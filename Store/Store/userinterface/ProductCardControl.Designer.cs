namespace Store.userinterface
{
    partial class ProductCardControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel cardBorder;
        private System.Windows.Forms.TableLayoutPanel root;   // whole card
        private System.Windows.Forms.Panel imageWrap;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TableLayoutPanel qtyRow; // − 0 +
        private System.Windows.Forms.Button minusBtn;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.Button plusBtn;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.Label lblInBag;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.cardBorder = new System.Windows.Forms.Panel();
            this.root       = new System.Windows.Forms.TableLayoutPanel();
            this.imageWrap  = new System.Windows.Forms.Panel();
            this.pic        = new System.Windows.Forms.PictureBox();
            this.lblName    = new System.Windows.Forms.Label();
            this.lblWeight  = new System.Windows.Forms.Label();
            this.lblPrice   = new System.Windows.Forms.Label();
            this.qtyRow     = new System.Windows.Forms.TableLayoutPanel();
            this.minusBtn   = new System.Windows.Forms.Button();
            this.qtyLabel   = new System.Windows.Forms.Label();
            this.plusBtn    = new System.Windows.Forms.Button();
            this.bottomBar  = new System.Windows.Forms.Panel();
            this.lblInBag   = new System.Windows.Forms.Label();

            this.cardBorder.SuspendLayout();
            this.root.SuspendLayout();
            this.imageWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.qtyRow.SuspendLayout();
            this.bottomBar.SuspendLayout();
            this.SuspendLayout();

            // ProductCardControl (outer)
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Margin    = new System.Windows.Forms.Padding(12);
            this.MinimumSize = new System.Drawing.Size(220, 320);
            this.Size        = new System.Drawing.Size(240, 340);

            // cardBorder
            this.cardBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardBorder.Padding = new System.Windows.Forms.Padding(8);
            this.cardBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardBorder.BackColor = System.Drawing.Color.White;

            // root (6 rows: image / name / desc / price / qtyRow / bottomBar)
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.RowCount = 6;
            // fixed image height to avoid collapsing
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F)); // image
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));  // name
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));  // desc
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));  // price
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));  // qty
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));  // bottom bar
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardBorder.Controls.Add(this.root);

            // imageWrap
            this.imageWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageWrap.Padding = new System.Windows.Forms.Padding(2);
            this.imageWrap.BackColor = System.Drawing.Color.White;
            this.imageWrap.Controls.Add(this.pic);

            // pic
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.BackColor = System.Drawing.Color.White;

            // lblName
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.AutoEllipsis = true;

            // lblWeight (desc)
            this.lblWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblWeight.ForeColor = System.Drawing.Color.DimGray;
            this.lblWeight.AutoEllipsis = true;

            // lblPrice
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.ForestGreen;

            // qtyRow (− 0 +)
            this.qtyRow.ColumnCount = 3;
            this.qtyRow.RowCount = 1;
            this.qtyRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.qtyRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.qtyRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.qtyRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qtyRow.Dock = System.Windows.Forms.DockStyle.Fill;

            // minusBtn
            this.minusBtn.Text = "−";
            this.minusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.minusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusBtn.Click += new System.EventHandler(this.minusBtn_Click);

            // qtyLabel
            this.qtyLabel.Text = "0";
            this.qtyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.qtyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // plusBtn
            this.plusBtn.Text = "+";
            this.plusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.plusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusBtn.Click += new System.EventHandler(this.plusBtn_Click);

            this.qtyRow.Controls.Add(this.minusBtn, 0, 0);
            this.qtyRow.Controls.Add(this.qtyLabel, 1, 0);
            this.qtyRow.Controls.Add(this.plusBtn, 2, 0);

            // bottomBar
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomBar.BackColor = System.Drawing.Color.IndianRed;
            this.bottomBar.Visible = false;
            this.bottomBar.Controls.Add(this.lblInBag);

            // lblInBag
            this.lblInBag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInBag.ForeColor = System.Drawing.Color.White;
            this.lblInBag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInBag.Text = "In bag";
            this.lblInBag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // assemble rows
            this.root.Controls.Add(this.imageWrap, 0, 0);
            this.root.Controls.Add(this.lblName,   0, 1);
            this.root.Controls.Add(this.lblWeight, 0, 2);
            this.root.Controls.Add(this.lblPrice,  0, 3);
            this.root.Controls.Add(this.qtyRow,    0, 4);
            this.root.Controls.Add(this.bottomBar, 0, 5);

            // add to UserControl
            this.Controls.Add(this.cardBorder);

            this.cardBorder.ResumeLayout(false);
            this.root.ResumeLayout(false);
            this.imageWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.qtyRow.ResumeLayout(false);
            this.bottomBar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
