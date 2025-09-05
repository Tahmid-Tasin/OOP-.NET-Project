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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.labelBrand = new System.Windows.Forms.Label();
            this.BrandBox = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.BarcodeBox = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.labelImage = new System.Windows.Forms.Label();
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
            this.IDBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelLeft.Controls.Add(this.flowLayoutPanel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(700, 800);
            this.panelLeft.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 800);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRight.Controls.Add(this.button4);
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
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(700, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(650, 800);
            this.panelRight.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.labelHeader.Location = new System.Drawing.Point(200, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(316, 36);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Product Management";
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(60, 80);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 23);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(200, 80);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(300, 22);
            this.NameBox.TabIndex = 2;
            // 
            // labelBrand
            // 
            this.labelBrand.Location = new System.Drawing.Point(60, 120);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(100, 23);
            this.labelBrand.TabIndex = 3;
            this.labelBrand.Text = "Brand";
            // 
            // BrandBox
            // 
            this.BrandBox.Location = new System.Drawing.Point(200, 120);
            this.BrandBox.Name = "BrandBox";
            this.BrandBox.Size = new System.Drawing.Size(300, 22);
            this.BrandBox.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(60, 160);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(100, 23);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(200, 160);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(300, 60);
            this.DescriptionBox.TabIndex = 6;
            // 
            // labelPrice
            // 
            this.labelPrice.Location = new System.Drawing.Point(60, 230);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(100, 23);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Price";
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(200, 230);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(300, 22);
            this.PriceBox.TabIndex = 8;
            // 
            // labelBarcode
            // 
            this.labelBarcode.Location = new System.Drawing.Point(60, 270);
            this.labelBarcode.Name = "labelBarcode";
            this.labelBarcode.Size = new System.Drawing.Size(100, 23);
            this.labelBarcode.TabIndex = 9;
            this.labelBarcode.Text = "Barcode";
            // 
            // BarcodeBox
            // 
            this.BarcodeBox.Location = new System.Drawing.Point(200, 270);
            this.BarcodeBox.Name = "BarcodeBox";
            this.BarcodeBox.Size = new System.Drawing.Size(300, 22);
            this.BarcodeBox.TabIndex = 10;
            // 
            // labelCategory
            // 
            this.labelCategory.Location = new System.Drawing.Point(60, 310);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(100, 23);
            this.labelCategory.TabIndex = 11;
            this.labelCategory.Text = "Category";
            // 
            // CategoryBox
            // 
            this.CategoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryBox.Location = new System.Drawing.Point(200, 310);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(300, 24);
            this.CategoryBox.TabIndex = 12;
            // 
            // labelImage
            // 
            this.labelImage.Location = new System.Drawing.Point(60, 350);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(100, 23);
            this.labelImage.TabIndex = 13;
            this.labelImage.Text = "Image";
            // 
            // ProductPicture
            // 
            this.ProductPicture.Location = new System.Drawing.Point(200, 350);
            this.ProductPicture.Name = "ProductPicture";
            this.ProductPicture.Size = new System.Drawing.Size(120, 120);
            this.ProductPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductPicture.TabIndex = 14;
            this.ProductPicture.TabStop = false;
            // 
            // UploadImageBtn
            // 
            this.UploadImageBtn.Location = new System.Drawing.Point(330, 380);
            this.UploadImageBtn.Name = "UploadImageBtn";
            this.UploadImageBtn.Size = new System.Drawing.Size(75, 23);
            this.UploadImageBtn.TabIndex = 15;
            this.UploadImageBtn.Text = "Upload Image";
            this.UploadImageBtn.Click += new System.EventHandler(this.UploadImageBtn_Click);
            // 
            // SaveProductBtn
            // 
            this.SaveProductBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.SaveProductBtn.ForeColor = System.Drawing.Color.White;
            this.SaveProductBtn.Location = new System.Drawing.Point(200, 490);
            this.SaveProductBtn.Name = "SaveProductBtn";
            this.SaveProductBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveProductBtn.TabIndex = 16;
            this.SaveProductBtn.Text = "Save";
            this.SaveProductBtn.UseVisualStyleBackColor = false;
            this.SaveProductBtn.Click += new System.EventHandler(this.SaveProductBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.Color.LightGray;
            this.ResetBtn.ForeColor = System.Drawing.Color.Black;
            this.ResetBtn.Location = new System.Drawing.Point(320, 490);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 17;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // labelSearchName
            // 
            this.labelSearchName.Location = new System.Drawing.Point(60, 560);
            this.labelSearchName.Name = "labelSearchName";
            this.labelSearchName.Size = new System.Drawing.Size(100, 23);
            this.labelSearchName.TabIndex = 18;
            this.labelSearchName.Text = "Search Name";
            // 
            // SearchNameBox
            // 
            this.SearchNameBox.Location = new System.Drawing.Point(200, 560);
            this.SearchNameBox.Name = "SearchNameBox";
            this.SearchNameBox.Size = new System.Drawing.Size(300, 22);
            this.SearchNameBox.TabIndex = 19;
            // 
            // labelSearchBrand
            // 
            this.labelSearchBrand.Location = new System.Drawing.Point(60, 600);
            this.labelSearchBrand.Name = "labelSearchBrand";
            this.labelSearchBrand.Size = new System.Drawing.Size(100, 23);
            this.labelSearchBrand.TabIndex = 20;
            this.labelSearchBrand.Text = "Search Brand";
            // 
            // SearchBrandBox
            // 
            this.SearchBrandBox.Location = new System.Drawing.Point(200, 600);
            this.SearchBrandBox.Name = "SearchBrandBox";
            this.SearchBrandBox.Size = new System.Drawing.Size(300, 22);
            this.SearchBrandBox.TabIndex = 21;
            // 
            // labelSearchBarcode
            // 
            this.labelSearchBarcode.Location = new System.Drawing.Point(60, 640);
            this.labelSearchBarcode.Name = "labelSearchBarcode";
            this.labelSearchBarcode.Size = new System.Drawing.Size(100, 23);
            this.labelSearchBarcode.TabIndex = 22;
            this.labelSearchBarcode.Text = "Search Barcode";
            // 
            // SearchBarcodeBox
            // 
            this.SearchBarcodeBox.Location = new System.Drawing.Point(200, 640);
            this.SearchBarcodeBox.Name = "SearchBarcodeBox";
            this.SearchBarcodeBox.Size = new System.Drawing.Size(300, 22);
            this.SearchBarcodeBox.TabIndex = 23;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.SearchBtn.ForeColor = System.Drawing.Color.White;
            this.SearchBtn.Location = new System.Drawing.Point(200, 680);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 24;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchResetBtn
            // 
            this.SearchResetBtn.BackColor = System.Drawing.Color.Gray;
            this.SearchResetBtn.ForeColor = System.Drawing.Color.White;
            this.SearchResetBtn.Location = new System.Drawing.Point(320, 680);
            this.SearchResetBtn.Name = "SearchResetBtn";
            this.SearchResetBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchResetBtn.TabIndex = 25;
            this.SearchResetBtn.Text = "Reset";
            this.SearchResetBtn.UseVisualStyleBackColor = false;
            this.SearchResetBtn.Click += new System.EventHandler(this.SearchResetBtn_Click);
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(0, 0);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(100, 22);
            this.IDBox.TabIndex = 0;
            this.IDBox.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button4.Location = new System.Drawing.Point(390, 739);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(238, 48);
            this.button4.TabIndex = 26;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.backToHomePage);
            // 
            // ProductManageView
            // 
            this.ClientSize = new System.Drawing.Size(1350, 800);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "ProductManageView";
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
        private Button button4;
    }
}
