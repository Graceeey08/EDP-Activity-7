using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace Blissfull_Convenience
{
    public partial class orderitem : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private string server;
        private string database;
        private string uid;
        private string pass;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public orderitem()
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

                string query = "SELECT * FROM order_items";
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
