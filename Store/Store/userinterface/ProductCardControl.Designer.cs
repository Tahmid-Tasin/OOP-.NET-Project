namespace Store.userinterface
{
    partial class ProductCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TableLayoutPanel qtyPanel;
        private System.Windows.Forms.Button minusBtn;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.Button plusBtn;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.Label lblInBag;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bottomBar = new System.Windows.Forms.Panel();
            this.lblInBag = new System.Windows.Forms.Label();
            this.qtyPanel = new System.Windows.Forms.TableLayoutPanel();
            this.minusBtn = new System.Windows.Forms.Button();
            this.qtyLabel = new System.Windows.Forms.Label();
            this.plusBtn = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();

            this.mainPanel.SuspendLayout();
            this.bottomBar.SuspendLayout();
            this.qtyPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();

            // mainPanel
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Size = new System.Drawing.Size(220, 320);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(15);
            this.mainPanel.Controls.Add(this.bottomBar);
            this.mainPanel.Controls.Add(this.qtyPanel);
            this.mainPanel.Controls.Add(this.lblPrice);
            this.mainPanel.Controls.Add(this.lblWeight);
            this.mainPanel.Controls.Add(this.lblName);
            this.mainPanel.Controls.Add(this.imagePanel);

            // imagePanel
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imagePanel.Height = 160;
            this.imagePanel.Padding = new System.Windows.Forms.Padding(5);
            this.imagePanel.Controls.Add(this.pic);

            // pic
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.BackColor = System.Drawing.Color.White;

            // lblName
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Height = 24;

            // lblWeight
            this.lblWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblWeight.ForeColor = System.Drawing.Color.DimGray;
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWeight.Height = 18;

            // lblPrice
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrice.Height = 22;

            // qtyPanel
            this.qtyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qtyPanel.Height = 50;
            this.qtyPanel.ColumnCount = 3;
            this.qtyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.qtyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.qtyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));

            this.qtyPanel.Controls.Add(this.minusBtn, 0, 0);
            this.qtyPanel.Controls.Add(this.qtyLabel, 1, 0);
            this.qtyPanel.Controls.Add(this.plusBtn, 2, 0);

            // minusBtn
            this.minusBtn.Text = "−";
            this.minusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.minusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusBtn.Click += new System.EventHandler(this.minusBtn_Click);

            // qtyLabel
            this.qtyLabel.Text = "0";
            this.qtyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.qtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.qtyLabel.Dock = System.Windows.Forms.DockStyle.Fill;

            // plusBtn
            this.plusBtn.Text = "+";
            this.plusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.plusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusBtn.Click += new System.EventHandler(this.plusBtn_Click);

            // bottomBar
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBar.Height = 32;
            this.bottomBar.BackColor = System.Drawing.Color.IndianRed;
            this.bottomBar.Visible = false;
            this.bottomBar.Controls.Add(this.lblInBag);

            // lblInBag
            this.lblInBag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInBag.Text = "In Bag";
            this.lblInBag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInBag.ForeColor = System.Drawing.Color.White;
            this.lblInBag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // ProductCardControl
            this.Controls.Add(this.mainPanel);
            this.Size = new System.Drawing.Size(220, 320);

            this.mainPanel.ResumeLayout(false);
            this.bottomBar.ResumeLayout(false);
            this.qtyPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
