using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Blissfull_Convenience
{
    public partial class Admin : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private string server;
        private string database;
        private string uid;
        private string pass;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public Admin()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadDataIntoDataGridView();
            dataGridView1.CellClick += dataGridView1_CellClick;
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
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM admin";
                command = new MySqlCommand(query, connection);

                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
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
        private void AddNewAdmin(string acc, string pass)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO admin (username, password) VALUES (@acc, @pass)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@acc", acc);
                command.Parameters.AddWithValue("@pass", pass);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Admin added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add Admin!");
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
        private void UpdateAdmin(int adminid, string acc, string pass)
        {
            try
            {
                connection.Open();

                string query = "UPDATE admin SET username = @acc, password = @pass WHERE id = @adminid";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@acc", acc);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@adminid", adminid);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Admin information updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update admin information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating admin information: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Retrieve data from the selected row
                int accountid = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string acc = Convert.ToString(selectedRow.Cells["username"].Value);
                string pass = Convert.ToString(selectedRow.Cells["password"].Value);


                // Populate text boxes and controls with the selected row data
                Adminid.Text = accountid.ToString();
                username.Text = acc;
                password.Text = pass;
            }
        }
        private void customerbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cust = new Management();
            cust.Show();
        }

        private void employeebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var emp = new Employee();
            emp.Show();
        }

        private void orderitembtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var orderit = new orderitem();
            orderit.Show();
        }

        private void ordersbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ord = new order();
            ord.Show();
        }

        private void productbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prod = new Products();
            prod.Show();
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var adm = new Admin();
            adm.Show();
        }

        private void Addnewbtn_Click(object sender, EventArgs e)
        {
            string acc = username.Text;
            string pass = password.Text;
            string confirm = Confirmpass.Text;

            if (pass == confirm)
            {
                AddNewAdmin(acc, pass);
                LoadDataIntoDataGridView();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int accountid = Convert.ToInt32(Adminid.Text);
            string acc = username.Text;
            string pass = password.Text;
            string confirm = Confirmpass.Text;

            if (pass == confirm)
            {
                UpdateAdmin(accountid, acc, pass);
                LoadDataIntoDataGridView();
            }
        }
    }
}
