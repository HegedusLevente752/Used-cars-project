namespace SoftwareEngineering
{
    partial class Hirdetes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button button3;
            Button button2;
            Button button1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hirdetes));
            DriveZone = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            Price = new TextBox();
            label7 = new Label();
            Description = new TextBox();
            label6 = new Label();
            GearBox = new ComboBox();
            label5 = new Label();
            Cubic = new TextBox();
            label4 = new Label();
            Fuel = new ComboBox();
            label3 = new Label();
            Milage = new TextBox();
            label2 = new Label();
            HP = new TextBox();
            label1 = new Label();
            Modell = new TextBox();
            Marka = new TextBox();
            pictureBox2 = new PictureBox();
            Evjarat = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Gold;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(893, 30);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(196, 41);
            button3.TabIndex = 10;
            button3.Text = "Hirdetés közzététele";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(1124, 28);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(106, 41);
            button2.TabIndex = 9;
            button2.Text = "Profilom";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(1265, 28);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 41);
            button1.TabIndex = 8;
            button1.Text = "Kijelentkezés";
            button1.UseVisualStyleBackColor = false;
            // 
            // DriveZone
            // 
            DriveZone.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DriveZone.ForeColor = Color.Navy;
            DriveZone.Location = new Point(77, 30);
            DriveZone.Name = "DriveZone";
            DriveZone.Size = new Size(129, 33);
            DriveZone.TabIndex = 5;
            DriveZone.Text = "DriveZone";
            DriveZone.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-55, -33);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(Price);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(Description);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(GearBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(Cubic);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(Fuel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Milage);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(HP);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Modell);
            panel1.Controls.Add(Marka);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(441, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(637, 453);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // Price
            // 
            Price.BackColor = Color.LightSkyBlue;
            Price.Cursor = Cursors.IBeam;
            Price.Location = new Point(119, 198);
            Price.Multiline = true;
            Price.Name = "Price";
            Price.PlaceholderText = "Ára";
            Price.Size = new Size(100, 26);
            Price.TabIndex = 24;
            Price.Tag = "";
            Price.Text = "  ";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label7.Location = new Point(70, 195);
            label7.Name = "label7";
            label7.Size = new Size(189, 37);
            label7.TabIndex = 23;
            label7.Text = "Ára:";
            // 
            // Description
            // 
            Description.BackColor = Color.LightSkyBlue;
            Description.Cursor = Cursors.IBeam;
            Description.Location = new Point(80, 278);
            Description.Multiline = true;
            Description.Name = "Description";
            Description.PlaceholderText = "Lóerő";
            Description.Size = new Size(554, 123);
            Description.TabIndex = 22;
            Description.Tag = "";
            Description.Text = "  ";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(3, 269);
            label6.Name = "label6";
            label6.Size = new Size(229, 37);
            label6.TabIndex = 21;
            label6.Text = "Leírás :";
            // 
            // GearBox
            // 
            GearBox.BackColor = Color.LightSkyBlue;
            GearBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            GearBox.FormattingEnabled = true;
            GearBox.Items.AddRange(new object[] { "Manuál", "Automata", "CVT", "DCT", "Szekvenciális" });
            GearBox.Location = new Point(354, 232);
            GearBox.Name = "GearBox";
            GearBox.Size = new Size(121, 25);
            GearBox.TabIndex = 20;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(286, 227);
            label5.Name = "label5";
            label5.Size = new Size(189, 37);
            label5.TabIndex = 19;
            label5.Text = "Váltó:";
            // 
            // Cubic
            // 
            Cubic.BackColor = Color.LightSkyBlue;
            Cubic.Cursor = Cursors.IBeam;
            Cubic.Location = new Point(480, 190);
            Cubic.Multiline = true;
            Cubic.Name = "Cubic";
            Cubic.PlaceholderText = "Motor méret";
            Cubic.Size = new Size(137, 26);
            Cubic.TabIndex = 18;
            Cubic.Tag = "";
            Cubic.Text = "  ";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(286, 184);
            label4.Name = "label4";
            label4.Size = new Size(205, 37);
            label4.TabIndex = 17;
            label4.Text = "Motor méret (ccm):";
            label4.Click += label4_Click;
            // 
            // Fuel
            // 
            Fuel.BackColor = Color.LightSkyBlue;
            Fuel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Fuel.FormattingEnabled = true;
            Fuel.Items.AddRange(new object[] { "Benzin", "Dízel", "Hybrid", "Elektromos" });
            Fuel.Location = new Point(422, 153);
            Fuel.Name = "Fuel";
            Fuel.Size = new Size(121, 25);
            Fuel.TabIndex = 16;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(286, 147);
            label3.Name = "label3";
            label3.Size = new Size(189, 37);
            label3.TabIndex = 15;
            label3.Text = "Üzemanyag:";
            // 
            // Milage
            // 
            Milage.BackColor = Color.LightSkyBlue;
            Milage.Cursor = Cursors.IBeam;
            Milage.Location = new Point(508, 115);
            Milage.Multiline = true;
            Milage.Name = "Milage";
            Milage.PlaceholderText = "Lóerő";
            Milage.Size = new Size(100, 26);
            Milage.TabIndex = 14;
            Milage.Tag = "";
            Milage.Text = "  ";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(286, 110);
            label2.Name = "label2";
            label2.Size = new Size(229, 37);
            label2.TabIndex = 13;
            label2.Text = "Futásteljesítmény (Km):";
            // 
            // HP
            // 
            HP.BackColor = Color.LightSkyBlue;
            HP.Cursor = Cursors.IBeam;
            HP.Location = new Point(471, 76);
            HP.Multiline = true;
            HP.Name = "HP";
            HP.PlaceholderText = "Lóerő";
            HP.Size = new Size(100, 26);
            HP.TabIndex = 12;
            HP.Tag = "";
            HP.Text = "  ";
            HP.TextChanged += HP_TextChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(286, 73);
            label1.Name = "label1";
            label1.Size = new Size(189, 37);
            label1.TabIndex = 3;
            label1.Text = "Teljesítmény (HP):";
            // 
            // Modell
            // 
            Modell.BackColor = Color.LightSkyBlue;
            Modell.Cursor = Cursors.IBeam;
            Modell.Location = new Point(286, 47);
            Modell.Multiline = true;
            Modell.Name = "Modell";
            Modell.PlaceholderText = "Modell";
            Modell.Size = new Size(189, 23);
            Modell.TabIndex = 2;
            Modell.Tag = "";
            // 
            // Marka
            // 
            Marka.BackColor = Color.LightSkyBlue;
            Marka.Cursor = Cursors.IBeam;
            Marka.Location = new Point(286, 18);
            Marka.Multiline = true;
            Marka.Name = "Marka";
            Marka.PlaceholderText = "Márka";
            Marka.Size = new Size(189, 23);
            Marka.TabIndex = 1;
            Marka.Tag = "";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(277, 189);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // Evjarat
            // 
            Evjarat.BackColor = Color.LightSkyBlue;
            Evjarat.Cursor = Cursors.IBeam;
            Evjarat.Location = new Point(949, 161);
            Evjarat.Multiline = true;
            Evjarat.Name = "Evjarat";
            Evjarat.PlaceholderText = "Évjárat";
            Evjarat.Size = new Size(85, 23);
            Evjarat.TabIndex = 3;
            Evjarat.Tag = "";
            // 
            // Hirdetes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1424, 761);
            Controls.Add(Evjarat);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(DriveZone);
            Controls.Add(pictureBox1);
            Name = "Hirdetes";
            Text = "Hirdetes";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DriveZone;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox Marka;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox Modell;
        private TextBox Evjarat;
        private TextBox HP;
        private Label label3;
        private TextBox Milage;
        private Label label2;
        private TextBox Cubic;
        private Label label4;
        private ComboBox Fuel;
        private TextBox Price;
        private Label label7;
        private TextBox Description;
        private Label label6;
        private ComboBox GearBox;
        private Label label5;
    }
}