using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // EZ KELL A GRAPHICSPATH MIATT
using Microsoft.Data.SqlClient;

namespace SoftwareEngineering
{
    public partial class Profilom : Form
    {
        private string connectionString = @"Server=LEXX\SQLEXPRESS;Database=UsedCars;Trusted_Connection=True;TrustServerCertificate=True;";

        public Profilom()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Ahhoz, hogy megtekintsd a profilodat, kérlek jelentkezz be.", "Bejelentkezés szükséges", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
                return;
            }

            // Engedélyezzük a mentés gombot
            button4.Enabled = true;

            // Betöltjük a bejelentkezett felhasználó adatait
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // lekérjük a user adatait a name alapján (mivel a Form2 a name oszlopot használja username-ként)
                    string query = "SELECT name, phonenumber, location FROM Users WHERE name = @CurrentUsername";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CurrentUsername", SessionManager.CurrentUser);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                textBox2.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                textBox3.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadUserAds();
        }

        private void LoadUserAds()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // u_id megszerzése a CurrentUser alapján
                    int? userId = null;
                    string getUserIdQuery = "SELECT u_id FROM Users WHERE name = @CurrentUsername";
                    using (SqlCommand idCmd = new SqlCommand(getUserIdQuery, conn))
                    {
                        idCmd.Parameters.AddWithValue("@CurrentUsername", SessionManager.CurrentUser);
                        object result = idCmd.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }

                    if (!userId.HasValue) return; // Nem találtunk usert

                    // Lekérdezzük a hirdetéseket
                    string query = "SELECT ad_id, carbrand, carmodel, year, price, performance, mileage_km, fuel, likes FROM Ads WHERE user_id = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId.Value);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int yOffset = 0; // Két panel közti függőleges távolság

                            // A panel4 az amibe pakoljuk az elemeket? Ezt előbb is üríthetjük (ha van benne valami)
                            panel4.Controls.Clear();

                            while (reader.Read())
                            {
                                // Adatok beolvasása, DBNull ellenőrzéssel
                                int adId = reader.GetInt32(0);
                                string carBrand = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string carModel = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                int? year = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                                decimal? price = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4);
                                string performance = reader.IsDBNull(5) ? "" : reader.GetString(5);
                                int? mileage = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                                string fuel = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                int likes = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);

                                // Fő panel (kék kártya)
                                Panel adPanel = new Panel();
                                adPanel.Width = panel4.Width - 10; // vagy ahogy szeretnéd
                                adPanel.Height = panel3.Height; // Vegyük át a panel3 magasságát (vagy statikus: 150)
                                adPanel.Location = new Point(5, yOffset);
                                adPanel.BackColor = Color.LightSkyBlue; // a képen látható kékes szín
                                adPanel.BorderStyle = BorderStyle.FixedSingle;

                                // Marka + model (Satsuma \n AMP GT)
                                Label lblTitle = new Label();
                                lblTitle.Text = $"{carBrand}\n{carModel}";
                                lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Regular); // vagy ami tetszik
                                lblTitle.Location = new Point(10, 10);
                                lblTitle.AutoSize = true;
                                adPanel.Controls.Add(lblTitle);

                                // Évszám (1975) (Jobb felül)
                                Label lblYear = new Label();
                                lblYear.Text = year.HasValue ? year.Value.ToString() : "";
                                lblYear.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                                lblYear.ForeColor = Color.DimGray;
                                lblYear.AutoSize = true;
                                // Nem biztos a pozíció, nagyjából
                                lblYear.Location = new Point(adPanel.Width - 80, 20);
                                adPanel.Controls.Add(lblYear);

                                // Ár (Ára: 1,500 $)
                                Label lblPrice = new Label();
                                lblPrice.Text = $"Ára: {price?.ToString("N0")} $";
                                lblPrice.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                                lblPrice.Location = new Point(10, 80);
                                lblPrice.AutoSize = true;
                                adPanel.Controls.Add(lblPrice);

                                // Kedvelések (Kedvelések: 128)
                                Label lblLikes = new Label();
                                lblLikes.Text = $"Kedvelések: {likes}";
                                lblLikes.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                                lblLikes.ForeColor = Color.DimGray;
                                lblLikes.Location = new Point(10, 110);
                                lblLikes.AutoSize = true;
                                adPanel.Controls.Add(lblLikes);

                                // Teljesítmény stb (Középen jobbra dőlve)
                                Label lblDetails = new Label();
                                lblDetails.Text = $"Teljesítmény: {performance} Lóerő\nFutásteljesítmény: {mileage} Km\nÜzemanyag: {fuel}";
                                lblDetails.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                                lblDetails.ForeColor = Color.DimGray;
                                lblDetails.Location = new Point(adPanel.Width / 2 - 50, 80);
                                lblDetails.AutoSize = true;
                                adPanel.Controls.Add(lblDetails);


                                // Gombok is kellenek-e ide? Ha igen, itt hozzáadhatók (Edit, Delete)
                                Button edit = new Button();
                                edit.Size = new Size(35, 35);
                                edit.FlatStyle = FlatStyle.Flat;
                                edit.FlatAppearance.BorderSize = 0;
                                edit.BackColor = Color.FromArgb(70, 100, 240);
                                edit.Cursor = Cursors.Hand;
                                edit.Tag = adId; // Eltároljuk a hirdetés azonosítóját a szerkesztéshez

                                string editPath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\edit.png";
                                if (System.IO.File.Exists(editPath))
                                {
                                    Image img = Image.FromFile(editPath);
                                    edit.Image = new Bitmap(img, new Size(20, 20));
                                    img.Dispose();
                                }
                                else
                                {
                                    edit.Text = "E";
                                }

                                edit.Location = new Point(adPanel.Width - 50, adPanel.Height - 50);
                                MakeRound(edit);
                                edit.Click += DynamicEdit_Click;
                                adPanel.Controls.Add(edit);

                                panel4.Controls.Add(adPanel);
                                yOffset += adPanel.Height + 10; // Következő elem lentebb kezdődik
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a hirdetések betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(pen, 0, panel2.Height - 1, panel2.Width, panel2.Height - 1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Profilom_Load(object sender, EventArgs e)
        {
            // Panel3-ra teszi, ez lehet, hogy át kell rakni, de maradjon most ahogy volt.
            // Lásd: Ha a panel4-be generáljuk dinamikusan az itemeket, ott hoznánk létre őket kártyánként
            Button edit = new Button();
            Button delete = new Button();

            edit.Size = new Size(35, 35);
            delete.Size = new Size(35, 35);

            edit.FlatStyle = FlatStyle.Flat;
            edit.FlatAppearance.BorderSize = 0;
            edit.BackColor = Color.FromArgb(70, 100, 240);

            delete.FlatStyle = FlatStyle.Flat;
            delete.FlatAppearance.BorderSize = 0;
            delete.BackColor = Color.Tomato;


            string editPath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\edit.png";
            string deletePath = @"C:\Users\Hegedus\Documents\OOP\SoftwareEngineering\delete.png";

            if (System.IO.File.Exists(editPath))
            {
                edit.Image = ResizeImage(Image.FromFile(editPath), 20, 20);
            }
            else
            {
                edit.Text = "E"; // Ha nincs meg a fájl, egy betű jelzi
            }

            if (System.IO.File.Exists(deletePath))
            {
                delete.Image = ResizeImage(Image.FromFile(deletePath), 20, 20);
            }
            else
            {
                delete.Text = "X";
            }

            // int vCenter = (panel3.Height / 2) - (edit.Height / 2);
            edit.Location = new Point(panel3.Width - 100, panel3.Height - 50);
            delete.Location = new Point(panel3.Width - 50, panel3.Height - 50);

            MakeRound(edit);
            MakeRound(delete);

            edit.Click += Edit_Click;
            delete.Click += Delete_Click;

            panel3.Controls.Add(edit);
            panel3.Controls.Add(delete);
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap destRect = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(destRect))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return destRect;
        }

        private void MakeRound(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }


        private void Edit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit megnyomva!");

        }

        private void DynamicEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                int adId = (int)btn.Tag;
                // Megnyitjuk a szerkesztő formot, majd elrejtjük / bezárjuk ezt
                HirdetesSzerkesztes editForm = new HirdetesSzerkesztes(adId);
                editForm.Show();
                this.Hide();
            }
        }

        // Delete gomb eseménykezelője
        private void Delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete megnyomva!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string newName = textBox1.Text.Trim(); // Ez itt már tényleg a valós, teljes név (name)
            string newPhone = textBox2.Text.Trim();
            string newLocation = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("A név nem lehet üres!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lekérjük a jelenlegi felhasználó u_id-ját, ha létezik
                    int? currentUserId = null;
                    string getIdQuery = "SELECT u_id FROM Users WHERE name = @CurrentUsername";
                    using (SqlCommand idCmd = new SqlCommand(getIdQuery, conn))
                    {
                        idCmd.Parameters.AddWithValue("@CurrentUsername", SessionManager.CurrentUser);
                        object idResult = idCmd.ExecuteScalar();
                        if (idResult != null && idResult != DBNull.Value)
                            currentUserId = Convert.ToInt32(idResult);
                    }

                    // Ellenőrizzük, hogy az új név foglalt-e már egy másik user által
                    string checkQuery;
                    if (currentUserId.HasValue)
                    {
                        checkQuery = "SELECT COUNT(1) FROM Users WHERE name = @NewName AND u_id <> @CurrentId";
                    }
                    else
                    {
                        // Ha nem tudtuk lekérni az u_id-t, akkor név alapján ellenőrizzük (kevésbé garantált, de jobb, mint semmi)
                        checkQuery = "SELECT COUNT(1) FROM Users WHERE name = @NewName AND name <> @CurrentUsername";
                    }

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@NewName", newName);
                        if (currentUserId.HasValue)
                            checkCmd.Parameters.AddWithValue("@CurrentId", currentUserId.Value);
                        else
                            checkCmd.Parameters.AddWithValue("@CurrentUsername", SessionManager.CurrentUser);

                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists > 0)
                        {
                            MessageBox.Show("A megadott név már foglalt. Válassz másikat.", "Név foglalt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Frissítés végrehajtása
                    string updateQuery = "UPDATE Users SET name = @NewName, phonenumber = @Phone, location = @Location WHERE name = @CurrentUsername";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewName", newName);
                        // Null check kezelése a telefonhoz és lokációhoz
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(newPhone) ? (object)DBNull.Value : newPhone);
                        cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(newLocation) ? (object)DBNull.Value : newLocation);
                        cmd.Parameters.AddWithValue("@CurrentUsername", SessionManager.CurrentUser);

                        cmd.ExecuteNonQuery();

                        // Ha az azonosításra használt nevet is módosítottuk, frissíteni kell a session-t
                        SessionManager.CurrentUser = newName;

                        MessageBox.Show("Adatok sikeresen mentve!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a mentés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                Hirdetes hirdetes = new Hirdetes();
                hirdetes.Show();
                this.Hide();
            }
        }
    }
}