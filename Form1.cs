using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareEngineering
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=LEXX\SQLEXPRESS;Database=UsedCars;Trusted_Connection=True;TrustServerCertificate=True;";
        private List<Panel> adPanels = new List<Panel>();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            panel3.Visible = false;
            panel2.AutoScroll = true;
            ListaGorgeto.Visible = false;

            UpdateUI();
            LoadFilterOptions();
            PopulateMileageCombo();
            button4.Enabled = true;
            button4.Click -= button4_Click;
            button4.Click += button4_Click;

            LoadAdvertisements();
        }

        private void LoadAdvertisements(string brand = null, string model = null, int? year = null, int? ccm = null, string transmission = null, int? maxMileage = null)
        {
            ClearAdPanels();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var queryBuilder = new StringBuilder(@"
                        SELECT a.*, u.name, u.phonenumber, u.location
                        FROM Ads a
                        LEFT JOIN Users u ON a.user_id = u.u_id");

                    var conditions = new List<string>();

                    if (!string.IsNullOrEmpty(brand))
                    {
                        conditions.Add("a.carbrand = @Brand");
                    }
                    if (!string.IsNullOrEmpty(model))
                    {
                        conditions.Add("a.carmodel = @Model");
                    }
                    if (year.HasValue)
                    {
                        conditions.Add("a.year = @Year");
                    }
                    if (ccm.HasValue)
                    {
                        conditions.Add("a.ccm = @Ccm");
                    }
                    if (!string.IsNullOrEmpty(transmission))
                    {
                        conditions.Add("a.transmission = @Transmission");
                    }
                    if (maxMileage.HasValue)
                    {
                        conditions.Add("a.mileage_km <= @MaxMileage");
                    }

                    if (conditions.Any())
                    {
                        queryBuilder.Append(" WHERE ").Append(string.Join(" AND ", conditions));
                    }

                    queryBuilder.Append(" ORDER BY a.ad_id DESC");

                    using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
                    {
                        if (!string.IsNullOrEmpty(brand))
                        {
                            cmd.Parameters.AddWithValue("@Brand", brand);
                        }
                        if (!string.IsNullOrEmpty(model))
                        {
                            cmd.Parameters.AddWithValue("@Model", model);
                        }
                        if (year.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Year", year.Value);
                        }
                        if (ccm.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Ccm", ccm.Value);
                        }
                        if (!string.IsNullOrEmpty(transmission))
                        {
                            cmd.Parameters.AddWithValue("@Transmission", transmission);
                        }
                        if (maxMileage.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@MaxMileage", maxMileage.Value);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int yOffset = 10;

                            while (reader.Read())
                            {
                                Panel newPanel = CreateAdPanel(reader, yOffset);
                                panel2.Controls.Add(newPanel);
                                adPanels.Add(newPanel);
                                yOffset += newPanel.Height + 20;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Autók betöltése sikertelen: " + ex.Message);
            }
        }

        private void ClearAdPanels()
        {
            foreach (Panel pnl in adPanels)
            {
                panel2.Controls.Remove(pnl);
                pnl.Dispose();
            }
            adPanels.Clear();
        }

        private void LoadFilterOptions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT carbrand, carmodel, year, ccm, transmission FROM Ads", conn))
                {
                    conn.Open();

                    var brands = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    var models = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    var years = new HashSet<int>();
                    var ccms = new HashSet<int>();
                    var transmissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                brands.Add(reader.GetString(0));
                            if (!reader.IsDBNull(1))
                                models.Add(reader.GetString(1));
                            if (!reader.IsDBNull(2))
                                years.Add(reader.GetInt32(2));
                            if (!reader.IsDBNull(3))
                                ccms.Add(reader.GetInt32(3));
                            if (!reader.IsDBNull(4))
                                transmissions.Add(reader.GetString(4));
                        }
                    }

                    PopulateCombo(comboBox1, brands);
                    PopulateCombo(comboBox2, models);
                    PopulateCombo(comboBox3, years.Select(y => y.ToString()), sortDescending: true);
                    PopulateCombo(comboBox4, ccms.Select(c => c.ToString()));
                    PopulateCombo(comboBox5, transmissions);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Szûrõk betöltése sikertelen: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCombo(ComboBox combo, IEnumerable<string> values, bool sortDescending = false)
        {
            combo.BeginUpdate();
            combo.Items.Clear();
            combo.Items.Add(string.Empty);

            IEnumerable<string> ordered = sortDescending
                ? values.Where(v => !string.IsNullOrWhiteSpace(v)).OrderByDescending(v => v)
                : values.Where(v => !string.IsNullOrWhiteSpace(v)).OrderBy(v => v);

            foreach (string value in ordered)
            {
                combo.Items.Add(value);
            }

            combo.SelectedIndex = 0;
            combo.EndUpdate();
        }

        private void PopulateMileageCombo()
        {
            int[] mileageSteps = { 50000, 100000, 150000, 200000, 250000, 300000, 400000, 500000 };
            comboBox6.BeginUpdate();
            comboBox6.Items.Clear();
            comboBox6.Items.Add(string.Empty);
            foreach (int value in mileageSteps)
            {
                comboBox6.Items.Add(value.ToString());
            }
            comboBox6.SelectedIndex = 0;
            comboBox6.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string brand = NormalizeFilter(comboBox1.Text);
            string model = NormalizeFilter(comboBox2.Text);
            int? year = ParseNullableInt(comboBox3.Text);
            int? ccm = ParseNullableInt(comboBox4.Text);
            string transmission = NormalizeFilter(comboBox5.Text);
            int? maxMileage = ParseNullableInt(comboBox6.Text);

            LoadAdvertisements(brand, model, year, ccm, transmission, maxMileage);
        }

        private static string NormalizeFilter(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }

        private static int? ParseNullableInt(string input)
        {
            return int.TryParse(input?.Trim(), out int value) ? value : null;
        }

        private Panel CreateAdPanel(SqlDataReader reader, int yPos)
        {
            // Panel másolása és klónozása kód alapján, de használhatnánk custom control-t is. 
            // Itt most létrehozunk egy új panelt, ami a panel3 vizuális stílusát másolja.
            Panel pnl = new Panel();
            pnl.BackColor = panel3.BackColor;
            pnl.Size = panel3.Size;
            pnl.Location = new Point(81, yPos);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // Készítünk egy metódust, ami segít címkét (Label) másolni és új szöveggel ellátni
            void CopyLabel(Label original, string newText)
            {
                Label lbl = new Label();
                lbl.Font = original.Font;
                lbl.ForeColor = original.ForeColor;
                lbl.Location = original.Location;
                lbl.Size = original.Size;
                lbl.AutoSize = original.AutoSize;
                lbl.Text = newText;
                lbl.BackColor = Color.Transparent; // Átlátszó háttér, hogy a "szélesebb" címkék ne takarják ki egymást
                pnl.Controls.Add(lbl);
                lbl.BringToFront(); // Biztosítja, hogy az új értékek biztosan látszódjanak és az elõtérbe kerüljenek
            }

            // Fix szövegek és formázások másolása (pl: "Márka:", "Váltó:", stb)
            CopyLabel(Loc, Loc.Text);
            CopyLabel(label18, label18.Text);
            CopyLabel(label9, label9.Text);
            CopyLabel(label12, label12.Text);
            CopyLabel(label22, label22.Text);
            CopyLabel(label19, label19.Text);
            CopyLabel(label16, label16.Text);
            CopyLabel(label13, label13.Text);
            CopyLabel(label10, label10.Text);
            CopyLabel(HP, HP.Text);
            CopyLabel(label7, label7.Text);
            CopyLabel(label14, label14.Text); // "ccm" label

            // Dinamikus adat mezõk feltöltése adatbázisból:
            // Feltételezve oszlopok jelenlétét a SELECT szerint
            string brand = reader["carbrand"] != DBNull.Value ? reader["carbrand"].ToString() : "";
            string model = reader["carmodel"] != DBNull.Value ? reader["carmodel"].ToString() : "";
            string year = reader["year"] != DBNull.Value ? reader["year"].ToString() : "";
            string hp = reader["performance"] != DBNull.Value ? reader["performance"].ToString() : "";
            string mileage = reader["mileage_km"] != DBNull.Value ? reader["mileage_km"].ToString() : "";
            string fuel = reader["fuel"] != DBNull.Value ? reader["fuel"].ToString() : "";
            string transmission = reader["transmission"] != DBNull.Value ? reader["transmission"].ToString() : "";
            string price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]).ToString("0.##") : "";
            string description = reader["description"] != DBNull.Value ? reader["description"].ToString() : "";
            string cubicCapacity = reader["ccm"] != DBNull.Value ? reader["ccm"].ToString() : "-";
            
            // Összekapcsolt (JOIN) Users adatok
            string ownerName = reader["name"] != DBNull.Value ? reader["name"].ToString() : "Ismeretlen";
            string ownerPhone = reader["phonenumber"] != DBNull.Value ? reader["phonenumber"].ToString() : "-";
            string ownerLocation = reader["location"] != DBNull.Value ? reader["location"].ToString() : "-";

            // Dinamikus címkék hozzáadása
            CopyLabel(CarBrand, brand);
            CopyLabel(CarModel, model);
            CopyLabel(Year, year);
            CopyLabel(HPAmount, hp);
            CopyLabel(Milage, mileage);
            CopyLabel(Fuel, fuel);
            CopyLabel(Trans, transmission);
            CopyLabel(Desc, description);
            CopyLabel(label8, price);           // az ár mezõje a panel3-on "label8" néven fut
            CopyLabel(CCm, cubicCapacity);
            CopyLabel(UserLocation, ownerLocation);
            CopyLabel(Number, ownerPhone);
            CopyLabel(UserNameLabel, ownerName);

            return pnl;
        }

        private void UpdateUI()
        {
            if (button1 == null) return; // Biztonsági ellenõrzés

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
