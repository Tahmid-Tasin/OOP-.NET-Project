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
        public LoginForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _adminService = new AdminService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserComboBox.Items.Add("Admin");
            UserComboBox.Items.Add("Manager");
            UserComboBox.Items.Add("Customer");
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            CustomerCreateForm frm = new CustomerCreateForm();
            frm.Show();
            Visible = false;

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserComboBox.Text == "Customer")
            {
                string user = UserNameBox.Text.Trim();
                string pass = pwBox.Text;

                bool ok = _customerService.VerifyLogin(user, pass);
                if (ok)
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    CustomerView ad = new CustomerView();
                    ad.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

            else if (UserComboBox.Text == "Admin")
            {
                string us = UserNameBox.Text.Trim();
                string pa = pwBox.Text;
                bool ok = _adminService.VerifyLogin(us, pa);
                if (ok)
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    AdminView cs = new AdminView();
                    cs.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }

            else
            {
                MessageBox.Show("Please select an user type");
            }
        }
    }
}
