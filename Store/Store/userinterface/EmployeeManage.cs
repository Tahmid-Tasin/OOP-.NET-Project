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

            button1.Text = "Add";
            EditResetBtn.Enabled = false;
            PassBox.Enabled = true;

            LoadEmployeesIntoGrid();
        }

        private void LoadEmployeesIntoGrid()
        {
            var list = _employeeService.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void ResetEditForm()
        {
            IDBox.Text = "";
            NameBox.Text = "";
            MobileBox.Text = "";
            PassBox.Text = "";
            Addressbox.Text = "";
            PassBox.Enabled = true;
            button1.Text = "Add";
            EditResetBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Add")
            {
                var emp = new Employee
                {
                    NAME = NameBox.Text,
                    MOBILE = MobileBox.Text,
                    PASSWORD = PassBox.Text,
                    ADDRESS = Addressbox.Text
                };

                int rows = _employeeService.Register(emp);
                if (rows > 0)
                {
                    MessageBox.Show("Employee Saved Successfully!");
                    LoadEmployeesIntoGrid();
                    ResetEditForm();
                }
                else
                {
                    MessageBox.Show("Save Failed!");
                }
            }
            else // Update
            {
                if (!int.TryParse(IDBox.Text, out int id))
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
                    // password intentionally not updated here
                };

                int rows = _employeeService.Update(emp);
                if (rows > 0)
                {
                    MessageBox.Show("Employee updated.");
                    LoadEmployeesIntoGrid();
                    ResetEditForm();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
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

            var list = _employeeService.Search(name, mobile);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchNameBox.Text = "";
            SearchMobileBox.Text = "";
            LoadEmployeesIntoGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminView adm = new AdminView();
            adm.Show();
            Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName != "View_Col" && colName != "Edit_Col" && colName != "Delete_Col") return;

            var emp = dataGridView1.Rows[e.RowIndex].DataBoundItem as Employee;
            if (emp == null) return;

            if (colName == "View_Col")
            {
                MessageBox.Show($"ID: {emp.ID}\nName: {emp.NAME}\nMobile: {emp.MOBILE}\nAddress: {emp.ADDRESS}", "Employee");
            }
            else if (colName == "Edit_Col")
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
                    button1.Text = "Update";
                    EditResetBtn.Enabled = true;
                }
            }
            else if (colName == "Delete_Col")
            {
                if (MessageBox.Show($"Delete employee #{emp.ID} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                int rows = _employeeService.Delete(emp.ID);
                if (rows > 0)
                {
                    LoadEmployeesIntoGrid();
                    if (IDBox.Text == emp.ID.ToString())
                        ResetEditForm();
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }
            }
        }
    }
}
