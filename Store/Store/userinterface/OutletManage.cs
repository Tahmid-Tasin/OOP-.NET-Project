using System;
using System.Drawing;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class OutletManage : Form
    {
        private readonly OutletService _outletService;

        public OutletManage()
        {
            InitializeComponent();
            _outletService = new OutletService();

            // grid binding
            dataGridView1.AutoGenerateColumns = false;
            ID_Column.DataPropertyName    = "Id";
            Name_Column.DataPropertyName  = "Name";
            City_Column.DataPropertyName  = "City";
            Phone_Column.DataPropertyName = "Phone";
            Contact_Column.DataPropertyName = "ContactName";

            // placeholders for classic WinForms
            InitPlaceholders();

            // ensure Add button sits at top-right initially
            RepositionAddNew();

            LoadOutlets();
        }

        private void LoadOutlets()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _outletService.GetAll();
        }

        // ===== Header events =====
        private void topPanel_SizeChanged(object sender, EventArgs e) => RepositionAddNew();

        private void RepositionAddNew()
        {
            // keep a 12px right margin, vertically ~centered
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
            using (var dlg = new OutletEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadOutlets();
            }
        }

        // ===== Search / Reset =====
        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            var name    = GetValueOrNull(txtSearchName);
            var phone   = GetValueOrNull(txtSearchPhone);
            var address = GetValueOrNull(txtSearchAddress);
            var city    = GetValueOrNull(txtSearchCity);
            var postal  = GetValueOrNull(txtSearchPostal);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _outletService.Search(name, phone, address, city, postal, null);
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            InitPlaceholders();
            LoadOutlets();
        }

        // ===== Grid action buttons =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex].Name;
            if (col != "View_Col" && col != "Edit_Col" && col != "Delete_Col") return;

            var outlet = dataGridView1.Rows[e.RowIndex].DataBoundItem as Outlet;
            if (outlet == null) return;

            if (col == "View_Col")
            {
                MessageBox.Show(
                    $"Name: {outlet.Name}\n" +
                    $"Address: {outlet.AddressLine1} {outlet.AddressLine2}\n" +
                    $"{outlet.City}, {outlet.State} {outlet.PostalCode}, {outlet.Country}\n" +
                    $"Phone: {outlet.Phone}\n" +
                    $"Contact: {outlet.ContactName} ({outlet.ContactEmail})",
                    "Outlet");
            }
            else if (col == "Edit_Col")
            {
                using (var dlg = new OutletEditForm(outlet))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        LoadOutlets();
                }
            }
            else if (col == "Delete_Col")
            {
                if (MessageBox.Show($"Delete outlet '{outlet.Name}'?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                _outletService.Delete(outlet.Id);
                LoadOutlets();
            }
        }

        // ===== Placeholder helpers (classic WinForms) =====
        private void InitPlaceholders()
        {
            SetPlaceholder(txtSearchName,    "Name");
            SetPlaceholder(txtSearchPhone,   "Phone");
            SetPlaceholder(txtSearchAddress, "Address");
            SetPlaceholder(txtSearchCity,    "City");
            SetPlaceholder(txtSearchPostal,  "Postal Code");

            txtSearchName.GotFocus    += RemovePlaceholder;
            txtSearchPhone.GotFocus   += RemovePlaceholder;
            txtSearchAddress.GotFocus += RemovePlaceholder;
            txtSearchCity.GotFocus    += RemovePlaceholder;
            txtSearchPostal.GotFocus  += RemovePlaceholder;

            txtSearchName.LostFocus    += AddPlaceholder;
            txtSearchPhone.LostFocus   += AddPlaceholder;
            txtSearchAddress.LostFocus += AddPlaceholder;
            txtSearchCity.LostFocus    += AddPlaceholder;
            txtSearchPostal.LostFocus  += AddPlaceholder;
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
