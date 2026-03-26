namespace SoftwareEngineering
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            DriveZone = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            UserName = new Label();
            textBoxusern = new TextBox();
            textBoxpass = new TextBox();
            PassWord = new Label();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DriveZone
            // 
            DriveZone.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DriveZone.ForeColor = Color.Navy;
            DriveZone.Location = new Point(74, 30);
            DriveZone.Name = "DriveZone";
            DriveZone.Size = new Size(128, 33);
            DriveZone.TabIndex = 3;
            DriveZone.Text = "DriveZone";
            DriveZone.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-58, -33);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(86, 80);
            label1.Name = "label1";
            label1.Size = new Size(492, 75);
            label1.TabIndex = 4;
            label1.Text = "BEJELENTKEZÉS";
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            UserName.Location = new Point(107, 220);
            UserName.Name = "UserName";
            UserName.Size = new Size(234, 45);
            UserName.TabIndex = 5;
            UserName.Text = "Felhasználónév";
            // 
            // textBoxusern
            // 
            textBoxusern.AllowDrop = true;
            textBoxusern.BackColor = Color.SteelBlue;
            textBoxusern.BorderStyle = BorderStyle.FixedSingle;
            textBoxusern.Cursor = Cursors.IBeam;
            textBoxusern.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxusern.Location = new Point(107, 268);
            textBoxusern.Multiline = true;
            textBoxusern.Name = "textBoxusern";
            textBoxusern.Size = new Size(434, 60);
            textBoxusern.TabIndex = 6;
            // 
            // textBoxpass
            // 
            textBoxpass.AllowDrop = true;
            textBoxpass.BackColor = Color.SteelBlue;
            textBoxpass.BorderStyle = BorderStyle.FixedSingle;
            textBoxpass.Cursor = Cursors.IBeam;
            textBoxpass.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxpass.Location = new Point(107, 421);
            textBoxpass.Multiline = true;
            textBoxpass.Name = "textBoxpass";
            textBoxpass.PasswordChar = '*';
            textBoxpass.Size = new Size(434, 60);
            textBoxpass.TabIndex = 8;
            textBoxpass.TextChanged += textBox2_TextChanged;
            // 
            // PassWord
            // 
            PassWord.AutoSize = true;
            PassWord.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            PassWord.Location = new Point(107, 373);
            PassWord.Name = "PassWord";
            PassWord.Size = new Size(103, 45);
            PassWord.TabIndex = 7;
            PassWord.Text = "Jelszó";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Location = new Point(614, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 706);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(23, 299);
            label2.Name = "label2";
            label2.Size = new Size(192, 86);
            label2.TabIndex = 0;
            label2.Text = "VAGY";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(107, 546);
            button1.Name = "button1";
            button1.Size = new Size(434, 56);
            button1.TabIndex = 10;
            button1.Text = "Bejelentkezés";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSkyBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(925, 546);
            button2.Name = "button2";
            button2.Size = new Size(434, 56);
            button2.TabIndex = 16;
            button2.Text = "Regisztrálás";
            button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.BackColor = Color.SteelBlue;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(925, 421);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(434, 60);
            textBox1.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(925, 373);
            label3.Name = "label3";
            label3.Size = new Size(103, 45);
            label3.TabIndex = 14;
            label3.Text = "Jelszó";
            // 
            // textBox2
            // 
            textBox2.AllowDrop = true;
            textBox2.BackColor = Color.SteelBlue;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox2.Location = new Point(925, 268);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(434, 60);
            textBox2.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(925, 220);
            label4.Name = "label4";
            label4.Size = new Size(234, 45);
            label4.TabIndex = 12;
            label4.Text = "Felhasználónév";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(913, 80);
            label5.Name = "label5";
            label5.Size = new Size(468, 75);
            label5.TabIndex = 11;
            label5.Text = "REGISZTRÁCIÓ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1424, 761);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(textBoxpass);
            Controls.Add(PassWord);
            Controls.Add(textBoxusern);
            Controls.Add(UserName);
            Controls.Add(label1);
            Controls.Add(DriveZone);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "Login Panel";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DriveZone;
        private PictureBox pictureBox1;
        private Label label1;
        private Label UserName;
        private TextBox textBoxusern;
        private TextBox textBoxpass;
        private Label PassWord;
        private Panel panel1;
        private Label label2;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
    }
}