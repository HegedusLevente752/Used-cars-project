namespace SoftwareEngineering
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button button1;
            Button button2;
            Button button3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            DriveZone = new Label();
            panel1 = new Panel();
            button4 = new Button();
            comboBox6 = new ComboBox();
            label6 = new Label();
            comboBox5 = new ComboBox();
            label5 = new Label();
            comboBox4 = new ComboBox();
            label4 = new Label();
            comboBox3 = new ComboBox();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            ListaGorgeto = new VScrollBar();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(1265, 27);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 41);
            button1.TabIndex = 2;
            button1.Text = "Bejelentkezés";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(1124, 27);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(106, 41);
            button2.TabIndex = 3;
            button2.Text = "Profilom";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gold;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(893, 29);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(196, 41);
            button3.TabIndex = 4;
            button3.Text = "Hirdetés közzététele";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-58, -34);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // DriveZone
            // 
            DriveZone.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DriveZone.ForeColor = Color.Navy;
            DriveZone.Location = new Point(74, 29);
            DriveZone.Name = "DriveZone";
            DriveZone.Size = new Size(129, 33);
            DriveZone.TabIndex = 1;
            DriveZone.Text = "DriveZone";
            DriveZone.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(comboBox6);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(comboBox5);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-8, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 667);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.RoyalBlue;
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(19, 607);
            button4.Name = "button4";
            button4.Size = new Size(280, 42);
            button4.TabIndex = 7;
            button4.Text = "Keresés";
            button4.UseVisualStyleBackColor = false;
            // 
            // comboBox6
            // 
            comboBox6.BackColor = SystemColors.InactiveCaption;
            comboBox6.FlatStyle = FlatStyle.Popup;
            comboBox6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(20, 537);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(279, 29);
            comboBox6.Sorted = true;
            comboBox6.TabIndex = 15;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(82, 500);
            label6.Name = "label6";
            label6.Size = new Size(167, 23);
            label6.TabIndex = 16;
            label6.Text = "Max Km óra állás";
            // 
            // comboBox5
            // 
            comboBox5.BackColor = SystemColors.InactiveCaption;
            comboBox5.FlatStyle = FlatStyle.Popup;
            comboBox5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(20, 440);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(279, 29);
            comboBox5.Sorted = true;
            comboBox5.TabIndex = 13;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(129, 397);
            label5.Name = "label5";
            label5.Size = new Size(57, 23);
            label5.TabIndex = 14;
            label5.Text = "Váltó";
            // 
            // comboBox4
            // 
            comboBox4.BackColor = SystemColors.InactiveCaption;
            comboBox4.FlatStyle = FlatStyle.Popup;
            comboBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(19, 351);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(280, 29);
            comboBox4.Sorted = true;
            comboBox4.TabIndex = 11;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(129, 311);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 12;
            label4.Text = "Motor";
            // 
            // comboBox3
            // 
            comboBox3.BackColor = SystemColors.InactiveCaption;
            comboBox3.FlatStyle = FlatStyle.Popup;
            comboBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(20, 256);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(279, 29);
            comboBox3.Sorted = true;
            comboBox3.TabIndex = 9;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(129, 210);
            label3.Name = "label3";
            label3.Size = new Size(79, 23);
            label3.TabIndex = 10;
            label3.Text = "Évjárat";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.InactiveCaption;
            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(20, 154);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(279, 29);
            comboBox2.Sorted = true;
            comboBox2.TabIndex = 7;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(129, 113);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 8;
            label2.Text = "Modell";
            label2.Click += label2_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.InactiveCaption;
            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 56);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(279, 29);
            comboBox1.Sorted = true;
            comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(129, 11);
            label1.Name = "label1";
            label1.Size = new Size(79, 23);
            label1.TabIndex = 6;
            label1.Text = "Gyártó";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSkyBlue;
            panel2.Controls.Add(ListaGorgeto);
            panel2.Location = new Point(425, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(929, 667);
            panel2.TabIndex = 6;
            // 
            // ListaGorgeto
            // 
            ListaGorgeto.Location = new Point(908, 0);
            ListaGorgeto.Name = "ListaGorgeto";
            ListaGorgeto.Size = new Size(21, 675);
            ListaGorgeto.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1424, 761);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(DriveZone);
            Controls.Add(pictureBox1);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Főoldal";
            TransparencyKey = Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label DriveZone;
        private Panel panel1;
        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox6;
        private Label label6;
        private ComboBox comboBox5;
        private Label label5;
        private ComboBox comboBox4;
        private Label label4;
        private ComboBox comboBox3;
        private Label label3;
        private ComboBox comboBox2;
        private Label label2;
        private Panel panel2;
        private Button button4;
        private VScrollBar ListaGorgeto;
    }
}
