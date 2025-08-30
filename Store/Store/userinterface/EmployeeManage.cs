using System;
using System.Windows.Forms;

using Store.service;

namespace Store
{
    public partial class EmployeeManage : Form
    {
        private readonly EmployeeService _employeeService;

        public EmployeeManage()
        {
            _employeeService = new EmployeeService();
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            ID_Coloumn.DataPropertyName = "ID";
            Name_Coloumn.DataPropertyName = "NAME";
            Mobile_Coloumn.DataPropertyName = "MOBILE";
            Address_Coloumn.DataPropertyName = "ADDRESS";

            ActionAddUpdate.Text = "Add";
            EditResetBtn.Enabled = false;
            PassBox.Enabled = true;

            LoadEmployeesIntoGrid();
        }

        private void LoadEmployeesIntoGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _employeeService.GetAll();
        }

        private void ResetEditForm()
        {
            IDBox.Text = "";
            NameBox.Text = "";
            MobileBox.Text = "";
            PassBox.Text = "";
            Addressbox.Text = "";
            PassBox.Enabled = true;
            ActionAddUpdate.Text = "Add";
            EditResetBtn.Enabled = false;
        }

        private void ActionAddUpdate_Click(object sender, EventArgs e)
        {
            if (ActionAddUpdate.Text == "Add")
            {
                var emp = new Employee
                {
                    NAME = NameBox.Text?.Trim(),
                    MOBILE = MobileBox.Text?.Trim(),
                    PASSWORD = PassBox.Text ?? "",
                    ADDRESS = Addressbox.Text?.Trim()
                };

                var rows = _employeeService.Register(emp);
                if (rows > 0)
                {
                    MessageBox.Show("Employee Saved Successfully!");
                    LoadEmployeesIntoGrid();
                    ResetEditForm();
                }
                else
                    MessageBox.Show("Save Failed!");
            }
            else
            {
                if (!int.TryParse(IDBox.Text, out var id))
                {
                    MessageBox.Show("No record selected to update.");
                    return;
                }

                var emp = new Employee
                {
                    ID = id,
                    NAME = NameBox.Text?.Trim(),
                    MOBILE = MobileBox.Text?.Trim(),
                    ADDRESS = Addressbox.Text?.Trim()
                };

                var rows = _employeeService.Update(emp);
                if (rows > 0)
                {
                    MessageBox.Show("Employee updated.");
                    LoadEmployeesIntoGrid();
                    ResetEditForm();
                }
                else
                    MessageBox.Show("Update failed.");
            }
        }

        private void EditResetBtn_Click(object sender, EventArgs e)
        {
            ResetEditForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = (SearchNameBox.Text ?? "").Trim();
            string mobile = (SearchMobileBox.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(mobile))
            {
                LoadEmployeesIntoGrid();
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _employeeService.Search(name, mobile);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchNameBox.Text = "";
            SearchMobileBox.Text = "";
            LoadEmployeesIntoGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var adm = new AdminView();
            adm.Show();
            Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var col = dataGridView1.Columns[e.ColumnIndex].Name;
            if (col != "View_Col" && col != "Edit_Col" && col != "Delete_Col")
                return;

            var emp = dataGridView1.Rows[e.RowIndex].DataBoundItem as Employee;
            if (emp == null)
                return;

            if (col == "View_Col")
            {
                MessageBox.Show(
                    $"ID: {emp.ID}\nName: {emp.NAME}\nMobile: {emp.MOBILE}\nAddress: {emp.ADDRESS}",
                    "Employee");
            }
            else if (col == "Edit_Col")
            {
                var fresh = _employeeService.GetById(emp.ID);
                if (fresh != null)
                {
                    IDBox.Text = fresh.ID.ToString();
                    NameBox.Text = fresh.NAME;
                    MobileBox.Text = fresh.MOBILE;
                    Addressbox.Text = fresh.ADDRESS;

                    PassBox.Text = "";
                    PassBox.Enabled = false;

                    ActionAddUpdate.Text = "Update";
                    EditResetBtn.Enabled = true;
                }
            }
            else if (col == "Delete_Col")
            {
                if (MessageBox.Show($"Delete employee #{emp.ID}?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                var rows = _employeeService.Delete(emp.ID);
                if (rows > 0)
                {
                    LoadEmployeesIntoGrid();
                    if (IDBox.Text == emp.ID.ToString())
                        ResetEditForm();
                }
                else
                    MessageBox.Show("Delete failed.");
            }
        }
    }
}
