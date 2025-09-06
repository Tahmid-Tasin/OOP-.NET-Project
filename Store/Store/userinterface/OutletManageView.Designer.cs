namespace Store.userinterface
{
    partial class OutletManageView
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
            this.OutletGrid = new System.Windows.Forms.DataGridView();
            this.OutletID_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutletName_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();

            this.panelRight = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelOutlet = new System.Windows.Forms.Label();
            this.OutletNameBox = new System.Windows.Forms.TextBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.BranchNameBox = new System.Windows.Forms.TextBox();
            this.AddBranchBtn = new System.Windows.Forms.Button();
            this.BranchGrid = new System.Windows.Forms.DataGridView();
            this.BranchName_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchDel_Col = new System.Windows.Forms.DataGridViewButtonColumn();

            this.SaveUpdateBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();

            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutletGrid)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).BeginInit();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.panelLeft.Controls.Add(this.OutletGrid);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Size = new System.Drawing.Size(600, 729);

            // OutletGrid
            this.OutletGrid.AllowUserToAddRows = false;
            this.OutletGrid.AllowUserToDeleteRows = false;
            this.OutletGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutletGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.OutletID_Col,
                this.OutletName_Col,
                this.View_Col,
                this.Edit_Col,
                this.Delete_Col
            });
            this.OutletGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutletGrid.ReadOnly = true;
            this.OutletGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OutletGrid_CellContentClick);

            // OutletID_Col
            this.OutletID_Col.HeaderText = "ID";
            this.OutletID_Col.Name = "OutletID_Col";
            this.OutletID_Col.ReadOnly = true;
            this.OutletID_Col.Width = 60;

            // OutletName_Col
            this.OutletName_Col.HeaderText = "Outlet Name";
            this.OutletName_Col.Name = "OutletName_Col";
            this.OutletName_Col.ReadOnly = true;
            this.OutletName_Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // View_Col
            this.View_Col.HeaderText = "View";
            this.View_Col.Name = "View_Col";
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;
            this.View_Col.Width = 60;

            // Edit_Col
            this.Edit_Col.HeaderText = "Edit";
            this.Edit_Col.Name = "Edit_Col";
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;
            this.Edit_Col.Width = 60;

            // Delete_Col
            this.Delete_Col.HeaderText = "Delete";
            this.Delete_Col.Name = "Delete_Col";
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;
            this.Delete_Col.Width = 60;

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRight.Controls.Add(this.labelHeader);
            this.panelRight.Controls.Add(this.labelOutlet);
            this.panelRight.Controls.Add(this.OutletNameBox);
            this.panelRight.Controls.Add(this.labelBranch);
            this.panelRight.Controls.Add(this.BranchNameBox);
            this.panelRight.Controls.Add(this.AddBranchBtn);
            this.panelRight.Controls.Add(this.BranchGrid);
            this.panelRight.Controls.Add(this.SaveUpdateBtn);
            this.panelRight.Controls.Add(this.ResetBtn);
            this.panelRight.Controls.Add(this.BackBtn);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;

            // labelHeader
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(175, 76, 15);
            this.labelHeader.Location = new System.Drawing.Point(200, 20);
            this.labelHeader.Size = new System.Drawing.Size(400, 40);
            this.labelHeader.Text = "Outlet Management";

            // labelOutlet
            this.labelOutlet.Location = new System.Drawing.Point(50, 80);
            this.labelOutlet.Text = "Outlet Name:";

            // OutletNameBox
            this.OutletNameBox.Location = new System.Drawing.Point(200, 80);
            this.OutletNameBox.Size = new System.Drawing.Size(300, 22);

            // labelBranch
            this.labelBranch.Location = new System.Drawing.Point(50, 130);
            this.labelBranch.Text = "Branch Name:";

            // BranchNameBox
            this.BranchNameBox.Location = new System.Drawing.Point(200, 130);
            this.BranchNameBox.Size = new System.Drawing.Size(220, 22);

            // AddBranchBtn
            this.AddBranchBtn.Location = new System.Drawing.Point(430, 130);
            this.AddBranchBtn.Text = "Add Branch";
            this.AddBranchBtn.Click += new System.EventHandler(this.AddBranchBtn_Click);

            // BranchGrid
            this.BranchGrid.AllowUserToAddRows = false;
            this.BranchGrid.AllowUserToDeleteRows = false;
            this.BranchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BranchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.BranchName_Col,
                this.BranchDel_Col
            });
            this.BranchGrid.Location = new System.Drawing.Point(50, 180);
            this.BranchGrid.Size = new System.Drawing.Size(500, 400);
            this.BranchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BranchGrid_CellContentClick);

            // BranchName_Col
            this.BranchName_Col.HeaderText = "Branch Name";
            this.BranchName_Col.Name = "BranchName_Col";
            this.BranchName_Col.ReadOnly = true;
            this.BranchName_Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // BranchDel_Col
            this.BranchDel_Col.HeaderText = "Delete";
            this.BranchDel_Col.Name = "BranchDel_Col";
            this.BranchDel_Col.Text = "Delete";
            this.BranchDel_Col.UseColumnTextForButtonValue = true;
            this.BranchDel_Col.Width = 80;

            // SaveUpdateBtn
            this.SaveUpdateBtn.BackColor = System.Drawing.Color.FromArgb(175, 76, 15);
            this.SaveUpdateBtn.ForeColor = System.Drawing.Color.White;
            this.SaveUpdateBtn.Location = new System.Drawing.Point(200, 600);
            this.SaveUpdateBtn.Size = new System.Drawing.Size(100, 40);
            this.SaveUpdateBtn.Text = "Save";
            this.SaveUpdateBtn.Click += new System.EventHandler(this.SaveUpdateBtn_Click);

            // ResetBtn
            this.ResetBtn.BackColor = System.Drawing.Color.LightGray;
            this.ResetBtn.Location = new System.Drawing.Point(320, 600);
            this.ResetBtn.Size = new System.Drawing.Size(100, 40);
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);

            // BackBtn
            this.BackBtn.Location = new System.Drawing.Point(450, 600);
            this.BackBtn.Size = new System.Drawing.Size(100, 40);
            this.BackBtn.Text = "Back";
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);

            // OutletManageView
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Text = "OutletManageView";

            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutletGrid)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView OutletGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutletID_Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutletName_Col;
        private System.Windows.Forms.DataGridViewButtonColumn View_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Edit_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_Col;

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelOutlet;
        private System.Windows.Forms.TextBox OutletNameBox;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.TextBox BranchNameBox;
        private System.Windows.Forms.Button AddBranchBtn;
        private System.Windows.Forms.DataGridView BranchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName_Col;
        private System.Windows.Forms.DataGridViewButtonColumn BranchDel_Col;
        private System.Windows.Forms.Button SaveUpdateBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button BackBtn;
    }
}
