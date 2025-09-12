using System.Drawing;

namespace Store.userinterface
{
    partial class CustomerCartView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerBar;
        private System.Windows.Forms.ComboBox cbFilterToggle;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtSearchBrand;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerBar = new System.Windows.Forms.Panel();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.lblCart = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchBrand = new System.Windows.Forms.TextBox();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();

            this.headerBar.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();

            // CustomerCartView
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Name = "CustomerCartView";
            this.Text = "Products";

            // headerBar
            this.headerBar.BackColor = Color.White;
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.Height = 56;
            this.headerBar.Controls.Add(this.cbFilterToggle);
            this.headerBar.Controls.Add(this.btnResetSearch);
            this.headerBar.Controls.Add(this.lblCart);

            // cbFilterToggle
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] { "Hide Filters", "Show Filters" });
            this.cbFilterToggle.Location = new System.Drawing.Point(12, 16);
            this.cbFilterToggle.Size = new System.Drawing.Size(140, 21);
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);

            // btnResetSearch
            this.btnResetSearch.Location = new System.Drawing.Point(160, 15);
            this.btnResetSearch.Size = new System.Drawing.Size(90, 24);
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            // lblCart
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCart.ForeColor = Color.Black;
            this.lblCart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCart.Location = new System.Drawing.Point(1080, 18);
            this.lblCart.Text = "Cart: 0";

            // filterPanel
            this.filterPanel.BackColor = Color.White;
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Height = 68;
            this.filterPanel.Controls.Add(this.lblName);
            this.filterPanel.Controls.Add(this.txtSearchName);
            this.filterPanel.Controls.Add(this.lblBrand);
            this.filterPanel.Controls.Add(this.txtSearchBrand);
            this.filterPanel.Controls.Add(this.lblBarcode);
            this.filterPanel.Controls.Add(this.txtSearchBarcode);
            this.filterPanel.Controls.Add(this.cbCategory);
            this.filterPanel.Controls.Add(this.btnSearch);

            // lblName
            this.lblName.Location = new System.Drawing.Point(16, 24);
            this.lblName.Size = new System.Drawing.Size(46, 20);
            this.lblName.Text = "Name";

            // txtSearchName
            this.txtSearchName.Location = new System.Drawing.Point(65, 22);
            this.txtSearchName.Size = new System.Drawing.Size(160, 22);

            // lblBrand
            this.lblBrand.Location = new System.Drawing.Point(235, 24);
            this.lblBrand.Size = new System.Drawing.Size(44, 20);
            this.lblBrand.Text = "Brand";

            // txtSearchBrand
            this.txtSearchBrand.Location = new System.Drawing.Point(285, 22);
            this.txtSearchBrand.Size = new System.Drawing.Size(160, 22);

            // lblBarcode
            this.lblBarcode.Location = new System.Drawing.Point(455, 24);
            this.lblBarcode.Size = new System.Drawing.Size(56, 20);
            this.lblBarcode.Text = "Barcode";

            // txtSearchBarcode
            this.txtSearchBarcode.Location = new System.Drawing.Point(515, 22);
            this.txtSearchBarcode.Size = new System.Drawing.Size(160, 22);

            // cbCategory
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new System.Drawing.Point(685, 22);
            this.cbCategory.Size = new System.Drawing.Size(160, 22);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(855, 20);
            this.btnSearch.Size = new System.Drawing.Size(96, 26);
            this.btnSearch.Text = "Search";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // flowProducts
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Padding = new System.Windows.Forms.Padding(20);
            this.flowProducts.WrapContents = true;
            this.flowProducts.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowProducts.AutoScrollMargin = new Size(20, 20);
            this.flowProducts.BackColor = Color.WhiteSmoke;

            // add to form
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerBar);

            this.headerBar.ResumeLayout(false);
            this.headerBar.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
