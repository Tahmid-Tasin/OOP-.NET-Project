using System;
using System.Drawing;
using System.Windows.Forms;
using Store.service;
//using Store.Repository; // <-- for Branch model (adjust if your model namespace differs)

namespace Store.userinterface
{
    public partial class BranchManage : Form
    {
        private readonly BranchService _branchService;
        private readonly int _companyId;

        public BranchManage(int companyId)
        {
            InitializeComponent();

            _branchService = new BranchService();
            _companyId = companyId;

            // Grid binding setup
            dataGridView1.AutoGenerateColumns = false;
            ID_Column.DataPropertyName = "Id";
            Name_Column.DataPropertyName = "Name";
            City_Column.DataPropertyName = "City";
            Phone_Column.DataPropertyName = "Phone";
            Email_Column.DataPropertyName = "Email";

            // Wire placeholder handlers once
            txtSearchName.GotFocus += RemovePlaceholder;
            txtSearchCity.GotFocus += RemovePlaceholder;
            txtSearchPhone.GotFocus += RemovePlaceholder;
            txtSearchPostal.GotFocus += RemovePlaceholder;

            txtSearchName.LostFocus += AddPlaceholder;
            txtSearchCity.LostFocus += AddPlaceholder;
            txtSearchPhone.LostFocus += AddPlaceholder;
            txtSearchPostal.LostFocus += AddPlaceholder;

            // Initial state
            ResetPlaceholders();
            cbFilterToggle.SelectedIndex = 0; // Hide Filters
            RepositionAddNew();
            LoadBranches();
        }

        private void LoadBranches()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _branchService.GetByCompany(_companyId);
        }

        private void topPanel_SizeChanged(object sender, EventArgs e) => RepositionAddNew();

        private void RepositionAddNew()
        {
            int rightMargin = 12;
            int top = Math.Max(14, (topPanel.Height - btnAddNew.Height) / 2);
            btnAddNew.Location = new Point(topPanel.ClientSize.Width - btnAddNew.Width - rightMargin, top);
        }

        private void cbFilterToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterPanel.Visible = cbFilterToggle.SelectedIndex == 1; // 0=Hide, 1=Show
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new BranchEditForm(_companyId))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadBranches();
            }
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            var name = GetValueOrNull(txtSearchName);
            var city = GetValueOrNull(txtSearchCity);
            var phone = GetValueOrNull(txtSearchPhone);
            var postal = GetValueOrNull(txtSearchPostal);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _branchService.Search(name, city, phone, postal, _companyId);
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            ResetPlaceholders();
            LoadBranches();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;
            var branch = dataGridView1.Rows[e.RowIndex].DataBoundItem as Branch;
            if (branch == null) return;

            if (colName == "View")
            {
                MessageBox.Show(
                    $"Name: {branch.Name}\n" +
                    $"Address: {branch.AddressLine1} {branch.AddressLine2}\n" +
                    $"{branch.City}, {branch.State} {branch.PostalCode}, {branch.Country}\n" +
                    $"Phone: {branch.Phone}\n" +
                    $"Email: {branch.Email}",
                    "Branch");
            }
            else if (colName == "Edit")
            {
                using (var dlg = new BranchEditForm(_companyId, branch))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        LoadBranches();
                }
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show($"Delete branch '{branch.Name}'?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                _branchService.Delete(branch.Id);
                LoadBranches();
            }
        }

        // === Placeholders ===
        private void ResetPlaceholders()
        {
            SetPlaceholder(txtSearchName, "Name");
            SetPlaceholder(txtSearchCity, "City");
            SetPlaceholder(txtSearchPhone, "Phone");
            SetPlaceholder(txtSearchPostal, "Postal Code");
        }

        private void SetPlaceholder(TextBox box, string text)
        {
            box.Tag = text;
            box.Text = text;
            box.ForeColor = Color.Gray;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (sender is TextBox box && box.ForeColor == Color.Gray)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (sender is TextBox box && string.IsNullOrWhiteSpace(box.Text))
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
