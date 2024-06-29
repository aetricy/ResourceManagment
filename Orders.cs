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

namespace ResourceManagment
{
    public partial class Orders : Form
    {
        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resource.accdb;");



        public Orders()
        {
            InitializeComponent();
        }
        void loadTable()
        {
            orderID.Visible = false;

            string query = @"
        SELECT 
            o.OrderID, 
            c.CustomerName, 
            p.ProductName, 
            o.OrderDate, 
            o.Quantity, 
            o.Completed
        FROM 
            (Orders o
        INNER JOIN 
            Customers c ON o.CustomerID = c.CustomerID)
        INNER JOIN 
            Products p ON o.ProductID = p.ProductID;
    ";

            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            OleDbCommand command2 = new OleDbCommand("SELECT CustomerName from Customers", connection);
            OleDbDataReader dr = command2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            OleDbCommand command3 = new OleDbCommand("SELECT ProductName from Products", connection);
            OleDbDataReader dr2 = command3.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[0]);
            }
            connection.Close();


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string query = @"
INSERT INTO Orders (CustomerID, ProductID, OrderDate, Quantity, Completed)
SELECT c.CustomerID, p.ProductID, @p1, @p2, @p3
FROM Customers c, Products p
WHERE c.CustomerName = @p4
AND p.ProductName = @p5; 
";
            if (comboBox1.Text != "" && comboBox2.Text != "" && numericUpDown1.Value != 0)
            {
                // Show confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to insert this order?", "Confirm Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    connection.Close();
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query, connection);

                    // Add parameters in the correct order
                    command.Parameters.AddWithValue("@p1", dateTimePicker1.Value.ToString());
                    command.Parameters.AddWithValue("@p2", numericUpDown1.Value);
                    command.Parameters.AddWithValue("@p3", false);
                    command.Parameters.AddWithValue("@p4", comboBox1.Text);
                    command.Parameters.AddWithValue("@p5", comboBox2.Text);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order inserted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                    connection.Close();
                    loadTable();
                }
            }
            else
            {
                MessageBox.Show("Name or Product can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            bool isCompleted =false;
            connection.Open();
            OleDbCommand command2 = new OleDbCommand("SELECT Completed from Orders", connection);
            OleDbDataReader dr = command2.ExecuteReader();
            while (dr.Read())
            {
                isCompleted = Convert.ToBoolean(dr[0].ToString());
            }
            dr.Close ();
            connection.Close ();
            if (!isCompleted)
            {
                DialogResult result = MessageBox.Show($"OrderID: {orderID.Text} will be finished are you sure?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("update Orders set Completed=@p1 WHERE OrderID=@p2", connection);
                    command.Parameters.AddWithValue("@P1", true);
                    command.Parameters.AddWithValue("@P2", orderID.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    loadTable();
                }
            }
        }
         
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (orderID.Text != "label4")
            {
                connection.Open();
                DialogResult result = MessageBox.Show($"OrderID: {orderID.Text} will be deleted are you sure?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    OleDbCommand command2 = new OleDbCommand("DELETE FROM Orders WHERE OrderID=@P1", connection);
                    command2.Parameters.AddWithValue("@P1", orderID.Text);
                    command2.ExecuteNonQuery();

                    connection.Close();
                    loadTable();

                }
                connection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;

            comboBox1.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            numericUpDown1.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            orderID.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resourceSet.Orders' table. You can move, or remove it, as needed.
        //    this.ordersTableAdapter.Fill(this.resourceSet.Orders);
            loadTable();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
