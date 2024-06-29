using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ResourceManagment.ResourceSet;

namespace ResourceManagment
{
    public partial class Customers : Form
    {

        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resource.accdb;");
        private DataTable customerDataTable = new DataTable();
        public Customers()
        {
            InitializeComponent();
        }
        private void LoadCustomerData()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Customers", connection);
            customerDataTable.Clear();
            adapter.Fill(customerDataTable);
            customerDataGrid.DataSource = customerDataTable;
            connection.Close();
        }


        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomerData();

            customerID.Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> productList = new List<string>();

            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT CustomerName FROM Customers", connection);
            OleDbDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                productList.Add(dr.GetString(0).ToLower());
            }
            dr.Close();
            Debug.WriteLine(productList[0]);
            if (!productList.Contains(customerName.Text.ToLower()))
            {
                OleDbCommand command2 = new OleDbCommand("insert into Customers (CustomerName,CustomerNumber, CustomerAddress) VALUES (@P1, @P2,@p3)", connection);
                command2.Parameters.AddWithValue("@P1", customerName.Text);
                command2.Parameters.AddWithValue("@P2", customerNumber.Text);
                command2.Parameters.AddWithValue("@P3", customerAddress.Text);
                command2.ExecuteNonQuery();
                connection.Close();
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("There is already a customer with this name in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand("update Customers set CustomerName = @P1, CustomerAddress = @P2, CustomerNumber = @P3 WHERE CustomerID = @P4", connection);
                command.Parameters.AddWithValue("@P1", customerName.Text);
                command.Parameters.AddWithValue("@P2", customerAddress.Text);
                command.Parameters.AddWithValue("@P3", customerNumber.Text);
                command.Parameters.AddWithValue("@P4", customerID.Text);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating customer details: " + ex.Message);
            }
            finally
            {
                connection.Close();
                LoadCustomerData();
            }

            
        }

        private void customerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = customerDataGrid.SelectedCells[0].RowIndex;

            customerName.Text = customerDataGrid.Rows[choosen].Cells[1].Value.ToString();
            customerAddress.Text = customerDataGrid.Rows[choosen].Cells[2].Value.ToString();
            customerNumber.Text = customerDataGrid.Rows[choosen].Cells[3].Value.ToString();

            customerID.Text = customerDataGrid.Rows[choosen].Cells[0].Value.ToString();
        }
    }
}
