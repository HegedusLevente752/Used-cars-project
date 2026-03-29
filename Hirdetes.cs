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
using System.Drawing.Drawing2D; // EZ KELL A GRAPHICSPATH MIATT

namespace SoftwareEngineering
{
    public partial class Hirdetes : Form
    {
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
            }
        }

        private void Profilom_Load(object sender, EventArgs e)
        {
            Button accept = new Button();
            accept.Size = new Size(50, 50); // Itt állítsd be a kör méretét
            accept.FlatStyle = FlatStyle.Flat;
            accept.FlatAppearance.BorderSize = 0;
            accept.BackColor = Color.LightGreen;

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

            // Eseménykezelő (ha rákattintasz, történjen valami)
            accept.Click += (s, ev) =>
            {
                MessageBox.Show("Elfogadva!");
            };
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
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}

