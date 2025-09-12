using System.Drawing;
using System.Windows.Forms;

namespace Store.userinterface
{
    partial class ProductCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Panel imagePanel;
        private PictureBox pic;
        private Label lblName;
        private Label lblWeight;
        private Label lblPrice;
        private TableLayoutPanel qtyPanel;
        private Button minusBtn;
        private Label qtyLabel;
        private Button plusBtn;
        private Panel bottomBar;
        private Label lblInBag;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

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

            // ==== ProductCardControl (root) ====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Size = new System.Drawing.Size(220, 320);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.DoubleBuffered = true;

            // ==== mainPanel ====
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(0);

            // ==== bottomBar ====
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
            this.lblInBag.AutoSize = false;

            // ==== qtyPanel ====
            this.qtyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qtyPanel.Height = 50;
            this.qtyPanel.ColumnCount = 3;
            this.qtyPanel.RowCount = 1;
            this.qtyPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.qtyPanel.ColumnStyles.Clear();
            this.qtyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.qtyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            this.qtyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            this.qtyPanel.RowStyles.Clear();
            this.qtyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // minusBtn
            this.minusBtn.Text = "−";
            this.minusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.minusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusBtn.Margin = new Padding(6, 6, 3, 6);
            this.minusBtn.Click += new System.EventHandler(this.minusBtn_Click);

            // qtyLabel
            this.qtyLabel.Text = "0";
            this.qtyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.qtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.qtyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qtyLabel.AutoSize = false;
            this.qtyLabel.Margin = new Padding(3, 6, 3, 6);

            // plusBtn
            this.plusBtn.Text = "+";
            this.plusBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.plusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusBtn.Margin = new Padding(3, 6, 6, 6);
            this.plusBtn.Click += new System.EventHandler(this.plusBtn_Click);

            this.qtyPanel.Controls.Add(this.minusBtn, 0, 0);
            this.qtyPanel.Controls.Add(this.qtyLabel, 1, 0);
            this.qtyPanel.Controls.Add(this.plusBtn, 2, 0);

            // ==== lblPrice ====
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.AutoSize = false;
            this.lblPrice.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrice.Height = 22;

            // ==== lblWeight ====
            this.lblWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWeight.AutoSize = false;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblWeight.ForeColor = System.Drawing.Color.DimGray;
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWeight.Height = 18;

            // ==== lblName ====
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.AutoSize = false;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.Height = 24;

            // ==== imagePanel ====
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imagePanel.Height = 160;
            this.imagePanel.Padding = new System.Windows.Forms.Padding(5);
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.Controls.Add(this.pic);

            // pic
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // ===== Add children to mainPanel IN THIS ORDER (top-first) =====
            // IMPORTANT: Dock.Top stacking depends on add order; add top-most FIRST.
            this.mainPanel.Controls.Add(this.qtyPanel);   // will appear BELOW the items added after this
            this.mainPanel.Controls.Add(this.lblPrice);
            this.mainPanel.Controls.Add(this.lblWeight);
            this.mainPanel.Controls.Add(this.lblName);
            this.mainPanel.Controls.Add(this.imagePanel);
            this.mainPanel.Controls.Add(this.bottomBar);  // Dock.Bottom

            // Root add
            this.Controls.Add(this.mainPanel);
        }
    }
}
