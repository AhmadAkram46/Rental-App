namespace RentalSystemApp
{
    partial class Form1
    {
        // Designer fields (one per control)
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblNewItem;
        private System.Windows.Forms.TextBox txtNewItemName;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnRentItem;
        private System.Windows.Forms.Button btnReturnItem;

        private void InitializeComponent()
        {
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblNewItem = new System.Windows.Forms.Label();
            this.txtNewItemName = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnRentItem = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridItems.Location = new System.Drawing.Point(0, 0);
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItems.Size = new System.Drawing.Size(800, 250);
            this.gridItems.TabIndex = 0;
            // 
            // lblNewItem
            // 
            this.lblNewItem.AutoSize = true;
            this.lblNewItem.Location = new System.Drawing.Point(12, 270);
            this.lblNewItem.Name = "lblNewItem";
            this.lblNewItem.Size = new System.Drawing.Size(70, 13);
            this.lblNewItem.TabIndex = 1;
            this.lblNewItem.Text = "New Item:";
            // 
            // txtNewItemName
            // 
            this.txtNewItemName.Location = new System.Drawing.Point(90, 267);
            this.txtNewItemName.Name = "txtNewItemName";
            this.txtNewItemName.Size = new System.Drawing.Size(200, 20);
            this.txtNewItemName.TabIndex = 2;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(310, 265);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(12, 300);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(85, 13);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(103, 297);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerName.TabIndex = 5;
            // 
            // btnRentItem
            // 
            this.btnRentItem.Location = new System.Drawing.Point(320, 295);
            this.btnRentItem.Name = "btnRentItem";
            this.btnRentItem.Size = new System.Drawing.Size(75, 23);
            this.btnRentItem.TabIndex = 6;
            this.btnRentItem.Text = "Rent Item";
            this.btnRentItem.UseVisualStyleBackColor = true;
            this.btnRentItem.Click += new System.EventHandler(this.btnRentItem_Click);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.Location = new System.Drawing.Point(410, 295);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.Size = new System.Drawing.Size(75, 23);
            this.btnReturnItem.TabIndex = 7;
            this.btnReturnItem.Text = "Return Item";
            this.btnReturnItem.UseVisualStyleBackColor = true;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnReturnItem);
            this.Controls.Add(this.btnRentItem);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtNewItemName);
            this.Controls.Add(this.lblNewItem);
            this.Controls.Add(this.gridItems);
            this.Name = "Form1";
            this.Text = "Rental System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
