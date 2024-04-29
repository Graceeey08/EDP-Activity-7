using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext; //EPP packages to manipulate the excel file
using OfficeOpenXml.Drawing.Chart;// for charts and graphs
using OfficeOpenXml.Style; // changes fonts, style, etc


namespace Blissfull_Convenience
{
    public partial class Products : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private string server;
        private string database;
        private string uid;
        private string pass;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public Products()
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

                string query = "SELECT * FROM products";
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
        private void AddNewProduct(string product1, string price, string quantity)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO products (productname, price, Quantity) VALUES (@productss, @price, @quantity)";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@productss", product1);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add product!");
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
        private void UpdateProduct(int productid, string product1, string price, string quantity)
        {
            try
            {
                connection.Open();
                // Update the product record in the database
                string query = "UPDATE products SET productname = @productss, price = @price, Quantity = @quantity WHERE product_id = @productid";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@productss", product1);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@productid", productid);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product information updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update product information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating product information: " + ex.Message);
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
                int productid = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
                string product = Convert.ToString(selectedRow.Cells["productname"].Value);
                string price = Convert.ToString(selectedRow.Cells["price"].Value);
                string quantity = Convert.ToString(selectedRow.Cells["Quantity"].Value);

                // Populate text boxes and controls with the selected row data
                ProductID.Text = productid.ToString();
                Productname.Text = product;
                Price.Text = price;
                QuantityText.Text = quantity;
            }
        }
        //higlight for products search
        private void SearchProduct(string searchTerm)
        {
            try
            {
                connection.Open();

                // Check this query for the correct table name and column name
                string query = "SELECT * FROM products WHERE productname LIKE @searchTerm";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

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
            this.Hide();
            var adm = new Admin();
            adm.Show();
        }

        private void ProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Productname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuantityText_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Addnewbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Productname.Text) || string.IsNullOrWhiteSpace(Price.Text) || string.IsNullOrWhiteSpace(QuantityText.Text))
            {
                MessageBox.Show("Please fill in all fields before adding a new product.");
                return;
            }

            // Extract values from textboxes
            string product1 = Productname.Text;
            string price = Price.Text;
            string quantity = QuantityText.Text;

            // Add new product to the database
            AddNewProduct(product1, price, quantity);
            LoadDataIntoDataGridView();
        }
        private void updatebtn_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(ProductID.Text);
            string product1 = Productname.Text;
            string price = Price.Text;
            string quantity = QuantityText.Text;

            UpdateProduct(productid, product1, price, quantity);
            LoadDataIntoDataGridView();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text;
            SearchProduct(searchTerm);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printbtn_Click(object sender, EventArgs e)//New Added Function and Button
        {
            string filePath = @"F:\VisualStudio2022 Repository\Blissfull Convenience\BlissfulInventoryReport.xlsx"; // file path to be saved
            try
            {
                connection.Open();

                string productQuery = "SELECT product_id, productname, price, quantity FROM products;"; // accessing product in database
                string orderQuery = "SELECT YEAR(order_date) AS year, SUM(total_amount) AS total_sales FROM orders GROUP BY YEAR(order_date)"; // accessing order in database

                using (MySqlCommand productCommand = new MySqlCommand(productQuery, connection))// command for product
                {
                    using (MySqlDataReader productReader = productCommand.ExecuteReader())//reader for product
                    {
                        // Create a new Excel package
                        //editt
                        ExcelPackage excelPackage = new ExcelPackage(); //using the excel package

                        // Add a worksheet to the Excel package
                        ExcelWorksheet worksheet_1 = excelPackage.Workbook.Worksheets.Add("Inventory"); //creating first sheet
                        ExcelWorksheet worksheet_2 = excelPackage.Workbook.Worksheets.Add("Graphs"); // second sheet

                        //for logo 
                        var picture = worksheet_1.Drawings.AddPicture("Logo", new FileInfo("F:\\Downloads\\download-removebg-preview.ico"));//logo of the shop
                        // Set the size of the picture
                        picture.SetSize(70, 70); // Set the picture size in pixels

                        // Set the width of column 1 and height of row 1
                        worksheet_1.Column(1).Width = 13.71;
                        worksheet_1.Row(1).Height = 52.50;
                        worksheet_1.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_1.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightPink);

                        // Calculate the offsets to center the picture in cell A1
                        double cellWidth = worksheet_1.Column(1).Width;
                        double cellHeight = worksheet_1.Row(1).Height;
                        double xOffset = cellWidth / 13.71; // Calculate horizontal offset
                        double yOffset = cellHeight / 4; // Calculate vertical offset

                        // Set the position of the picture to center it in cell A1
                        picture.SetPosition(0, (int)xOffset, 0, (int)yOffset);

                        //Merging and adding the company name
                        ExcelRange cellsToMerge = worksheet_1.Cells["B1:F1"];
                        cellsToMerge.Merge = true;
                        cellsToMerge.Value = "Blissful Convenience";
                        cellsToMerge.Style.Font.Size = 20;
                        cellsToMerge.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cellsToMerge.Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                        cellsToMerge.Style.Font.Name = "Britannic Bold";
                        cellsToMerge.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#4472C4"));
                        cellsToMerge.Style.Font.Bold = true;
                        cellsToMerge.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cellsToMerge.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ExcelRange cellsToMerge1 = worksheet_1.Cells["B4:E4"];
                        cellsToMerge1.Merge = true;
                        cellsToMerge1.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cellsToMerge1.Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                        cellsToMerge1.Style.Font.Name = "Britannic Bold";
                        cellsToMerge1.Style.Font.Color.SetColor(Color.Black);
                        cellsToMerge1.Value = "Product Inventory";
                        cellsToMerge1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cellsToMerge1.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        // Set column headers
                        worksheet_1.Cells["B5"].Value = "Product ID";
                        worksheet_1.Cells["C5"].Value = "Product Name";
                        worksheet_1.Cells["D5"].Value = "Price";
                        worksheet_1.Cells["E5"].Value = "Quantity";

                        int row = 6;

                        // Read data from the reader and write it to the Excel sheet
                        while (productReader.Read())
                        {
                            worksheet_1.Cells[row, 2].Value = productReader.GetString(0); // Assuming
                            worksheet_1.Cells[row, 3].Value = productReader.GetString(1); // Assuming productname is a string
                            worksheet_1.Cells[row, 4].Value = productReader.GetDecimal(2); // Assuming price is a decimal
                            worksheet_1.Cells[row, 5].Value = productReader.GetString(3); // Assuming quantity is a string

                            row++;
                        }
                        worksheet_1.Cells[22, 4].Value = "_________________________";
                        worksheet_1.Cells[23, 4].Value = "Owner";

                        worksheet_1.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet_1.Cells.AutoFitColumns();


                        //For worksheet 2 (Graphs) similar with the first

                        var picture1 = worksheet_2.Drawings.AddPicture("Logo", new FileInfo("F:\\Downloads\\download-removebg-preview.ico"));
                        // Set the size of the picture
                        picture1.SetSize(70, 70); // Set the picture size in pixels

                        // Set the width of column 1 and height of row 1
                        worksheet_2.Column(1).Width = 13.71;
                        worksheet_2.Row(1).Height = 52.50;
                        worksheet_2.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet_2.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightPink);

                        // Calculate the offsets to center the picture in cell A1
                        double cellWidths = worksheet_1.Column(1).Width;
                        double cellHeights = worksheet_1.Row(1).Height;
                        double xOffsets = cellWidths / 13.71; // Calculate horizontal offset
                        double yOffsets = cellHeights / 4; // Calculate vertical offset

                        // Set the position of the picture to center it in cell A1
                        picture.SetPosition(0, (int)xOffsets, 0, (int)yOffsets);

                        ExcelRange cellsToMerge3 = worksheet_2.Cells["B1:H1"];
                        cellsToMerge3.Merge = true;
                        cellsToMerge3.Value = "Blissful Convenience";
                        cellsToMerge3.Style.Font.Size = 20;
                        cellsToMerge3.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cellsToMerge3.Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                        cellsToMerge3.Style.Font.Name = "Britannic Bold";
                        cellsToMerge3.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#4472C4"));
                        cellsToMerge3.Style.Font.Bold = true;
                        cellsToMerge3.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cellsToMerge3.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        // Set column headers
                        worksheet_2.Cells.AutoFitColumns();

                        productReader.Close();

                        // Add a new chart worksheet

                        using (MySqlCommand orderCommand = new MySqlCommand(orderQuery, connection))//command for order
                        {
                            using (MySqlDataReader orderReader = orderCommand.ExecuteReader())//for reader
                            {
                                Dictionary<int, decimal> salesByYear = new Dictionary<int, decimal>();

                                while (orderReader.Read())
                                {
                                    int year = orderReader.GetInt32(0);
                                    decimal totalSales = orderReader.GetDecimal(1);
                                    salesByYear.Add(year, totalSales);
                                }

                                // Populate the chart data in the chart worksheet
                                int chartRow = 3;
                                foreach (var kvp in salesByYear)
                                {
                                    worksheet_2.Cells[chartRow, 2].Value = kvp.Key; // Year
                                    worksheet_2.Cells[chartRow, 3].Value = kvp.Value; // Total Sales
                                    chartRow++;
                                }

                                // Add a chart to the chart worksheet
                                var chart = worksheet_2.Drawings.AddChart("Chart Name", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                                chart.SetPosition(2, 0, 1, 0);
                                chart.SetSize(385, 300);

                                // Specify the data range for the chart
                                var series = chart.Series.Add(worksheet_2.Cells["C3:C" + chartRow], worksheet_2.Cells["B3:B" + chartRow]);

                                // Set the title of the chart
                                chart.Title.Text = "Total Sales by Year Report";

                                // Set axis titles
                                chart.XAxis.Title.Text = "Year";
                                chart.YAxis.Title.Text = "Total Sales";

                                worksheet_2.Cells[20, 5].Value = "____________________________";
                                worksheet_2.Cells[21, 6].Value = "Owner";

                                orderReader.Close();
                            }
                        }

                        // Save the Excel file
                        excelPackage.SaveAs(new FileInfo(filePath));
                        MessageBox.Show("Excel file saved successfully!");

                        // Dispose the ExcelPackage object
                        excelPackage.Dispose();
                    }
                }       
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }
        }
    }
}
