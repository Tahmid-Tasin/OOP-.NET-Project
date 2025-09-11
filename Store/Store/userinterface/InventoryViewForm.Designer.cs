namespace Store.userinterface
{
    partial class InventoryViewForm
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
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();

            this.valProduct = new System.Windows.Forms.Label();
            this.valBrand = new System.Windows.Forms.Label();
            this.valBranch = new System.Windows.Forms.Label();
            this.valQuantity = new System.Windows.Forms.Label();
            this.valUpdated = new System.Windows.Forms.Label();

            this.btnClose = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(30, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(55, 15);
            this.lblProduct.Text = "Product:";
            // 
            // valProduct
            // 
            this.valProduct.AutoSize = true;
            this.valProduct.Location = new System.Drawing.Point(120, 30);
            this.valProduct.Name = "valProduct";
            this.valProduct.Size = new System.Drawing.Size(12, 15);
            this.valProduct.Text = "-";

            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(30, 65);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(42, 15);
            this.lblBrand.Text = "Brand:";
            // 
            // valBrand
            // 
            this.valBrand.AutoSize = true;
            this.valBrand.Location = new System.Drawing.Point(120, 65);
            this.valBrand.Name = "valBrand";
            this.valBrand.Size = new System.Drawing.Size(12, 15);
            this.valBrand.Text = "-";

            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(30, 100);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(50, 15);
            this.lblBranch.Text = "Branch:";
            // 
            // valBranch
            // 
            this.valBranch.AutoSize = true;
            this.valBranch.Location = new System.Drawing.Point(120, 100);
            this.valBranch.Name = "valBranch";
            this.valBranch.Size = new System.Drawing.Size(12, 15);
            this.valBranch.Text = "-";

            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(30, 135);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(55, 15);
            this.lblQuantity.Text = "Quantity:";
            // 
            // valQuantity
            // 
            this.valQuantity.AutoSize = true;
            this.valQuantity.Location = new System.Drawing.Point(120, 135);
            this.valQuantity.Name = "valQuantity";
            this.valQuantity.Size = new System.Drawing.Size(12, 15);
            this.valQuantity.Text = "-";

            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Location = new System.Drawing.Point(30, 170);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(55, 15);
            this.lblUpdated.Text = "Updated:";
            // 
            // valUpdated
            // 
            this.valUpdated.AutoSize = true;
            this.valUpdated.Location = new System.Drawing.Point(120, 170);
            this.valUpdated.Name = "valUpdated";
            this.valUpdated.Size = new System.Drawing.Size(12, 15);
            this.valUpdated.Text = "-";

            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(150, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // InventoryViewForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.valProduct);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.valBrand);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.valBranch);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.valQuantity);
            this.Controls.Add(this.lblUpdated);
            this.Controls.Add(this.valUpdated);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Details";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUpdated;

        private System.Windows.Forms.Label valProduct;
        private System.Windows.Forms.Label valBrand;
        private System.Windows.Forms.Label valBranch;
        private System.Windows.Forms.Label valQuantity;
        private System.Windows.Forms.Label valUpdated;

        private System.Windows.Forms.Button btnClose;
    }
}
