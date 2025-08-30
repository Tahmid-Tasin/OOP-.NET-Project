using System;
using System.Drawing;
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

            button5.Enabled = false;
            PassBox.Enabled = true;

            LoadEmployeesIntoGrid();
        }

        private void LoadEmployeesIntoGrid()
        {
            var list = _employeeService.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
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
            }
            else
            {
                MessageBox.Show("Save Failed!");
            }

            IDBox.Text = "";
            NameBox.Text = "";
            MobileBox.Text = "";
            PassBox.Text = "";
            Addressbox.Text = "";
            button5.Enabled = false;
            PassBox.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
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
                // Password intentionally not updated here
            };

            int rows = _employeeService.Update(emp);
            if (rows > 0)
            {
                MessageBox.Show("Employee updated.");
                LoadEmployeesIntoGrid();
                button5.Enabled = false;
                PassBox.Enabled = true;

                IDBox.Text = "";
                NameBox.Text = "";
                MobileBox.Text = "";
                PassBox.Text = "";
                Addressbox.Text = "";
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(IDBox.Text, out int id))
            {
                MessageBox.Show("Select a row or use the Delete action in the grid.");
                return;
            }

            if (MessageBox.Show($"Delete employee #{id} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            int rows = _employeeService.Delete(id);
            if (rows > 0)
            {
                MessageBox.Show("Deleted.");
                LoadEmployeesIntoGrid();

                IDBox.Text = "";
                NameBox.Text = "";
                MobileBox.Text = "";
                PassBox.Text = "";
                Addressbox.Text = "";
                button5.Enabled = false;
                PassBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Delete failed.");
            }
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

        // Grid: handle View/Edit/Delete button columns
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "View_Col" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Edit_Col" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Delete_Col")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var emp = row.DataBoundItem as Employee;
                if (emp == null) return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "View_Col")
                {
                    MessageBox.Show($"ID: {emp.ID}\nName: {emp.NAME}\nMobile: {emp.MOBILE}\nAddress: {emp.ADDRESS}", "Employee");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit_Col")
                {
                    var fresh = _employeeService.GetById(emp.ID);
                    if (fresh != null)
                    {
                        IDBox.Text = fresh.ID.ToString();
                        NameBox.Text = fresh.NAME;
                        MobileBox.Text = fresh.MOBILE;
                        Addressbox.Text = fresh.ADDRESS;

                        PassBox.Text = "";
                        PassBox.Enabled = false;   // disable password during edit
                        button5.Enabled = true;    // enable Update
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete_Col")
                {
                    if (MessageBox.Show($"Delete employee #{emp.ID} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    int rows = _employeeService.Delete(emp.ID);
                    if (rows > 0)
                    {
                        LoadEmployeesIntoGrid();
                        if (IDBox.Text == emp.ID.ToString())
                        {
                            IDBox.Text = "";
                            NameBox.Text = "";
                            MobileBox.Text = "";
                            PassBox.Text = "";
                            Addressbox.Text = "";
                            button5.Enabled = false;
                            PassBox.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Delete failed.");
                    }
                }
            }
        }
    }
}
