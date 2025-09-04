using System.Drawing;
using System.Windows.Forms;

namespace Store.userinterface
{
    partial class ProductManageView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();

            this.labelHeader = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelImage = new System.Windows.Forms.Label();

            this.IDBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.BrandBox = new System.Windows.Forms.TextBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.BarcodeBox = new System.Windows.Forms.TextBox();
            this.CategoryBox = new System.Windows.Forms.ComboBox();

            this.ProductPicture = new System.Windows.Forms.PictureBox();
            this.UploadImageBtn = new System.Windows.Forms.Button();

            this.SaveProductBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();

            this.labelSearchName = new System.Windows.Forms.Label();
            this.SearchNameBox = new System.Windows.Forms.TextBox();
            this.labelSearchBrand = new System.Windows.Forms.Label();
            this.SearchBrandBox = new System.Windows.Forms.TextBox();
            this.labelSearchBarcode = new System.Windows.Forms.Label();
            this.SearchBarcodeBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchResetBtn = new System.Windows.Forms.Button();

            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPicture)).BeginInit();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.BackColor = Color.FromArgb(230, 230, 230);
            this.panelLeft.Controls.Add(this.flowLayoutPanel1);
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Width = 700;

            // flowLayoutPanel1
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = Color.White;

            // panelRight
            this.panelRight.BackColor = Color.WhiteSmoke;
            this.panelRight.Dock = DockStyle.Fill;

            // header
            this.labelHeader.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.labelHeader.ForeColor = Color.FromArgb(175, 76, 15);
            this.labelHeader.Text = "Product Management";
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new Point(200, 20);

            // Name
            this.labelName.Text = "Name";
            this.labelName.Location = new Point(60, 80);
            this.NameBox.Location = new Point(200, 80);
            this.NameBox.Width = 300;

            // Brand
            this.labelBrand.Text = "Brand";
            this.labelBrand.Location = new Point(60, 120);
            this.BrandBox.Location = new Point(200, 120);
            this.BrandBox.Width = 300;

            // Description
            this.labelDescription.Text = "Description";
            this.labelDescription.Location = new Point(60, 160);
            this.DescriptionBox.Location = new Point(200, 160);
            this.DescriptionBox.Width = 300;
            this.DescriptionBox.Height = 60;
            this.DescriptionBox.Multiline = true;

            // Price
            this.labelPrice.Text = "Price";
            this.labelPrice.Location = new Point(60, 230);
            this.PriceBox.Location = new Point(200, 230);
            this.PriceBox.Width = 300;

            // Barcode
            this.labelBarcode.Text = "Barcode";
            this.labelBarcode.Location = new Point(60, 270);
            this.BarcodeBox.Location = new Point(200, 270);
            this.BarcodeBox.Width = 300;

            // Category
            this.labelCategory.Text = "Category";
            this.labelCategory.Location = new Point(60, 310);
            this.CategoryBox.Location = new Point(200, 310);
            this.CategoryBox.Width = 300;
            this.CategoryBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Image
            this.labelImage.Text = "Image";
            this.labelImage.Location = new Point(60, 350);
            this.ProductPicture.Location = new Point(200, 350);
            this.ProductPicture.Size = new Size(120, 120);
            this.ProductPicture.SizeMode = PictureBoxSizeMode.Zoom;

            this.UploadImageBtn.Text = "Upload Image";
            this.UploadImageBtn.Location = new Point(330, 380);
            this.UploadImageBtn.Click += new System.EventHandler(this.UploadImageBtn_Click);

            // Save
            this.SaveProductBtn.Text = "Save";
            this.SaveProductBtn.BackColor = Color.FromArgb(175, 76, 15);
            this.SaveProductBtn.ForeColor = Color.White;
            this.SaveProductBtn.Location = new Point(200, 490);
            this.SaveProductBtn.Click += new System.EventHandler(this.SaveProductBtn_Click);

            // Reset
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.BackColor = Color.LightGray;
            this.ResetBtn.ForeColor = Color.Black;
            this.ResetBtn.Location = new Point(320, 490);
            this.ResetBtn.Click += (s, e) => ResetForm();

            // Search Name
            this.labelSearchName.Text = "Search Name";
            this.labelSearchName.Location = new Point(60, 560);
            this.SearchNameBox.Location = new Point(200, 560);
            this.SearchNameBox.Width = 300;

            // Search Brand
            this.labelSearchBrand.Text = "Search Brand";
            this.labelSearchBrand.Location = new Point(60, 600);
            this.SearchBrandBox.Location = new Point(200, 600);
            this.SearchBrandBox.Width = 300;

            // Search Barcode
            this.labelSearchBarcode.Text = "Search Barcode";
            this.labelSearchBarcode.Location = new Point(60, 640);
            this.SearchBarcodeBox.Location = new Point(200, 640);
            this.SearchBarcodeBox.Width = 300;

            this.SearchBtn.Text = "Search";
            this.SearchBtn.BackColor = Color.FromArgb(175, 76, 15);
            this.SearchBtn.ForeColor = Color.White;
            this.SearchBtn.Location = new Point(200, 680);

            this.SearchResetBtn.Text = "Reset";
            this.SearchResetBtn.BackColor = Color.Gray;
            this.SearchResetBtn.ForeColor = Color.White;
            this.SearchResetBtn.Location = new Point(320, 680);

            // hidden IDBox
            this.IDBox.Visible = false;

            // add controls to right panel
            this.panelRight.Controls.Add(this.labelHeader);
            this.panelRight.Controls.Add(this.labelName);
            this.panelRight.Controls.Add(this.NameBox);
            this.panelRight.Controls.Add(this.labelBrand);
            this.panelRight.Controls.Add(this.BrandBox);
            this.panelRight.Controls.Add(this.labelDescription);
            this.panelRight.Controls.Add(this.DescriptionBox);
            this.panelRight.Controls.Add(this.labelPrice);
            this.panelRight.Controls.Add(this.PriceBox);
            this.panelRight.Controls.Add(this.labelBarcode);
            this.panelRight.Controls.Add(this.BarcodeBox);
            this.panelRight.Controls.Add(this.labelCategory);
            this.panelRight.Controls.Add(this.CategoryBox);
            this.panelRight.Controls.Add(this.labelImage);
            this.panelRight.Controls.Add(this.ProductPicture);
            this.panelRight.Controls.Add(this.UploadImageBtn);
            this.panelRight.Controls.Add(this.SaveProductBtn);
            this.panelRight.Controls.Add(this.ResetBtn);
            this.panelRight.Controls.Add(this.labelSearchName);
            this.panelRight.Controls.Add(this.SearchNameBox);
            this.panelRight.Controls.Add(this.labelSearchBrand);
            this.panelRight.Controls.Add(this.SearchBrandBox);
            this.panelRight.Controls.Add(this.labelSearchBarcode);
            this.panelRight.Controls.Add(this.SearchBarcodeBox);
            this.panelRight.Controls.Add(this.SearchBtn);
            this.panelRight.Controls.Add(this.SearchResetBtn);

            // form
            this.ClientSize = new System.Drawing.Size(1350, 800);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Text = "ProductManage";

            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPicture)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private Panel panelLeft;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelRight;

        private Label labelHeader, labelName, labelBrand, labelDescription, labelPrice, labelBarcode, labelCategory, labelImage;
        private TextBox IDBox, NameBox, BrandBox, DescriptionBox, PriceBox, BarcodeBox;
        private ComboBox CategoryBox;
        private PictureBox ProductPicture;
        private Button UploadImageBtn, SaveProductBtn, ResetBtn;

        private Label labelSearchName, labelSearchBrand, labelSearchBarcode;
        private TextBox SearchNameBox, SearchBrandBox, SearchBarcodeBox;
        private Button SearchBtn, SearchResetBtn;
    }
}
