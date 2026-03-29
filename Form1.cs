using System.Windows.Forms;

namespace SoftwareEngineering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            if (SessionManager.IsLoggedIn)
            {
                button1.Text = "Kijelentkezés";
                // Optionally show the logged in user's name
                // UserNameLabel.Text = SessionManager.CurrentUser; 
            }
            else
            {
                button1.Text = "Bejelentkezés";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Ahhoz, hogy megtekintsd a profilodat, kérlek jelentkezz be.", "Bejelentkezés szükséges", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Profilom profilom = new Profilom();
            profilom.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                // Logout logic
                SessionManager.Logout();
                UpdateUI();
                MessageBox.Show("Sikeresen kijelentkeztél.", "Kijelentkezve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Login logic
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Ahhoz, hogy hirdetést tegyél közzé, kérlek jelentkezz be.", "Bejelentkezés szükséges", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Hirdetes hirdetes = new Hirdetes();
            hirdetes.Show();
            this.Hide();
        }
    }
}
