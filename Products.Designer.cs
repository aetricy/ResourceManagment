namespace Ghana
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productDataSet = new System.Windows.Forms.DataGridView();
            this.productID = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.productName = new System.Windows.Forms.TextBox();
            this.productQuantity = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // productDataSet
            // 
            this.productDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataSet.Location = new System.Drawing.Point(12, 67);
            this.productDataSet.Name = "productDataSet";
            this.productDataSet.Size = new System.Drawing.Size(776, 349);
            this.productDataSet.TabIndex = 22;
            this.productDataSet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataSet_CellClick);
            // 
            // productID
            // 
            this.productID.AutoSize = true;
            this.productID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.productID.Location = new System.Drawing.Point(17, 12);
            this.productID.Name = "productID";
            this.productID.Size = new System.Drawing.Size(35, 13);
            this.productID.TabIndex = 21;
            this.productID.Text = "label1";
            // 
            // deleteButton
            // 
            this.deleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteButton.Location = new System.Drawing.Point(645, 22);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(136, 33);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete Material";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // updateButton
            // 
            this.updateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.updateButton.Location = new System.Drawing.Point(503, 22);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(136, 33);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Update Material";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click_1);
            // 
            // productName
            // 
            this.productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.productName.Location = new System.Drawing.Point(16, 28);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(267, 22);
            this.productName.TabIndex = 18;
            // 
            // productQuantity
            // 
            this.productQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.productQuantity.Location = new System.Drawing.Point(289, 30);
            this.productQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.productQuantity.Name = "productQuantity";
            this.productQuantity.Size = new System.Drawing.Size(66, 20);
            this.productQuantity.TabIndex = 17;
            // 
            // addButton
            // 
            this.addButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addButton.Location = new System.Drawing.Point(361, 22);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 33);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Add Material";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click_1);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.productDataSet);
            this.Controls.Add(this.productID);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.productQuantity);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productDataSet;
        private System.Windows.Forms.Label productID;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.NumericUpDown productQuantity;
        private System.Windows.Forms.Button addButton;
        private ResourceManagment.ResourceSet resourceSet;
        private ResourceManagment.ResourceSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}