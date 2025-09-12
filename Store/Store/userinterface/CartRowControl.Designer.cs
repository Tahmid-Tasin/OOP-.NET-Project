// STEP 02 — CartRowControl.Designer.cs

using System.Drawing;

namespace Store.userinterface
{
    partial class CartRowControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel rowPanel;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRemove;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rowPanel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();

            this.rowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();

            // rowPanel
            this.rowPanel.BackColor = Color.White;
            this.rowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowPanel.Padding = new System.Windows.Forms.Padding(8);
            this.rowPanel.Controls.Add(this.btnRemove);
            this.rowPanel.Controls.Add(this.lblTotal);
            this.rowPanel.Controls.Add(this.lblQty);
            this.rowPanel.Controls.Add(this.lblUnit);
            this.rowPanel.Controls.Add(this.lblSub);
            this.rowPanel.Controls.Add(this.lblTitle);
            this.rowPanel.Controls.Add(this.pic);

            // pic
            this.pic.Location = new System.Drawing.Point(8, 8);
            this.pic.Size = new System.Drawing.Size(52, 52);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(68, 8);
            this.lblTitle.Size = new System.Drawing.Size(210, 20);
            this.lblTitle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.lblTitle.Text = "Product name";

            // lblSub
            this.lblSub.AutoSize = false;
            this.lblSub.Location = new System.Drawing.Point(68, 28);
            this.lblSub.Size = new System.Drawing.Size(210, 18);
            this.lblSub.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
            this.lblSub.ForeColor = Color.DimGray;
            this.lblSub.Text = "Company • Branch";

            // lblUnit
            this.lblUnit.AutoSize = false;
            this.lblUnit.Location = new System.Drawing.Point(68, 48);
            this.lblUnit.Size = new System.Drawing.Size(80, 18);
            this.lblUnit.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            this.lblUnit.ForeColor = Color.Black;
            this.lblUnit.Text = "৳ 0.00";

            // lblQty
            this.lblQty.AutoSize = false;
            this.lblQty.Location = new System.Drawing.Point(150, 48);
            this.lblQty.Size = new System.Drawing.Size(50, 18);
            this.lblQty.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            this.lblQty.ForeColor = Color.Black;
            this.lblQty.Text = "x 0";

            // lblTotal
            this.lblTotal.AutoSize = false;
            this.lblTotal.Location = new System.Drawing.Point(210, 46);
            this.lblTotal.Size = new System.Drawing.Size(100, 20);
            this.lblTotal.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.Black;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Text = "৳ 0.00";
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // btnRemove
            this.btnRemove.Text = "✕";
            this.btnRemove.Size = new System.Drawing.Size(28, 28);
            this.btnRemove.Location = new System.Drawing.Point(320, 8);
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // CartRowControl
            this.Controls.Add(this.rowPanel);
            this.Size = new System.Drawing.Size(360, 72); // height per row
            this.Margin = new System.Windows.Forms.Padding(6);

            this.rowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
