using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic; // Kérlek add hozzá csomagként, ha InputBox-ot szeretnél használni vagy hozz létre egy új formot neki

namespace SoftwareEngineering
{
    public partial class Hirdetes : Form
    {
        private string connectionString = @"Server=LEXX\SQLEXPRESS;Database=UsedCars;Trusted_Connection=True;TrustServerCertificate=True;";

        public Hirdetes()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Ahhoz, hogy hirdetéseket tekints meg vagy adj fel, kérlek jelentkezz be.", "Bejelentkezés szükséges", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
                return; // Ha nincs bejelentkezve, ne fusson tovább a kód
            }

            // Gomb létrehozása, mert eddig nem hívta meg semmi az init kódot!
            CreateAcceptButton();
        }

        private void CreateAcceptButton()
        {
            Button accept = new Button();
            accept.Size = new Size(50, 50); // Itt állítsd be a kör méretét
            accept.FlatStyle = FlatStyle.Flat;
            accept.FlatAppearance.BorderSize = 0;
            accept.BackColor = Color.LightGreen;
            accept.Cursor = Cursors.Hand; // Legyen kéz kurzor fölötte

            string acceptPath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\accept.png";

            if (System.IO.File.Exists(acceptPath))
            {
                // A gomb Image-ét középre igazítja a WinForms alapból, ha nincs Text
                accept.Image = ResizeImage(Image.FromFile(acceptPath), 25, 25);
                accept.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                accept.Text = "V";
            }

            // Pozicionálás: Jobbról 50, alulról 50 pixel (a panel szélétől a gomb széléig)
            accept.Location = new Point(panel1.Width - accept.Width - 50, panel1.Height - accept.Height - 50);

            // Tedd rá a panelre és legyen kerek
            panel1.Controls.Add(accept);
            MakeRound(accept);
            accept.BringToFront(); // Hozzuk előtérbe, hogy biztosan kattintható legyen

            // Eseménykezelő feliratkozás
            accept.Click += Accept_Click;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy minden kötelező mező ki van-e töltve
            if (string.IsNullOrWhiteSpace(Marka.Text) || string.IsNullOrWhiteSpace(Modell.Text) || string.IsNullOrWhiteSpace(Price.Text))
            {
                MessageBox.Show("Kérlek töltsd ki legalább a Márka, Modell és Ára mezőket!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kép URL bekérése egy InputBox segítségével (feltételezve, hogy nincs külön TextBox neki a formon)
            // Cserélhető arra is, ha hozzáaddsz pl. egy TextBox_ImageUrl mezőt a formhoz.
            string imageUrl = Interaction.InputBox("Kérlek add meg a feltöltendő kép URL-jét (vagy hagyd üresen, ha nincs):", "Kép URL feltöltése", "");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Mivel a Form2.cs alapján a Users táblában nincs külön ID csak név (vagy a primary kulcs id helyett 'user_id'),
                    // És a legutóbbi hibaüzenet miatt tudjuk, hogy 'user_id' hiányzik/ismeretlen oszlop a Usersben.
                    int? userId = null;
                    // Megpróbáljuk lekérni az 'u_id' mezőt a Users táblából (A kép alapján 'u_id' a neve!)
                    string getUserIdQuery = "SELECT u_id FROM Users WHERE name = @Owner";
                    using (SqlCommand userCmd = new SqlCommand(getUserIdQuery, conn))
                    {
                        userCmd.Parameters.AddWithValue("@Owner", SessionManager.CurrentUser);
                        object result = userCmd.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }

                    // Az oszlopnevek a képen látottakhoz lettek igazítva. A 'cubic' nem szerepel a képen, így azt kihagyjuk.
                    string insertQuery = @"
                        INSERT INTO Ads
                        (user_id, carbrand, carmodel, year, performance, mileage_km, ccm, fuel, transmission, description, price, picture_url, likes) 
                        VALUES 
                        (@UserId, @CarBrand, @CarModel, @Year, @Performance, @Mileage, @Ccm, @Fuel, @Transmission, @Description, @Price, @PictureUrl, 0)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId.HasValue ? (object)userId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@CarBrand", Marka.Text.Trim());
                        cmd.Parameters.AddWithValue("@CarModel", Modell.Text.Trim());

                        // Számok konvertálása és null check
                        cmd.Parameters.AddWithValue("@Year", string.IsNullOrWhiteSpace(Evjarat.Text) ? (object)DBNull.Value : int.Parse(Evjarat.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Performance", string.IsNullOrWhiteSpace(HP.Text) ? (object)DBNull.Value : HP.Text.Trim());
                        cmd.Parameters.AddWithValue("@Mileage", string.IsNullOrWhiteSpace(Milage.Text) ? (object)DBNull.Value : int.Parse(Milage.Text.Trim()));

                        object ccmValue = int.TryParse(Cubic.Text.Trim(), out int ccmParsed) ? ccmParsed : (object)DBNull.Value;
                        cmd.Parameters.AddWithValue("@Ccm", ccmValue);

                        cmd.Parameters.AddWithValue("@Fuel", Fuel.SelectedItem != null ? Fuel.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Transmission", GearBox.SelectedItem != null ? GearBox.SelectedItem.ToString() : (object)DBNull.Value);

                        // Ár konvertálása decimálissá
                        cmd.Parameters.AddWithValue("@Price", string.IsNullOrWhiteSpace(Price.Text) ? (object)DBNull.Value : Convert.ToDecimal(Price.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(Description.Text) ? (object)DBNull.Value : Description.Text.Trim());
                        cmd.Parameters.AddWithValue("@PictureUrl", string.IsNullOrWhiteSpace(imageUrl) ? (object)DBNull.Value : imageUrl);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Hirdetés sikeresen közzétéve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opcionális: mezők ürítése mentés után
                        Marka.Text = ""; Modell.Text = ""; Evjarat.Text = ""; HP.Text = ""; Milage.Text = "";
                        Cubic.Text = ""; Price.Text = ""; Description.Text = ""; Fuel.SelectedIndex = -1; GearBox.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a mentés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakeRound(Control control)
        {
            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, control.Width, control.Height);
                control.Region = new Region(gp);
            }
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }





        // Delete gomb eseménykezelője

        private void HP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            int diameter = 35;
            int margin = 50;
            int x = panel1.Width - 50;
            int y = panel1.Height - 50;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Brush brush = new SolidBrush(Color.LightGreen))
            {
                e.Graphics.FillEllipse(brush, x, y, diameter, diameter);
            }

            string acceptPath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\accept.png";

            if (System.IO.File.Exists(acceptPath))
            {
                using (Image originalIcon = Image.FromFile(acceptPath))
                {
                    int iconSize = 30;
                    int iconX = x + (diameter - iconSize) / 2;
                    int iconY = y + (diameter - iconSize) / 2;

                    e.Graphics.DrawImage(originalIcon, iconX, iconY, iconSize, iconSize);
                }
            }
            else
            {
                using (Font font = new Font("Arial", 20, FontStyle.Bold))
                {
                    string text = "V";
                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    float textX = x + (diameter - textSize.Width) / 2;
                    float textY = y + (diameter - textSize.Height) / 2;

                    e.Graphics.DrawString(text, font, Brushes.White, textX, textY);
                }
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profilom profilom = new Profilom();
            profilom.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.Logout();
                MessageBox.Show("Sikeresen kijelentkeztél.", "Kijelentkezve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void GearBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

