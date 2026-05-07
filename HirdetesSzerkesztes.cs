using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace SoftwareEngineering
{
    public partial class HirdetesSzerkesztes : Form
    {
        private string connectionString = @"Server=LEXX\SQLEXPRESS;Database=UsedCars;Trusted_Connection=True;TrustServerCertificate=True;";
        private int adId;
        private string currentImageUrl = "";
        
        // Hasonló felépítést követünk, mint a Hirdetes formnál
        private Panel panel1 = new Panel();
        private TextBox Marka = new TextBox(); // javítva ComboBox-ról TextBox-ra
        private TextBox Modell = new TextBox();
        private TextBox Evjarat = new TextBox();
        private TextBox HP = new TextBox();
        private TextBox Milage = new TextBox();
        private TextBox Cubic = new TextBox();
        private TextBox Price = new TextBox();
        private TextBox Description = new TextBox();
        private ComboBox Fuel = new ComboBox();
        private ComboBox GearBox = new ComboBox();
        
        private Label lMarka = new Label { Text = "Márka:" };
        private Label lModell = new Label { Text = "Modell:" };
        private Label lEvjarat = new Label { Text = "Évjárat:" };
        private Label lHP = new Label { Text = "Teljesítmény (LE):" };
        private Label lMilage = new Label { Text = "Futásteljesítmény:" };
        private Label lCubic = new Label { Text = "Hengerûrtartalom (cm3):" };
        private Label lPrice = new Label { Text = "Ár ($):" };
        private Label lFuel = new Label { Text = "Üzemanyag:" };
        private Label lGearBox = new Label { Text = "Váltó:" };
        private Label lDesc = new Label { Text = "Leírás:" };

        public HirdetesSzerkesztes(int adIdToEdit)
        {
            this.adId = adIdToEdit;
            InitializeCustomComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadAdData();
        }

        private void InitializeCustomComponent()
        {
            this.Size = new Size(800, 600);
            this.Text = "Hirdetés Szerkesztése";
            this.BackColor = Color.LightSkyBlue;

            panel1.Size = new Size(700, 500);
            panel1.Location = new Point(40, 20);
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panel1);

            int yOffset = 20;
            int xLabel = 20;
            int xControl = 180;

            Control[] controls = {
                lMarka, Marka, lModell, Modell, lEvjarat, Evjarat,
                lHP, HP, lMilage, Milage, lCubic, Cubic,
                lPrice, Price, lFuel, Fuel, lGearBox, GearBox, lDesc, Description
            };

            Fuel.Items.AddRange(new object[] { "Benzin", "Dízel", "Elektromos", "Hibrid" });
            GearBox.Items.AddRange(new object[] { "Manuális", "Automata" });

            Description.Multiline = true;
            Description.Size = new Size(300, 80);

            for (int i = 0; i < controls.Length; i += 2)
            {
                // X eltolás a dizájn miatt, hogy kicsit beljebb kezdõdjön
                controls[i].Location = new Point(xLabel + 20, yOffset);
                controls[i].AutoSize = true;
                
                controls[i + 1].Location = new Point(xControl, yOffset);
                
                // Extra vizuális formázás a mezõknek (pl. kék alsó vonal imitálása)
                if (controls[i + 1] is TextBox tb)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.BackColor = Color.White;
                }
                
                if(controls[i + 1] != Description)
                {
                    controls[i + 1].Size = new Size(300, 25);
                    yOffset += 40;
                }
                else
                {
                    controls[i + 1].Size = new Size(300, 100);
                    yOffset += 115;
                }

                panel1.Controls.Add(controls[i]);
                panel1.Controls.Add(controls[i + 1]);
            }

            CreateAcceptButton();
            CreateCancelButton();
        }

        private void LoadAdData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lekérdezünk mindent (*), így sose lesz index csúszás
                    string query = "SELECT * FROM Ads WHERE ad_id = @AdId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdId", this.adId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Oszlopnevek alapján kérjük le az adatokat, elkerülve a kasztolási és sorrendi hibákat
                                Marka.Text = HasColumn(reader, "carbrand") && reader["carbrand"] != DBNull.Value ? reader["carbrand"].ToString() : "";
                                Modell.Text = HasColumn(reader, "carmodel") && reader["carmodel"] != DBNull.Value ? reader["carmodel"].ToString() : "";
                                Evjarat.Text = HasColumn(reader, "year") && reader["year"] != DBNull.Value ? reader["year"].ToString() : "";
                                HP.Text = HasColumn(reader, "performance") && reader["performance"] != DBNull.Value ? reader["performance"].ToString() : "";
                                Milage.Text = HasColumn(reader, "mileage_km") && reader["mileage_km"] != DBNull.Value ? reader["mileage_km"].ToString() : "";
                                Cubic.Text = HasColumn(reader, "ccm") && reader["ccm"] != DBNull.Value ? reader["ccm"].ToString() : "";
                                Fuel.Text = HasColumn(reader, "fuel") && reader["fuel"] != DBNull.Value ? reader["fuel"].ToString() : "";
                                GearBox.Text = HasColumn(reader, "transmission") && reader["transmission"] != DBNull.Value ? reader["transmission"].ToString() : "";
                                Description.Text = HasColumn(reader, "description") && reader["description"] != DBNull.Value ? reader["description"].ToString() : "";
                                Price.Text = HasColumn(reader, "price") && reader["price"] != DBNull.Value ? reader["price"].ToString() : "";
                                
                                if (HasColumn(reader, "picture_url"))
                                {
                                    currentImageUrl = reader["picture_url"] != DBNull.Value ? reader["picture_url"].ToString() : "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("A hirdetés nem található az adatbázisban!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Segédfüggvény, ami ellenõrzi, hogy létezik-e az az oszlop az adatbázisban
        private bool HasColumn(IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        private void CreateAcceptButton()
        {
            Button accept = new Button();
            accept.Size = new Size(50, 50);
            accept.FlatStyle = FlatStyle.Flat;
            accept.FlatAppearance.BorderSize = 0;
            accept.BackColor = Color.LightGreen;
            accept.Cursor = Cursors.Hand;

            string acceptPath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\accept.png";
            if (System.IO.File.Exists(acceptPath))
            {
                accept.Image = ResizeImage(Image.FromFile(acceptPath), 25, 25);
                accept.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                accept.Text = "V";
            }

            accept.Location = new Point(panel1.Width - accept.Width - 50, panel1.Height - accept.Height - 50);
            panel1.Controls.Add(accept);
            MakeRound(accept);
            accept.BringToFront();
            accept.Click += Accept_Click;
        }

        private void CreateCancelButton()
        {
            Button cancel = new Button();
            cancel.Size = new Size(50, 50);
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.FlatAppearance.BorderSize = 0;
            cancel.BackColor = Color.Tomato;
            cancel.Cursor = Cursors.Hand;
            cancel.Text = "X";
            cancel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            cancel.ForeColor = Color.White;

            cancel.Location = new Point(panel1.Width - cancel.Width - 110, panel1.Height - cancel.Height - 50);
            panel1.Controls.Add(cancel);
            MakeRound(cancel);
            cancel.BringToFront();
            cancel.Click += Cancel_Click;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Marka.Text) || string.IsNullOrWhiteSpace(Modell.Text) || string.IsNullOrWhiteSpace(Price.Text))
            {
                MessageBox.Show("Kérlek töltsd ki legalább a Márka, Modell és Ára mezõket!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                        UPDATE Ads SET
                        carbrand = @CarBrand, carmodel = @CarModel, year = @Year, performance = @Performance, 
                        mileage_km = @Mileage, ccm = @Ccm, fuel = @Fuel, transmission = @Transmission, 
                        description = @Description, price = @Price
                        WHERE ad_id = @AdId";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdId", adId);
                        cmd.Parameters.AddWithValue("@CarBrand", Marka.Text.Trim());
                        cmd.Parameters.AddWithValue("@CarModel", Modell.Text.Trim());

                        cmd.Parameters.AddWithValue("@Year", string.IsNullOrWhiteSpace(Evjarat.Text) ? (object)DBNull.Value : int.Parse(Evjarat.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Performance", string.IsNullOrWhiteSpace(HP.Text) ? (object)DBNull.Value : HP.Text.Trim());
                        cmd.Parameters.AddWithValue("@Mileage", string.IsNullOrWhiteSpace(Milage.Text) ? (object)DBNull.Value : int.Parse(Milage.Text.Trim()));

                        object ccmValue = int.TryParse(Cubic.Text.Trim(), out int ccmParsed) ? ccmParsed : (object)DBNull.Value;
                        cmd.Parameters.AddWithValue("@Ccm", ccmValue);

                        cmd.Parameters.AddWithValue("@Fuel", Fuel.SelectedItem != null ? Fuel.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Transmission", GearBox.SelectedItem != null ? GearBox.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", string.IsNullOrWhiteSpace(Price.Text) ? (object)DBNull.Value : Convert.ToDecimal(Price.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(Description.Text) ? (object)DBNull.Value : Description.Text.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Hirdetés sikeresen frissítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        GoBackToProfile();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a frissítés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            GoBackToProfile();
        }

        private void GoBackToProfile()
        {
            Profilom p = new Profilom();
            p.Show();
            this.Close();
        }

        private void MakeRound(Control control)
        {
            using (GraphicsPath gp = new GraphicsPath())
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
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
    }
}
