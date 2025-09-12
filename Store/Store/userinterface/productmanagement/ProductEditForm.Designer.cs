using System.Drawing;

namespace Store.userinterface
{
    partial class ProductEditForm
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
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();

            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();

            this.lblBrand = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();

            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();

            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();

            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.lblImage = new System.Windows.Forms.Label();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "ProductEditForm";
            this.Text = "Product";
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Product";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(175, 76, 15);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.AutoSize = true;
            // 
            // lblName
            // 
            this.lblName.Text = "Name *";
            this.lblName.Location = new Point(22, 70);
            this.lblName.Size = new Size(80, 20);
            // 
            // txtName
            // 
            this.txtName.Location = new Point(120, 68);
            this.txtName.Size = new Size(260, 22);
            this.txtName.TabIndex = 0;
            // 
            // lblCategory
            // 
            this.lblCategory.Text = "Category *";
            this.lblCategory.Location = new Point(22, 105);
            this.lblCategory.Size = new Size(80, 20);
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new Point(120, 103);
            this.cbCategory.Size = new Size(260, 21);
            this.cbCategory.TabIndex = 1;
            // 
            // lblBrand
            // 
            this.lblBrand.Text = "Brand";
            this.lblBrand.Location = new Point(22, 140);
            this.lblBrand.Size = new Size(80, 20);
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new Point(120, 138);
            this.txtBrand.Size = new Size(260, 22);
            this.txtBrand.TabIndex = 2;
            // 
            // lblPrice
            // 
            this.lblPrice.Text = "Price *";
            this.lblPrice.Location = new Point(22, 175);
            this.lblPrice.Size = new Size(80, 20);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new Point(120, 173);
            this.txtPrice.Size = new Size(260, 22);
            this.txtPrice.TabIndex = 3;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Text = "Barcode";
            this.lblBarcode.Location = new Point(22, 210);
            this.lblBarcode.Size = new Size(80, 20);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new Point(120, 208);
            this.txtBarcode.Size = new Size(260, 22);
            this.txtBarcode.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.Text = "Description";
            this.lblDescription.Location = new Point(22, 245);
            this.lblDescription.Size = new Size(80, 20);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(120, 243);
            this.txtDescription.Size = new Size(260, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.TabIndex = 5;
            // 
            // lblImage
            // 
            this.lblImage.Text = "Image";
            this.lblImage.Location = new Point(420, 70);
            this.lblImage.Size = new Size(80, 20);
            // 
            // picProduct
            // 
            this.picProduct.Location = new Point(420, 95);
            this.picProduct.Size = new Size(300, 240);
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnUpload
            // 
            this.btnUpload.Text = "Upload...";
            this.btnUpload.Location = new Point(420, 345);
            this.btnUpload.Size = new Size(100, 28);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(540, 430);
            this.btnSave.Size = new Size(90, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(640, 430);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbCategory);

            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtBrand);

            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);

            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);

            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);

            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnUpload);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            // Accept/Cancel buttons
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;

            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;

        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;

        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Button btnUpload;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
