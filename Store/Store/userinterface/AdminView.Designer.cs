namespace Store
{
    partial class AdminView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.EmployeeBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.OutletBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.sideMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.sideMenuPanel.Controls.Add(this.label1);
            this.sideMenuPanel.Controls.Add(this.button4);
            this.sideMenuPanel.Controls.Add(this.EmployeeBtn);
            this.sideMenuPanel.Controls.Add(this.button5);
            this.sideMenuPanel.Controls.Add(this.OutletBtn);
            this.sideMenuPanel.Controls.Add(this.button7);
            this.sideMenuPanel.Controls.Add(this.button6);
            this.sideMenuPanel.Controls.Add(this.button2);
            this.sideMenuPanel.Controls.Add(this.button1);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(200, 729);
            this.sideMenuPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "MENU BAR";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4 (Dashboard)
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Text = "Dashboard";
            this.button4.Height = 50;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // EmployeeBtn
            // 
            this.EmployeeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeBtn.Text = "Employee";
            this.EmployeeBtn.Height = 50;
            this.EmployeeBtn.Click += new System.EventHandler(this.EmployeeBtn_Click);
            // 
            // button5 (Stock)
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Text = "Stock";
            this.button5.Height = 50;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // OutletBtn
            // 
            this.OutletBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutletBtn.Text = "Outlet";
            this.OutletBtn.Height = 50;
            this.OutletBtn.Click += new System.EventHandler(this.OutletBtn_Click);
            // 
            // button7 (Products)
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Text = "Products";
            this.button7.Height = 50;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6 (Review)
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Text = "Review";
            this.button6.Height = 50;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2 (VIP Customers)
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Text = "VIP Customers";
            this.button2.Height = 50;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1 (Logout)
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Text = "Logout";
            this.button1.Height = 50;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1203, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 113);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(200, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1150, 729);
            this.contentPanel.TabIndex = 3;
            // 
            // AdminView
            // 
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sideMenuPanel);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.Load += new System.EventHandler(this.AdminView_Load);
            this.sideMenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button EmployeeBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OutletBtn;
    }
}
