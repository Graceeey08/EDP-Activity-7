using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Blissfull_Convenience
{
    
    public partial class order : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private string server;
        private string database;
        private string uid;
        private string pass;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public order()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadDataIntoDataGridView();
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

                string query = "SELECT * FROM customers";
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

        }
    }
}
