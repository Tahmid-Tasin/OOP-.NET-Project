// File: Store/userinterface/PurchaseHistoryForm.Designer.cs
namespace Store.userinterface
{
    partial class PurchaseHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvHistory;

        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalColumn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvHistory = new System.Windows.Forms.DataGridView();

            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // dgvHistory
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.AutoGenerateColumns = false;
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.DateColumn,
                this.CompanyColumn,
                this.BranchColumn,
                this.ProductColumn,
                this.QtyColumn,
                this.PriceColumn,
                this.TotalColumn
            });

            // Columns
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.DataPropertyName = "CreatedAt";
            this.DateColumn.Width = 130;

            this.CompanyColumn.HeaderText = "Company";
            this.CompanyColumn.DataPropertyName = "CompanyId"; // optionally join for name
            this.CompanyColumn.Width = 150;

            this.BranchColumn.HeaderText = "Branch";
            this.BranchColumn.DataPropertyName = "BranchId";
            this.BranchColumn.Width = 120;

            this.ProductColumn.HeaderText = "Product";
            this.ProductColumn.DataPropertyName = "ProductName";
            this.ProductColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.QtyColumn.HeaderText = "Qty";
            this.QtyColumn.DataPropertyName = "Quantity";
            this.QtyColumn.Width = 60;

            this.PriceColumn.HeaderText = "Unit Price";
            this.PriceColumn.DataPropertyName = "UnitPrice";
            this.PriceColumn.Width = 90;

            this.TotalColumn.HeaderText = "Total";
            this.TotalColumn.Width = 90;
            this.TotalColumn.DataPropertyName = "Total"; // computed in a viewmodel if needed

            // Form
            this.ClientSize = new System.Drawing.Size(860, 480);
            this.Controls.Add(this.dgvHistory);
            this.Text = "My Purchase History";
            this.Load += new System.EventHandler(this.PurchaseHistoryForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
