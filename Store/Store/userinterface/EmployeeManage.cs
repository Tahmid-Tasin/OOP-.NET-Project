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
            LoadEmployeesIntoGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.NAME = NameBox.Text;
            emp.MOBILE = MobileBox.Text;
            emp.PASSWORD = PassBox.Text;
            emp.ADDRESS = Addressbox.Text;

            int rows = _employeeService.Register(emp);

            if (rows > 0)
            {
                MessageBox.Show("Employee Saved Successfully!");
                LoadEmployeesIntoGrid();
            }
            else
                MessageBox.Show("Save Failed!");

            NameBox.Text = "";
            MobileBox.Text = "";
            PassBox.Text = "";
            Addressbox.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminView adm = new AdminView();
            adm.Show();
            Visible = false;
        }

        private void LoadEmployeesIntoGrid()
        {
            var list = _employeeService.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
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
    }
}
