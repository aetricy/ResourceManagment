using Ghana;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceManagment
{
    

    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Materials form = new Materials();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Products form = new Products();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Customers form = new Customers();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Orders form = new Orders();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }
    }
}
