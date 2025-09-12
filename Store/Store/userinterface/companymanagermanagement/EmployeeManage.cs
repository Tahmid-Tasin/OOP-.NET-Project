using System;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class EmployeeManage : Form
    {
        private readonly EmployeeService _employeeService;

        public EmployeeManage()
        {
            _employeeService = new EmployeeService();
            InitializeComponent();

            // Grid binding
            dataGridView1.AutoGenerateColumns = false;
            ID_Coloumn.DataPropertyName = "ID";
            Name_Coloumn.DataPropertyName = "NAME";
            Mobile_Coloumn.DataPropertyName = "MOBILE";
            Address_Coloumn.DataPropertyName = "ADDRESS";

            LoadEmployeesIntoGrid();
        }

        private void LoadEmployeesIntoGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _employeeService.GetAll();
            btnResetSearch.Visible = false; // reset button only after a search
        }

        // ===== Top bar actions =====
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // ADD mode – open dialog with no args
            using (var dlg = new EmployeeEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadEmployeesIntoGrid();
                }
            }
        }

        private void btnToggleSearch_Click(object sender, EventArgs e)
        {
            searchPanel.Visible = !searchPanel.Visible;
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearchName.Text.Trim();
            string mobile = txtSearchMobile.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(mobile))
            {
                MessageBox.Show("Enter Name and/or Mobile to search.");
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _employeeService.Search(name, mobile);
            btnResetSearch.Visible = true;
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            txtSearchMobile.Text = "";
            LoadEmployeesIntoGrid();
        }

        // ===== Grid button handling =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName != "View_Col" && colName != "Edit_Col" && colName != "Delete_Col") return;

            var emp = dataGridView1.Rows[e.RowIndex].DataBoundItem as Employee;
            if (emp == null) return;

            if (colName == "View_Col")
            {
                MessageBox.Show(
                    $"ID: {emp.ID}\nName: {emp.NAME}\nMobile: {emp.MOBILE}\nAddress: {emp.ADDRESS}",
                    "Employee");
            }
            else if (colName == "Edit_Col")
            {
                // EDIT mode – open dialog with the Employee instance
                using (var dlg = new EmployeeEditForm(emp))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadEmployeesIntoGrid();
                    }
                }
            }
            else if (colName == "Delete_Col")
            {
                if (MessageBox.Show($"Delete employee #{emp.ID}?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                var rows = _employeeService.Delete(emp.ID);
                if (rows > 0) LoadEmployeesIntoGrid();
                else MessageBox.Show("Delete failed.");
            }
        }
    }
}
