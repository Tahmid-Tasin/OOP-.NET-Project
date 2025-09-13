// NEW UI (Designer): Store/userinterface/OrderSummaryForm.Designer.cs
using System.Drawing;

namespace Store.userinterface
{
    partial class OrderSummaryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblGrand;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Column;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.Company_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Column  = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty_Column     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Column   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Column   = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.footer = new System.Windows.Forms.Panel();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblGrand = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Name = "OrderSummaryForm";
            this.Text = "Order Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            // Header
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Height = 56;
            this.header.BackColor = Color.White;
            this.header.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "Review & Pay";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);

            this.header.Controls.Add(this.lblTitle);

            // DataGridView
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoGenerateColumns = false;
            this.dgvLines.BackgroundColor = Color.White;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.MultiSelect = false;
            this.dgvLines.ReadOnly = true;

            // Columns
            this.Company_Column.HeaderText = "Company";
            this.Company_Column.Width = 150;

            this.Branch_Column.HeaderText = "Branch";
            this.Branch_Column.Width  = 140;

            this.Product_Column.HeaderText = "Product";
            this.Product_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.Qty_Column.HeaderText = "Qty";
            this.Qty_Column.Width = 60;

            this.Price_Column.HeaderText = "Unit Price (৳)";
            this.Price_Column.Width = 110;
            this.Price_Column.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle { Format = "N2" };

            this.Total_Column.HeaderText = "Total (৳)";
            this.Total_Column.Width = 110;
            this.Total_Column.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle { Format = "N2" };

            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Company_Column, this.Branch_Column, this.Product_Column,
                this.Qty_Column, this.Price_Column, this.Total_Column
            });

            // Footer
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Height = 110;
            this.footer.BackColor = Color.White;
            this.footer.Padding = new System.Windows.Forms.Padding(16);

            this.lblItems.AutoSize = true;
            this.lblItems.Text = "Items: 0";
            this.lblItems.Location = new System.Drawing.Point(16, 16);

            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Text = "Subtotal: ৳ 0.00";
            this.lblSubtotal.Location = new System.Drawing.Point(16, 40);

            this.lblGrand.AutoSize = true;
            this.lblGrand.Text = "৳ 0.00";
            this.lblGrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrand.Location = new System.Drawing.Point(16, 64);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Location = new System.Drawing.Point(640, 60);

            this.btnPay.Text = "Pay";
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Size = new System.Drawing.Size(100, 30);
            this.btnPay.Location = new System.Drawing.Point(746, 60);

            this.footer.Controls.Add(this.lblItems);
            this.footer.Controls.Add(this.lblSubtotal);
            this.footer.Controls.Add(this.lblGrand);
            this.footer.Controls.Add(this.btnCancel);
            this.footer.Controls.Add(this.btnPay);

            // Add to Form
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
        }
    }
}
