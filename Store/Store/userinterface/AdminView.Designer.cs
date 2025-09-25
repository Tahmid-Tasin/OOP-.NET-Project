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
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.EmployeeBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.CompanyBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.reviewbtn = new System.Windows.Forms.Button();
            this.BranchBtn = new System.Windows.Forms.Button();
            this.ProductsBtn = new System.Windows.Forms.Button();
            this.ItemsBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rightContainer = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.userRightFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.headerIcon = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.sideMenuPanel.SuspendLayout();
            this.rightContainer.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.userRightFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.sideMenuPanel.Controls.Add(this.label1);
            this.sideMenuPanel.Controls.Add(this.button4);
            this.sideMenuPanel.Controls.Add(this.EmployeeBtn);
            this.sideMenuPanel.Controls.Add(this.button5);
            this.sideMenuPanel.Controls.Add(this.CompanyBtn);
            this.sideMenuPanel.Controls.Add(this.button7);
            this.sideMenuPanel.Controls.Add(this.reviewbtn);
            this.sideMenuPanel.Controls.Add(this.BranchBtn);
            this.sideMenuPanel.Controls.Add(this.ProductsBtn);
            this.sideMenuPanel.Controls.Add(this.ItemsBtn);
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
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(0, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 50);
            this.button4.TabIndex = 8;
            this.button4.Text = "Dashboard";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // EmployeeBtn
            // 
            this.EmployeeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmployeeBtn.Location = new System.Drawing.Point(0, 400);
            this.EmployeeBtn.Name = "EmployeeBtn";
            this.EmployeeBtn.Size = new System.Drawing.Size(200, 50);
            this.EmployeeBtn.TabIndex = 9;
            this.EmployeeBtn.Text = "Company Managers";
            this.EmployeeBtn.Click += new System.EventHandler(this.EmployeeBtn_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(0, 350);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 50);
            this.button5.TabIndex = 10;
            this.button5.Text = "Stock";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CompanyBtn
            // 
            this.CompanyBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyBtn.Location = new System.Drawing.Point(0, 300);
            this.CompanyBtn.Name = "CompanyBtn";
            this.CompanyBtn.Size = new System.Drawing.Size(200, 50);
            this.CompanyBtn.TabIndex = 11;
            this.CompanyBtn.Text = "Company";
            this.CompanyBtn.Click += new System.EventHandler(this.CompanyBtn_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Location = new System.Drawing.Point(0, 250);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(200, 50);
            this.button7.TabIndex = 12;
            this.button7.Text = "Products";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // reviewbtn
            // 
            this.reviewbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.reviewbtn.Location = new System.Drawing.Point(0, 200);
            this.reviewbtn.Name = "reviewbtn";
            this.reviewbtn.Size = new System.Drawing.Size(200, 50);
            this.reviewbtn.TabIndex = 13;
            this.reviewbtn.Text = "Review";
            this.reviewbtn.Click += new System.EventHandler(this.reviewbtn_Click);
            // 
            // BranchBtn
            // 
            this.BranchBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.BranchBtn.Location = new System.Drawing.Point(0, 150);
            this.BranchBtn.Name = "BranchBtn";
            this.BranchBtn.Size = new System.Drawing.Size(200, 50);
            this.BranchBtn.TabIndex = 14;
            this.BranchBtn.Text = "Branches";
            this.BranchBtn.Click += new System.EventHandler(this.BranchBtn_Click);
            // 
            // ProductsBtn
            // 
            this.ProductsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductsBtn.Location = new System.Drawing.Point(0, 100);
            this.ProductsBtn.Name = "ProductsBtn";
            this.ProductsBtn.Size = new System.Drawing.Size(200, 50);
            this.ProductsBtn.TabIndex = 15;
            this.ProductsBtn.Text = "Products (Customer)";
            this.ProductsBtn.Click += new System.EventHandler(this.ProductsBtn_Click);
            // 
            // ItemsBtn
            // 
            this.ItemsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsBtn.Location = new System.Drawing.Point(0, 50);
            this.ItemsBtn.Name = "ItemsBtn";
            this.ItemsBtn.Size = new System.Drawing.Size(200, 50);
            this.ItemsBtn.TabIndex = 16;
            this.ItemsBtn.Text = "Items (Customer)";
            this.ItemsBtn.Click += new System.EventHandler(this.ItemsBtn_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 50);
            this.button2.TabIndex = 17;
            this.button2.Text = "VIP Customers";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 679);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 18;
            this.button1.Text = "Logout";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rightContainer
            // 
            this.rightContainer.Controls.Add(this.contentPanel);
            this.rightContainer.Controls.Add(this.headerPanel);
            this.rightContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightContainer.Location = new System.Drawing.Point(200, 0);
            this.rightContainer.Name = "rightContainer";
            this.rightContainer.Size = new System.Drawing.Size(1150, 729);
            this.rightContainer.TabIndex = 2;
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 60);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1150, 669);
            this.contentPanel.TabIndex = 1;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.headerPanel.Controls.Add(this.userRightFlow);
            this.headerPanel.Controls.Add(this.lblCompanyName);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1150, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // userRightFlow
            // 
            this.userRightFlow.AutoSize = true;
            this.userRightFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userRightFlow.Controls.Add(this.lblUserName);
            this.userRightFlow.Controls.Add(this.lblUserRole);
            this.userRightFlow.Controls.Add(this.headerIcon);
            this.userRightFlow.Dock = System.Windows.Forms.DockStyle.Right;
            this.userRightFlow.Location = new System.Drawing.Point(968, 0);
            this.userRightFlow.Name = "userRightFlow";
            this.userRightFlow.Padding = new System.Windows.Forms.Padding(0, 16, 12, 0);
            this.userRightFlow.Size = new System.Drawing.Size(182, 60);
            this.userRightFlow.TabIndex = 0;
            this.userRightFlow.WrapContents = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUserName.Location = new System.Drawing.Point(0, 16);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 19);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Unknown";
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblUserRole.Location = new System.Drawing.Point(79, 16);
            this.lblUserRole.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(37, 19);
            this.lblUserRole.TabIndex = 1;
            this.lblUserRole.Text = "User";
            // 
            // headerIcon
            // 
            this.headerIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerIcon.Location = new System.Drawing.Point(131, 19);
            this.headerIcon.Name = "headerIcon";
            this.headerIcon.Size = new System.Drawing.Size(36, 36);
            this.headerIcon.TabIndex = 2;
            this.headerIcon.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.Location = new System.Drawing.Point(12, 20);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(133, 21);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Company Name";
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.rightContainer);
            this.Controls.Add(this.sideMenuPanel);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.Load += new System.EventHandler(this.AdminView_Load);
            this.sideMenuPanel.ResumeLayout(false);
            this.rightContainer.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.userRightFlow.ResumeLayout(false);
            this.userRightFlow.PerformLayout();
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
        private System.Windows.Forms.Button reviewbtn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button EmployeeBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CompanyBtn;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button BranchBtn;
        private System.Windows.Forms.Button ProductsBtn;
        private System.Windows.Forms.Button ItemsBtn;
    }
}
