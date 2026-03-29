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

                    // Mivel a "name" oszlopban tároljuk a felhasználó nevét, a "name" alapján végezzük a WHERE-t is.
                    // FRISSÍTÉS: Frissítjük a nevet is, meg kell oldani ha a name frissül az legyen a current user.
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
    }
}