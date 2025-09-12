using System.Drawing;

namespace Store.userinterface
{
    partial class CustomerCartView
    {
        private System.ComponentModel.IContainer components = null;

        // existing
        private System.Windows.Forms.Panel headerBar;
        private System.Windows.Forms.ComboBox cbFilterToggle;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.ComboBox cbBranch;

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

        // new: slide-out cart
        private System.Windows.Forms.Panel cartPanel;
        private System.Windows.Forms.Timer cartTimer;
        private System.Windows.Forms.Panel cartHeader;
        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.Button btnCartOpen;
        private System.Windows.Forms.FlowLayoutPanel cartItemsFlow;
        private System.Windows.Forms.Panel cartFooter;
        private System.Windows.Forms.Label lblCartItems;
        private System.Windows.Forms.Label lblCartSubtotal;
        private System.Windows.Forms.Label lblCartTotal;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnPlaceOrder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.headerBar = new System.Windows.Forms.Panel();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.lblCart = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbBranch = new System.Windows.Forms.ComboBox();

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

            // slide-out cart
            this.cartPanel = new System.Windows.Forms.Panel();
            this.cartTimer = new System.Windows.Forms.Timer(this.components);
            this.cartHeader = new System.Windows.Forms.Panel();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.btnCartOpen = new System.Windows.Forms.Button();
            this.cartItemsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.cartFooter = new System.Windows.Forms.Panel();
            this.lblCartItems = new System.Windows.Forms.Label();
            this.lblCartSubtotal = new System.Windows.Forms.Label();
            this.lblCartTotal = new System.Windows.Forms.Label();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();

            // ==== Form ====
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Name = "CustomerCartView";
            this.Text = "Products";

            // ==== Header Bar ====
            this.headerBar.BackColor = Color.White;
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.Height = 56;
            this.headerBar.Controls.Add(this.cbFilterToggle);
            this.headerBar.Controls.Add(this.btnResetSearch);
            this.headerBar.Controls.Add(this.lblCart);
            this.headerBar.Controls.Add(this.cbCompany);
            this.headerBar.Controls.Add(this.cbBranch);

