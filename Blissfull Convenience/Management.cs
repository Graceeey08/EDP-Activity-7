using MySql.Data.MySqlClient; // Using Mysql Library to connect the Visual studio to mysql work bench
using System;
using System.Data;
using System.Windows.Forms;

namespace Blissfull_Convenience
{
    public partial class Management : Form
    {
        // Declare private fields for database connection and command
        private MySqlConnection connection; 
        private MySqlCommand command;

        // Database connection parameters
        private string server;
        private string database;
        private string uid;
        private string pass;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public Management()
        {
            InitializeComponent();
            InitializeDatabase(); // Initialize database connection
            LoadDataIntoDataGridView();  // Load data into DataGridView 
            dataGridView1.CellClick += dataGridView1_CellClick;// Attach event handler for cell click so that when updating an item/employee no need to type, it auto fill the textBox when clicked
        }
        // Method to initialize database connection
        private void InitializeDatabase()
        {
            server = "localhost";
            database = "blissful_convenience";
            uid = "root";
            pass = "erick";
            // Construct connection string
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            connection = new MySqlConnection(connectionString); // Create MySqlConnection object named "connection"
        }

        // Method to load data into DataGridView
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM customers"; // SQL query to show records from 'customer' table
                command = new MySqlCommand(query, connection);

                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable; // Set DataGridView's data source to the filled DataTable
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
        // Method to add a new customer to the database
        private void AddNewCustomer(string customer, string email, string phone, string address)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO customers (customer_name, email, phone_number, address) VALUES (@customer, @email, @phone, @address)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customer", customer);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add customer!");
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
        // Method to update customer information in the database
        private void UpdateCustomer(int customerid, string customer, string email, string phone, string address)
        {
            try
            {
                connection.Open();
                // Update the customer record in the database
                string query = "UPDATE customers SET customer_name = @customer, email = @email, phone_number = @phone, address = @address WHERE customer_id = @customerid";
                command = new MySqlCommand(query, connection); // Create and using MySqlCommand object
                command.Parameters.AddWithValue("@customer", customer);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@customerid", customerid);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer information updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update customer information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating customer information: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // creating an Event handler for cell click in DataGridView if the cell is selected then it will auto fill the
        // textBox to lessen hassle when putting or updating user or item
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Retrieve data from the selected row
                int customerid = Convert.ToInt32(selectedRow.Cells["customer_id"].Value); //it will get the column named customer_id and assign it to variable customerid
                string customer = Convert.ToString(selectedRow.Cells["customer_name"].Value);//similar logic 
                string email = Convert.ToString(selectedRow.Cells["email"].Value);//Here
                string phone = Convert.ToString(selectedRow.Cells["phone_number"].Value);//here
                string address = Convert.ToString(selectedRow.Cells["address"].Value);//and here

                // Populate text boxes and controls with the selected row data
                CustomerID.Text = customerid.ToString(); //assigning the textBox CustomerID to customerid
                Customername.Text = customer; //Similar logic to that 
                Email.Text = email;//here 
                Phonenum.Text = phone;//here
                Address.Text = address;//and here
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
            string customer = Customername.Text;
            string email = Email.Text;
            string phone = Phonenum.Text;
            string address = Address.Text;

            AddNewCustomer(customer, email, phone, address);
            LoadDataIntoDataGridView();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int customerid = Convert.ToInt32(CustomerID.Text);
            string customer = Customername.Text;
            string email = Email.Text;
            string phone = Phonenum.Text;
            string address = Address.Text;

            UpdateCustomer(customerid, customer, email, phone, address);
            LoadDataIntoDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            var back = new Form1();
            back.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Phonenum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
