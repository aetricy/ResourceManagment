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

namespace ResourceManagment
{
    public partial class Materials : Form
    {
        public OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resource.accdb;");
        private DataTable materialDataTable = new DataTable();

        public Materials()
        {
            InitializeComponent();
            materialID.Visible = false;

        }
        private void LoadMaterialData()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Materials", connection);
            materialDataTable.Clear();
            adapter.Fill(materialDataTable);
            materialDataSet.DataSource = materialDataTable;
            connection.Close();
        }
        private void Materials_Load(object sender, EventArgs e)
        {
            LoadMaterialData();


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> materialList = new List<string>();

            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT MaterialName FROM Materials", connection);
            OleDbDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                materialList.Add(dr.GetString(0).ToLower());
            }
            dr.Close();
            if (!materialList.Contains(materialName.Text.ToLower()))
            {
                OleDbCommand command2 = new OleDbCommand("INSERT INTO Materials (MaterialName, StockQuantity) VALUES (@P1, @P2)", connection);
                command2.Parameters.AddWithValue("@P1", materialName.Text);
                command2.Parameters.AddWithValue("@P2", materialQuantity.Text);
                command2.ExecuteNonQuery();
                connection.Close();
                LoadMaterialData();

            }
            else
            {
                MessageBox.Show("This material already exists in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("update Materials set materialName = @p1,stockQuantity= @p2 WHERE MaterialID=@p3", connection);
            command.Parameters.AddWithValue("@P1", materialName.Text);
            command.Parameters.AddWithValue("@P2", materialQuantity.Text);
            command.Parameters.AddWithValue("@P3", materialID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            LoadMaterialData();

        }

        private void materialDataSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = materialDataSet.SelectedCells[0].RowIndex;

            materialName.Text = materialDataSet.Rows[choosen].Cells[1].Value.ToString();
            materialQuantity.Text = materialDataSet.Rows[choosen].Cells[2].Value.ToString();
            materialID.Text = materialDataSet.Rows[choosen].Cells[0].Value.ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (materialID.Text != "label1")
            {
                string materialName = "";
                connection.Open();

                OleDbCommand command = new OleDbCommand("SELECT MaterialName FROM Materials WHERE MaterialID=@P1", connection);
                command.Parameters.AddWithValue("@P1", materialID.Text);
                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    materialName = dr.GetString(0).ToUpper();
                }

                dr.Close();

                DialogResult result = MessageBox.Show(materialName + " will be deleted. Are you sure?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        OleDbCommand command2 = new OleDbCommand("DELETE FROM Materials WHERE MaterialID=@P1", connection);
                        command2.Parameters.AddWithValue("@P1", materialID.Text);
                        command2.ExecuteNonQuery();

                        

                    }
                    catch (OleDbException ex)
                    {
                        if (ex.ErrorCode == 547) // Foreign key violation error number
                        {
                            MessageBox.Show("This material cannot be deleted because it is referenced by existing records.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw; // re-throw if it's not a foreign key violation
                        }
                    }
                }
                LoadMaterialData();
                connection.Close();
            }


        }
    }
}

