using System;
using System.Drawing;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class InventoryManage : Form
    {
        private readonly InventoryService _service;
        private readonly int _companyId;   // 👈 scope for manager

        // For Admin
        public InventoryManage()
        {
            InitializeComponent();
            _service = new InventoryService();
            _companyId = 0;

            SetupGrid();
            InitPlaceholders();
            RepositionAddNew();
            LoadInventory();
        }

        // For Company Manager
        public InventoryManage(int companyId) : this()
        {
            _companyId = companyId;
            LoadInventory();
        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            ID_Column.DataPropertyName = "Id";
            Product_Column.DataPropertyName = "ProductName";
            Brand_Column.DataPropertyName = "ProductBrand";
            Branch_Column.DataPropertyName = "BranchName";
            Qty_Column.DataPropertyName = "Quantity";
            Updated_Column.DataPropertyName = "UpdatedAt";
        }


        private void LoadInventory()
        {
            dataGridView1.DataSource = null;

            if (_companyId > 0)
                dataGridView1.DataSource = _service.Search(companyId: _companyId);
            else
                dataGridView1.DataSource = _service.GetAll();
        }

        // ===== Header events =====
        private void topPanel_SizeChanged(object sender, EventArgs e) => RepositionAddNew();

        private void RepositionAddNew()
        {
            int rightMargin = 12;
            int top = Math.Max(14, (topPanel.Height - btnAddNew.Height) / 2);
            btnAddNew.Location = new Point(topPanel.ClientSize.Width - btnAddNew.Width - rightMargin, top);
        }

        private void cbFilterToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool show = cbFilterToggle.SelectedIndex == 1;
            filterPanel.Visible = show;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new InventoryEditForm(_companyId))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadInventory();
            }
        }

        // ===== Search / Reset =====
        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            var product = GetValueOrNull(txtSearchProduct);
            var brand = GetValueOrNull(txtSearchBrand);

            dataGridView1.DataSource = null;

            var data = _service.Search(companyId: _companyId > 0 ? _companyId : (int?)null);
            dataGridView1.DataSource = data.FindAll(x =>
                (string.IsNullOrEmpty(product) ||
                 (!string.IsNullOrEmpty(x.Product?.NAME) &&
                  x.Product.NAME.IndexOf(product, StringComparison.OrdinalIgnoreCase) >= 0)) &&
                (string.IsNullOrEmpty(brand) ||
                 (!string.IsNullOrEmpty(x.Product?.BRAND) &&
                  x.Product.BRAND.IndexOf(brand, StringComparison.OrdinalIgnoreCase) >= 0))
            );
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            InitPlaceholders();
            LoadInventory();
        }

        // ===== Grid action buttons =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex].Name;
            if (col != "View_Col" && col != "Edit_Col" && col != "Delete_Col") return;

            var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as Inventory;
            if (item == null) return;

            if (col == "View_Col")
            {
                using (var dlg = new InventoryViewForm(item))
                {
                    dlg.ShowDialog(this);
                }
            }
            else if (col == "Edit_Col")
            {
                using (var dlg = new InventoryEditForm(item, _companyId))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        LoadInventory();
                }
            }
            else if (col == "Delete_Col")
            {
                if (MessageBox.Show(
                        $"Delete product '{item.Product?.NAME}' in branch '{item.Branch?.Name}'?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                _service.Remove(item.Id);
                LoadInventory();
            }
        }

        // ===== Placeholder helpers =====
        private void InitPlaceholders()
        {
            SetPlaceholder(txtSearchProduct, "Product");
            SetPlaceholder(txtSearchBrand, "Brand");

            txtSearchProduct.GotFocus += RemovePlaceholder;
            txtSearchBrand.GotFocus += RemovePlaceholder;

            txtSearchProduct.LostFocus += AddPlaceholder;
            txtSearchBrand.LostFocus += AddPlaceholder;
        }

        private void SetPlaceholder(TextBox box, string text)
        {
            box.Tag = text;
            box.Text = text;
            box.ForeColor = Color.Gray;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            if (box != null && box.ForeColor == Color.Gray)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            if (box != null && string.IsNullOrWhiteSpace(box.Text))
            {
                box.Text = box.Tag as string;
                box.ForeColor = Color.Gray;
            }
        }

        private string GetValueOrNull(TextBox box)
        {
            return (box.ForeColor == Color.Gray) ? null : box.Text.Trim();
        }
    }
}
