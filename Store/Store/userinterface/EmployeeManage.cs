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
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.NAME     = NameBox.Text;
            emp.MOBILE   = MobileBox.Text;
            emp.PASSWORD = PassBox.Text;
            emp.ADDRESS  = Addressbox.Text;
            
            int rows = _employeeService.Register(emp);

            if (rows > 0)
                MessageBox.Show("Employee Saved Successfully!");
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
    }
}
