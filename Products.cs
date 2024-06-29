using ResourceManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ResourceManagment.ResourceSet;

namespace Ghana
{
    public partial class Products : Form
    {
        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resource.accdb;");
        private DataTable productDataTable = new DataTable();

        public Products()
        {
            InitializeComponent();
        }
        private void LoadProductData()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Products", connection);
            productDataTable.Clear();
            adapter.Fill(productDataTable);
            productDataSet.DataSource = productDataTable;
            connection.Close();
        }
        private void Products_Load(object sender, EventArgs e)
        {
            LoadProductData();




            productID.Visible = false;
        }


        private void productDataSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = productDataSet.SelectedCells[0].RowIndex;

            productName.Text = productDataSet.Rows[choosen].Cells[1].Value.ToString();
            productQuantity.Text = productDataSet.Rows[choosen].Cells[2].Value.ToString();
            productID.Text = productDataSet.Rows[choosen].Cells[0].Value.ToString();
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            List<string> productList = new List<string>();

            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT ProductName FROM Products", connection);
            OleDbDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                productList.Add(dr.GetString(0).ToLower());
            }
            dr.Close();
            if (!productList.Contains(productName.Text.ToLower()))
            {
                OleDbCommand command2 = new OleDbCommand("INSERT INTO Products (ProductName, Quantity) VALUES (@P1, @P2)", connection);
                command2.Parameters.AddWithValue("@P1", productName.Text);
                command2.Parameters.AddWithValue("@P2", productQuantity.Text);
                command2.ExecuteNonQuery();
                connection.Close();
                LoadProductData();
            }
            else
            {
                MessageBox.Show("This product already exists in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection.Close();
            }
        }

        private void updateButton_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("update Products set ProductName = @p1,Quantity= @p2 WHERE ProductID=@p3", connection);
            command.Parameters.AddWithValue("@P1", productName.Text);
            command.Parameters.AddWithValue("@P2", productQuantity.Text);
            command.Parameters.AddWithValue("@P3", productID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            LoadProductData();
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            if (productID.Text != "label1")
            {
                string productName = "";
                connection.Open();

                OleDbCommand command = new OleDbCommand("SELECT ProductName FROM Products WHERE ProductID=@P1", connection);
                command.Parameters.AddWithValue("@P1", productID.Text);
                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    productName = dr.GetString(0).ToUpper();
                }

                dr.Close();

                DialogResult result = MessageBox.Show(productName + " will be deleted. Are you sure?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        OleDbCommand command2 = new OleDbCommand("DELETE FROM Products WHERE ProductID=@P1", connection);
                        command2.Parameters.AddWithValue("@P1", productID.Text);
                        command2.ExecuteNonQuery();

                    }
                    catch (OleDbException ex)
                    {
                        if (ex.ErrorCode == 547) // Foreign key violation error number
                        {
                            MessageBox.Show("This product cannot be deleted because it is referenced by existing orders.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw; // re-throw if it's not a foreign key violation
                        }
                    }
                }
                else
                {
                    connection.Close();
                }
            }
            LoadProductData();
            connection.Close();

        }
    }
}


