namespace ResourceManagment
{
    partial class Materials
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
            this.materialID = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.materialName = new System.Windows.Forms.TextBox();
            this.materialQuantity = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.materialDataSet = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.materialQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // materialID
            // 
            this.materialID.AutoSize = true;
            this.materialID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialID.Location = new System.Drawing.Point(24, 11);
            this.materialID.Name = "materialID";
            this.materialID.Size = new System.Drawing.Size(35, 13);
            this.materialID.TabIndex = 15;
            this.materialID.Text = "label1";
            // 
            // deleteButton
            // 
            this.deleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteButton.Location = new System.Drawing.Point(652, 21);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(136, 33);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Delete Material";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.updateButton.Location = new System.Drawing.Point(510, 21);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(136, 33);
            this.updateButton.TabIndex = 13;
            this.updateButton.Text = "Update Material";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // materialName
            // 
            this.materialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.materialName.Location = new System.Drawing.Point(23, 27);
            this.materialName.Name = "materialName";
            this.materialName.Size = new System.Drawing.Size(267, 22);
            this.materialName.TabIndex = 12;
            // 
            // materialQuantity
            // 
            this.materialQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.materialQuantity.Location = new System.Drawing.Point(296, 29);
            this.materialQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.materialQuantity.Name = "materialQuantity";
            this.materialQuantity.Size = new System.Drawing.Size(66, 20);
            this.materialQuantity.TabIndex = 11;
            // 
            // addButton
            // 
            this.addButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addButton.Location = new System.Drawing.Point(368, 21);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 33);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add Material";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // materialDataSet
            // 
            this.materialDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataSet.Location = new System.Drawing.Point(12, 72);
            this.materialDataSet.Name = "materialDataSet";
            this.materialDataSet.Size = new System.Drawing.Size(776, 344);
            this.materialDataSet.TabIndex = 9;
            this.materialDataSet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialDataSet_CellClick);
            // 
            // Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.materialID);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.materialName);
            this.Controls.Add(this.materialQuantity);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.materialDataSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Materials";
            this.Text = "Materials";
            this.Load += new System.EventHandler(this.Materials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label materialID;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox materialName;
        private System.Windows.Forms.NumericUpDown materialQuantity;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView materialDataSet;
        private ResourceSet resourceSet;
        private ResourceSetTableAdapters.MaterialsTableAdapter materialsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockQuantityDataGridViewTextBoxColumn;
    }
}