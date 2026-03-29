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

namespace SoftwareEngineering
{
    public partial class Profilom : Form
    {
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
                // Optionally call this.Close() if the lifecycle rules allow it without destroying the app.
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
            MessageBox.Show("Adatok sikeressen mentve!");
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
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}