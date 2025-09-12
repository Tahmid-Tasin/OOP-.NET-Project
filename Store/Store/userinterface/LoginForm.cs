using System;
using System.Windows.Forms;

using Store.service;
using Store.userinterface;

namespace Store
{
    public partial class LoginForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly AdminService _adminService;
        private readonly EmployeeService _employeeService;

        public LoginForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _adminService = new AdminService();
            _employeeService = new EmployeeService(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserComboBox.Items.Add("Admin");
            UserComboBox.Items.Add("Company Manager");
            UserComboBox.Items.Add("Customer");
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            var frm = new CustomerCreateForm();
            frm.Show();
            Visible = false;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string user = UserNameBox.Text.Trim();
            string pass = pwBox.Text;

            if (UserComboBox.Text == "Customer")
            {
                bool ok = _customerService.VerifyLogin(user, pass);
                if (ok)
                {
                    var customer = _customerService.GetByUserName(user);
                    string displayName = customer != null
                        ? customer.FullName
                        : user;

                    this.Hide();
                    new AdminView(displayName, "Customer").Show();
                }
                else MessageBox.Show("Invalid username or password");
            }
            else if (UserComboBox.Text == "Admin")
            {
                bool ok = _adminService.VerifyLogin(user, pass);
                if (ok)
                {
                    var admin = _adminService.GetByUserName(user);
                    string displayName = admin != null
                        ? $"{(admin.FirstName ?? "").Trim()} {(admin.LastName ?? "").Trim()}".Trim()
                        : user;

                    this.Hide();
                    new AdminView(displayName, "Admin").Show();
                }
                else MessageBox.Show("Invalid username or password");
            }
            else if (UserComboBox.Text == "Company Manager")
            {
                bool ok = _employeeService.VerifyLogin(user, pass);
                if (ok)
                {
                    var emp = _employeeService.GetByEmail(user);
                    string displayName  = emp?.NAME ?? user;
                    string companyName  = emp?.Company?.Name ?? "Company";
                    int companyId       = emp?.CompanyId ?? 0;

                    this.Hide();
                    new AdminView(displayName, "Company Manager", companyName, companyId).Show();
                }
                else
                {
                    MessageBox.Show("Invalid email or password");
                }
            }
            else
            {
                MessageBox.Show("Please select a user type");
            }
        }
    }
}
