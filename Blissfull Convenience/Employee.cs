using MySql.Data.MySqlClient;// Using Mysql Library to connect the Visual studio to mysql work bench
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Blissfull_Convenience
{
    public partial class Employee : Form
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

        public Employee()
        {
            InitializeComponent();
            InitializeDatabase(); // Initialize database connection
            LoadDataIntoDataGridView(); // Load data into DataGridView 
            dataGridView1.CellClick += dataGridView1_CellClick;// Attach event handler for cell click so that when updating an item/employee no need to type, it auto fill the textBox when clicked
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;//paint the in active and inactive row
        }
        // Method to initialize database connection
        private void InitializeDatabase()
        {
            server = "localhost";
            database = "blissful_convenience";
            uid = "root";
            // Construct connection string
            pass = "erick";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            connection = new MySqlConnection(connectionString); // Create MySqlConnection object named "connection"
        }
        // Method to load data into DataGridView
        private void LoadDataIntoDataGridView()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM employees";
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
        private void AddNewEmployee(string employee, string post, DateTime hireDate, string stat)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO employees (employee_name, position, hire_date, status) VALUES (@employee, @post, @hireDate, @stat)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employee", employee);
                command.Parameters.AddWithValue("@post", post);
                command.Parameters.AddWithValue("@hireDate", hireDate);
                command.Parameters.AddWithValue("@stat", stat);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add employee!");
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

        private void UpdateEmployee(int employeerid, string employee, string post, DateTime hireDate, string stat)
        {
            try
            {
                connection.Open();
                // Update the student record in the database
                string query = "UPDATE employees SET employee_name = @employee, position = @post, hire_date = @hireDate, status = @stat  WHERE employee_id = @employeerid";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employee", employee);
                command.Parameters.AddWithValue("@post", post);
                command.Parameters.AddWithValue("@hireDate", hireDate);
                command.Parameters.AddWithValue("@stat", stat);
                command.Parameters.AddWithValue("@employeerid", employeerid);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee information updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update employee information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating employee information: " + ex.Message);
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
                int employeeid = Convert.ToInt32(selectedRow.Cells["employee_id"].Value);
                string employee = Convert.ToString(selectedRow.Cells["employee_name"].Value);
                string post = Convert.ToString(selectedRow.Cells["position"].Value);
                string hireDate = Convert.ToString(selectedRow.Cells["hire_date"].Value);
                string stat = Convert.ToString(selectedRow.Cells["status"].Value);

                // Populate text boxes and controls with the selected row data
                EmployeeID.Text = employeeid.ToString();
                Employeename.Text = employee;
                position.Text = post;
                dateTimePicker1.Text = hireDate;

                if (stat == "Active")
                {
                    status.SelectedItem = "Active";
                }
                else if (stat == "Inactive")
                {
                    status.SelectedItem = "Inactive";
                }
            }
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Check if the row index is valid
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Get the teaching status value from the cell in the Teachingstatus column
                string stat = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["status"].Value);

                // Set the background color based on the teaching status value
                if (stat == "Active")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (stat == "Inactive")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }
                // Add additional conditions for other teaching status values if needed
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
            LoadDataIntoDataGridView();
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

        }

        private void adminbtn_Click(object sender, EventArgs e)
        {

        }

        private void Addnewbtn_Click(object sender, EventArgs e)
        {
            string employee = Employeename.Text;
            string post = position.Text;
            DateTime hireDate = dateTimePicker1.Value;
            string stat = status.SelectedItem.ToString();

            AddNewEmployee(employee, post, hireDate, stat);
            LoadDataIntoDataGridView();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int employeeid = Convert.ToInt32(EmployeeID.Text);
            string employee = Employeename.Text;
            string post = position.Text;
            DateTime hireDate = dateTimePicker1.Value;

            string stat = status.SelectedItem.ToString();

            UpdateEmployee(employeeid, employee, post, hireDate, stat);
            LoadDataIntoDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Employeename_TextChanged(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
                
        }
    }
}
