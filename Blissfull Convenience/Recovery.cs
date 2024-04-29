using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Blissfull_Convenience
{
    public partial class Recovery : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private string server;
        private string database;
        private string uid;
        private string pass;
        private int adminId;

        public Recovery()
        {
            InitializeComponent();
            InitializeDatabase();
            CheckConfirmButtonEnabled();
            newPass.Enabled = false;
            confirmPass.Enabled = false;
            confirm.Enabled = false;

        }
        private void InitializeDatabase()
        {
            server = "localhost";
            database = "blissful_convenience";
            uid = "root";
            pass = "erick";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            connection = new MySqlConnection(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            string username = UserText.Text;

            try
            {
                connection.Open();

                string query = "SELECT * FROM admin WHERE username=@username";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Admin account found!");
                        adminId = reader.GetInt32("id");
                        newPass.Enabled = true;
                        confirmPass.Enabled = true;
                        confirm.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Admin account not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string newPassword = newPass.Text;
            string confirmedPassword = confirmPass.Text;

            if (newPassword != confirmedPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            try
            {
                connection.Open();

                string query = "UPDATE admin SET password = @password WHERE id = @adminId";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@adminId", this.adminId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to change password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void CheckConfirmButtonEnabled()
        {
            confirm.Enabled = !string.IsNullOrWhiteSpace(newPass.Text) && !string.IsNullOrWhiteSpace(confirmPass.Text);
        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            CheckConfirmButtonEnabled();
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            CheckConfirmButtonEnabled();
        }

        private void UserText_TextChanged(object sender, EventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Form1();
            Login.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