            // cbFilterToggle
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] { "Hide Filters", "Show Filters" });
            this.cbFilterToggle.Location = new System.Drawing.Point(12, 16);
            this.cbFilterToggle.Size = new System.Drawing.Size(120, 21);
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);

            // btnResetSearch
            this.btnResetSearch.Location = new System.Drawing.Point(140, 15);
            this.btnResetSearch.Size = new System.Drawing.Size(70, 24);
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            // lblCart (left shows count; right-side actual slide panel has totals too)
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCart.ForeColor = Color.Black;
            this.lblCart.Location = new System.Drawing.Point(1080, 18);
            this.lblCart.Text = "Cart: 0";

            // cbCompany
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Location = new System.Drawing.Point(230, 15);
            this.cbCompany.Size = new System.Drawing.Size(200, 22);
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);

            // cbBranch
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Location = new System.Drawing.Point(440, 15);
            this.cbBranch.Size = new System.Drawing.Size(200, 22);
            this.cbBranch.SelectedIndexChanged += new System.EventHandler(this.cbBranch_SelectedIndexChanged);

            // ==== Filter Panel ====
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
            this.txtSearchName.Size = new System.Drawing.Size(140, 22);

            // lblBrand
            this.lblBrand.Location = new System.Drawing.Point(215, 24);
            this.lblBrand.Size = new System.Drawing.Size(44, 20);
            this.lblBrand.Text = "Brand";

            // txtSearchBrand
            this.txtSearchBrand.Location = new System.Drawing.Point(265, 22);
            this.txtSearchBrand.Size = new System.Drawing.Size(140, 22);

            // lblBarcode
            this.lblBarcode.Location = new System.Drawing.Point(415, 24);
            this.lblBarcode.Size = new System.Drawing.Size(56, 20);
            this.lblBarcode.Text = "Barcode";

            // txtSearchBarcode
            this.txtSearchBarcode.Location = new System.Drawing.Point(475, 22);
            this.txtSearchBarcode.Size = new System.Drawing.Size(120, 22);

            // cbCategory
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new System.Drawing.Point(605, 22);
            this.cbCategory.Size = new System.Drawing.Size(120, 22);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(735, 20);
            this.btnSearch.Size = new System.Drawing.Size(80, 26);
            this.btnSearch.Text = "Search";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ==== Products Flow ====
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Padding = new System.Windows.Forms.Padding(20);
            this.flowProducts.WrapContents = true;
            this.flowProducts.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowProducts.AutoScrollMargin = new Size(20, 20);
            this.flowProducts.BackColor = Color.WhiteSmoke;

            // ==== Slide-out Cart Panel ====
            this.cartPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.cartPanel.Width = 0; // collapsed initially
            this.cartPanel.BackColor = Color.White;
            this.cartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // cartHeader
            this.cartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.cartHeader.Height = 48;
            this.cartHeader.BackColor = Color.White;
            this.cartHeader.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);

            this.lblCartTitle.AutoSize = true;
            this.lblCartTitle.Text = "Your Bag";
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCartTitle.Location = new System.Drawing.Point(10, 14);

            this.btnCartOpen.Text = "«";
            this.btnCartOpen.Width = 36;
            this.btnCartOpen.Height = 28;
            this.btnCartOpen.Location = new System.Drawing.Point(300, 10);
            this.btnCartOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.cartHeader.Controls.Add(this.lblCartTitle);
            this.cartHeader.Controls.Add(this.btnCartOpen);

            // cartItemsFlow
            this.cartItemsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartItemsFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cartItemsFlow.WrapContents = false;
            this.cartItemsFlow.AutoScroll = true;
            this.cartItemsFlow.Padding = new System.Windows.Forms.Padding(8);
            this.cartItemsFlow.BackColor = Color.WhiteSmoke;

            // cartFooter
            this.cartFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cartFooter.Height = 120;
            this.cartFooter.BackColor = Color.White;
            this.cartFooter.Padding = new System.Windows.Forms.Padding(12);

            this.lblCartItems.AutoSize = true;
            this.lblCartItems.Text = "Items: 0";
            this.lblCartItems.Location = new System.Drawing.Point(12, 12);

            this.lblCartSubtotal.AutoSize = true;
            this.lblCartSubtotal.Text = "Subtotal: ৳ 0.00";
            this.lblCartSubtotal.Location = new System.Drawing.Point(12, 34);

            this.lblCartTotal.AutoSize = true;
            this.lblCartTotal.Text = "৳ 0.00";
            this.lblCartTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartTotal.Location = new System.Drawing.Point(12, 58);

            this.btnClearCart.Text = "Reset";
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Size = new System.Drawing.Size(80, 28);
            this.btnClearCart.Location = new System.Drawing.Point(12, 84);

            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Size = new System.Drawing.Size(110, 28);
            this.btnPlaceOrder.Location = new System.Drawing.Point(100, 84);

            this.cartFooter.Controls.Add(this.lblCartItems);
            this.cartFooter.Controls.Add(this.lblCartSubtotal);
            this.cartFooter.Controls.Add(this.lblCartTotal);
            this.cartFooter.Controls.Add(this.btnClearCart);
            this.cartFooter.Controls.Add(this.btnPlaceOrder);

            // add sections to cartPanel
            this.cartPanel.Controls.Add(this.cartItemsFlow);
            this.cartPanel.Controls.Add(this.cartFooter);
            this.cartPanel.Controls.Add(this.cartHeader);

            // Add everything to Form
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerBar);
            this.Controls.Add(this.cartPanel);

            // finalize
            this.headerBar.ResumeLayout(false);
            this.headerBar.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
