namespace Store.userinterface
{
    partial class OutletDetailsView
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
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelOutlet = new System.Windows.Forms.Label();
            this.OutletNameLabel = new System.Windows.Forms.Label();
            this.BranchGrid = new System.Windows.Forms.DataGridView();
            this.BranchName_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).BeginInit();
            this.SuspendLayout();

            // labelHeader
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(175, 76, 15);
            this.labelHeader.Location = new System.Drawing.Point(200, 20);
            this.labelHeader.Size = new System.Drawing.Size(400, 40);
            this.labelHeader.Text = "Outlet Details";

            // labelOutlet
            this.labelOutlet.Location = new System.Drawing.Point(50, 80);
            this.labelOutlet.Size = new System.Drawing.Size(100, 25);
            this.labelOutlet.Text = "Outlet:";

            // OutletNameLabel
            this.OutletNameLabel.Location = new System.Drawing.Point(160, 80);
            this.OutletNameLabel.Size = new System.Drawing.Size(400, 25);
            this.OutletNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);

            // BranchGrid
            this.BranchGrid.AllowUserToAddRows = false;
            this.BranchGrid.AllowUserToDeleteRows = false;
            this.BranchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BranchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.BranchName_Col
            });
            this.BranchGrid.Location = new System.Drawing.Point(50, 130);
            this.BranchGrid.Size = new System.Drawing.Size(500, 400);
            this.BranchGrid.ReadOnly = true;

            // BranchName_Col
            this.BranchName_Col.HeaderText = "Branch Name";
            this.BranchName_Col.Name = "BranchName_Col";
            this.BranchName_Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // OutletDetailsView
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelOutlet);
            this.Controls.Add(this.OutletNameLabel);
            this.Controls.Add(this.BranchGrid);
            this.Text = "OutletDetailsView";
            ((System.ComponentModel.ISupportInitialize)(this.BranchGrid)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelOutlet;
        private System.Windows.Forms.Label OutletNameLabel;
        private System.Windows.Forms.DataGridView BranchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName_Col;
    }
}
