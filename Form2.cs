using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SoftwareEngineering
{
    public partial class Form2 : Form
    {
        // Updated connection string based on your SSMS screenshot
        private string connectionString = @"Server=LEXX\SQLEXPRESS;Database=UsedCars;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form2()
        {
            InitializeComponent();
            EnsureTableHasPasswordColumn();
        }

        private void EnsureTableHasPasswordColumn()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Checking if the password column exists in the Users table and adding it if missing
                    string addColumnQuery = @"
                        IF COL_LENGTH('dbo.Users', 'password') IS NULL
                        BEGIN
                            ALTER TABLE dbo.Users
                            ADD password NVARCHAR(50) NULL;
                        END";
                    using (SqlCommand cmd = new SqlCommand(addColumnQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // This might fail if the DB or table doesn't exist yet, but we'll show the error to help debug
                MessageBox.Show("Could not verify/update Users table schema: " + ex.Message, "Database Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxusern_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(pen, 0, panel1.Height, panel1.Width, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxusern.Text;
            string password = textBoxpass.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Fetch the precise casing from the database to perform a case-sensitive check in C#
                    string query = "SELECT name, password FROM Users WHERE name = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        bool loggedIn = false;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dbUsername = reader.GetString(0);
                                string dbPassword = reader.GetString(1);
                                
                                // C# strings correctly enforce exact upper/lower case matching
                                if (dbUsername == username && dbPassword == password)
                                {
                                    loggedIn = true;
                                    break;
                                }
                            }
                        }

                        if (loggedIn)
                        {
                            SessionManager.IsLoggedIn = true;
                            SessionManager.CurrentUser = username;
                            
                            MessageBox.Show("Login successful!");
                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox1.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Check if user exists using 'name' column and case-sensitive C# check
                    string checkQuery = "SELECT name FROM Users WHERE name = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        bool exists = false;
                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(0) == username)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                        }
                        
                        if (exists)
                        {
                            MessageBox.Show("Username already exists.");
                            return;
                        }
                    }
                    
                    // Insert new user matching your table structure
                    string insertQuery = "INSERT INTO Users (name, password) VALUES (@Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        
                        cmd.ExecuteNonQuery();
                        
                        SessionManager.IsLoggedIn = true;
                        SessionManager.CurrentUser = username;
                        
                        MessageBox.Show("Registration successful!");
                        
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }
    }
}
