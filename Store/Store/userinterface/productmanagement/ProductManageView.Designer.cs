using System.Drawing;

namespace Store.userinterface
{
    partial class ProductManageView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.topBar = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtSearchBrand = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();

            this.topBar.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Name = "ProductManageView";
            this.Text = "Products";
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1200, 50);
            this.topBar.TabIndex = 0;
            // 
            // cbFilterToggle
            // 
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] {"Hide Filters", "Show Filters"});
            this.cbFilterToggle.Location = new System.Drawing.Point(12, 13);
            this.cbFilterToggle.Name = "cbFilterToggle";
            this.cbFilterToggle.Size = new System.Drawing.Size(140, 21);
            this.cbFilterToggle.TabIndex = 0;
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Location = new System.Drawing.Point(160, 12);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(90, 25);
            this.btnResetSearch.TabIndex = 1;
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Visible = false;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnAddNew.Location = new System.Drawing.Point(1085, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 25);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 50);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1200, 60);
            this.filterPanel.TabIndex = 1;
            this.filterPanel.Visible = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 20);
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(70, 20);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(170, 20);
            this.txtSearchName.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(260, 20);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(45, 20);
            this.lblBrand.Text = "Brand";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchBrand
            // 
            this.txtSearchBrand.Location = new System.Drawing.Point(310, 20);
            this.txtSearchBrand.Name = "txtSearchBrand";
            this.txtSearchBrand.Size = new System.Drawing.Size(170, 20);
            this.txtSearchBrand.TabIndex = 1;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(500, 20);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(55, 20);
            this.lblBarcode.Text = "Barcode";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchBarcode
            // 
            this.txtSearchBarcode.Location = new System.Drawing.Point(560, 20);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.Size = new System.Drawing.Size(170, 20);
            this.txtSearchBarcode.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(750, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 110);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1200, 610);
            this.flowLayoutPanel1.TabIndex = 2;

            // Add controls to containers
            this.topBar.Controls.Add(this.cbFilterToggle);
            this.topBar.Controls.Add(this.btnResetSearch);
            this.topBar.Controls.Add(this.btnAddNew);

            this.filterPanel.Controls.Add(this.lblName);
            this.filterPanel.Controls.Add(this.txtSearchName);
            this.filterPanel.Controls.Add(this.lblBrand);
            this.filterPanel.Controls.Add(this.txtSearchBrand);
            this.filterPanel.Controls.Add(this.lblBarcode);
            this.filterPanel.Controls.Add(this.txtSearchBarcode);
            this.filterPanel.Controls.Add(this.btnSearch);

            // Add to form
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topBar);

            this.topBar.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.ComboBox cbFilterToggle;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Button btnAddNew;

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtSearchBrand;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
