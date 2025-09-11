namespace Store.userinterface
{
    partial class InventoryManage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.txtSearchBrand = new System.Windows.Forms.TextBox();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.ID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();

            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.cbFilterToggle);
            this.topPanel.Controls.Add(this.btnAddNew);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 50;
            this.topPanel.Name = "topPanel";
            this.topPanel.TabIndex = 0;
            this.topPanel.SizeChanged += new System.EventHandler(this.topPanel_SizeChanged);

            // 
            // btnAddNew
            // 
            this.btnAddNew.Text = "Add Inventory";
            this.btnAddNew.Size = new System.Drawing.Size(120, 30);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);

            // 
            // cbFilterToggle
            // 
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] {
                "Hide Filters",
                "Show Filters"});
            this.cbFilterToggle.SelectedIndex = 0;
            this.cbFilterToggle.Location = new System.Drawing.Point(10, 15);
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);

            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.txtSearchProduct);
            this.filterPanel.Controls.Add(this.txtSearchBrand);
            this.filterPanel.Controls.Add(this.btnDoSearch);
            this.filterPanel.Controls.Add(this.btnResetSearch);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Height = 45;
            this.filterPanel.Visible = false;

            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(10, 10);
            this.txtSearchProduct.Width = 150;
            this.txtSearchProduct.Name = "txtSearchProduct";

            // 
            // txtSearchBrand
            // 
            this.txtSearchBrand.Location = new System.Drawing.Point(170, 10);
            this.txtSearchBrand.Width = 150;
            this.txtSearchBrand.Name = "txtSearchBrand";

            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Text = "Search";
            this.btnDoSearch.Location = new System.Drawing.Point(330, 8);
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);

            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.Location = new System.Drawing.Point(410, 8);
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ID_Column,
                this.Product_Column,
                this.Brand_Column,
                this.Branch_Column,
                this.Qty_Column,
                this.Updated_Column,
                this.View_Col,
                this.Edit_Col,
                this.Delete_Col});
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // 
            // ID_Column
            // 
            this.ID_Column.HeaderText = "ID";
            this.ID_Column.Name = "ID_Column";
            this.ID_Column.Visible = false;

            // 
            // Product_Column
            // 
            this.Product_Column.HeaderText = "Product";
            this.Product_Column.Name = "Product_Column";

            // 
            // Brand_Column
            // 
            this.Brand_Column.HeaderText = "Brand";
            this.Brand_Column.Name = "Brand_Column";

            // 
            // Branch_Column
            // 
            this.Branch_Column.HeaderText = "Branch";
            this.Branch_Column.Name = "Branch_Column";

            // 
            // Qty_Column
            // 
            this.Qty_Column.HeaderText = "Quantity";
            this.Qty_Column.Name = "Qty_Column";

            // 
            // Updated_Column
            // 
            this.Updated_Column.HeaderText = "Updated";
            this.Updated_Column.Name = "Updated_Column";

            // 
            // View_Col
            // 
            this.View_Col.HeaderText = "View";
            this.View_Col.Name = "View_Col";
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;

            // 
            // Edit_Col
            // 
            this.Edit_Col.HeaderText = "Edit";
            this.Edit_Col.Name = "Edit_Col";
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;

            // 
            // Delete_Col
            // 
            this.Delete_Col.HeaderText = "Delete";
            this.Delete_Col.Name = "Delete_Col";
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;

            // 
            // InventoryManage
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "InventoryManage";
            this.Text = "Inventory Management";

            this.topPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ComboBox cbFilterToggle;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.TextBox txtSearchBrand;
        private System.Windows.Forms.Button btnDoSearch;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updated_Column;
        private System.Windows.Forms.DataGridViewButtonColumn View_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Edit_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_Col;
    }
}
