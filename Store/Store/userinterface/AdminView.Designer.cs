using System.Drawing;

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
            this.CompanyBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BranchBtn = new System.Windows.Forms.Button();

            this.rightContainer = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();

            // Header stack
            this.userRightFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.headerIcon = new System.Windows.Forms.PictureBox();

            // Left header (company name)
            this.lblCompanyName = new System.Windows.Forms.Label();

            this.sideMenuPanel.SuspendLayout();
            this.rightContainer.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminView (Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.Load += new System.EventHandler(this.AdminView_Load);
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(175, 76, 15);
            this.sideMenuPanel.Controls.Add(this.label1);
            this.sideMenuPanel.Controls.Add(this.button4);
            this.sideMenuPanel.Controls.Add(this.EmployeeBtn);
            this.sideMenuPanel.Controls.Add(this.button5);
            this.sideMenuPanel.Controls.Add(this.CompanyBtn);
            this.sideMenuPanel.Controls.Add(this.button7);
            this.sideMenuPanel.Controls.Add(this.button6);
            this.sideMenuPanel.Controls.Add(this.BranchBtn);
            this.sideMenuPanel.Controls.Add(this.button2);
            this.sideMenuPanel.Controls.Add(this.button1);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(200, 729);
            this.sideMenuPanel.TabIndex = 1;
            // 
            // label1 (Menu title)
            // 
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "MENU BAR";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // Dashboard
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Text = "Dashboard";
            this.button4.Height = 50;
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // Managers
            this.EmployeeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeBtn.Text = "Company Managers";
            this.EmployeeBtn.Height = 50;
            this.EmployeeBtn.Click += new System.EventHandler(this.EmployeeBtn_Click);

            // Stock
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Text = "Stock";
            this.button5.Height = 50;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // Company
            this.CompanyBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyBtn.Text = "Company";
            this.CompanyBtn.Height = 50;
            this.CompanyBtn.Click += new System.EventHandler(this.CompanyBtn_Click);

            // Products
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Text = "Products";
            this.button7.Height = 50;
            this.button7.Click += new System.EventHandler(this.button7_Click);

            // Review
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Text = "Review";
            this.button6.Height = 50;
            this.button6.Click += new System.EventHandler(this.button6_Click);

            // Branch
            this.BranchBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.BranchBtn.Text = "Branches";
            this.BranchBtn.Height = 50;
            this.BranchBtn.Click += new System.EventHandler(this.BranchBtn_Click);

            // VIP Customers
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Text = "VIP Customers";
            this.button2.Height = 50;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // Logout
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Text = "Logout";
            this.button1.Height = 50;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // rightContainer
            this.rightContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightContainer.Location = new System.Drawing.Point(200, 0);
            this.rightContainer.Name = "rightContainer";
            this.rightContainer.Size = new System.Drawing.Size(1150, 729);
            this.rightContainer.TabIndex = 2;
            this.rightContainer.Controls.Add(this.contentPanel);
            this.rightContainer.Controls.Add(this.headerPanel);

            // contentPanel
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 60);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1150, 669);
            this.contentPanel.TabIndex = 1;

            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1150, 60);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Controls.Add(this.userRightFlow);
            this.headerPanel.Controls.Add(this.lblCompanyName);

            // lblCompanyName
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.Location = new System.Drawing.Point(12, 20);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Text = "Company Name";

            // userRightFlow
            this.userRightFlow.AutoSize = true;
            this.userRightFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userRightFlow.Dock = System.Windows.Forms.DockStyle.Right;
            this.userRightFlow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.userRightFlow.WrapContents = false;
            this.userRightFlow.Padding = new System.Windows.Forms.Padding(0, 16, 12, 0);
            this.userRightFlow.Controls.Add(this.lblUserName);
            this.userRightFlow.Controls.Add(this.lblUserRole);
            this.userRightFlow.Controls.Add(this.headerIcon);

            // lblUserName
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblUserName.Text = "Unknown";

            // lblUserRole
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblUserRole.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.lblUserRole.Text = "User";

            // headerIcon
            this.headerIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.headerIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerIcon.Size = new System.Drawing.Size(36, 36);
            this.headerIcon.TabStop = false;
            
            // Inside sideMenuPanel
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Text = "Inventory";
            this.button5.Height = 50;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // AdminView - add to Form
            this.Controls.Add(this.rightContainer);
            this.Controls.Add(this.sideMenuPanel);
            this.sideMenuPanel.ResumeLayout(false);
            this.rightContainer.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerIcon)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Panel rightContainer;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;

        private System.Windows.Forms.FlowLayoutPanel userRightFlow;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.PictureBox headerIcon;

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button EmployeeBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CompanyBtn;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button BranchBtn;
    }
}
