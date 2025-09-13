// File: userinterface/LoginForm.cs
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

            try
            {
                if (pwBox.Multiline) pwBox.Multiline = false;
                pwBox.UseSystemPasswordChar = true;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserComboBox.Items.Clear();
            UserComboBox.Items.Add("Admin");
            UserComboBox.Items.Add("Company Manager");
            UserComboBox.Items.Add("Customer");
            ApplyDefaultRoleSelection();
            ResetInputs();
        }

        private void ApplyDefaultRoleSelection()
        {
            string wanted = UserSession.LastLoginUserType ?? "Customer";
            int idx = -1;
            for (int i = 0; i < UserComboBox.Items.Count; i++)
            {
                if (string.Equals(UserComboBox.Items[i].ToString(), wanted, StringComparison.OrdinalIgnoreCase))
                { idx = i; break; }
            }
            if (idx >= 0) UserComboBox.SelectedIndex = idx;
            else if (UserComboBox.Items.Count > 0)
            {
                int def = UserComboBox.Items.IndexOf("Customer");
                UserComboBox.SelectedIndex = def >= 0 ? def : 0;
            }
        }

        private void ResetInputs()
        {
            UserNameBox.Clear();
            pwBox.Clear();
            UserNameBox.Focus();
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e) { }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            var frm = new CustomerCreateForm();
            frm.Show();
            Visible = false;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string user = (UserNameBox.Text ?? "").Trim();
            string pass = (pwBox.Text ?? "").Trim();
            string selected = (UserComboBox.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(selected))
            {
                MessageBox.Show("Please select a user type");
                return;
            }
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please enter username/email and password");
                return;
            }

            UserSession.LastLoginUserType = selected;

            try
            {
                if (selected == "Customer")
                {
                    if (_customerService.VerifyLogin(user, pass))
                    {
                        var c = _customerService.GetByLoginKey(user);
                        UserSession.SignIn(UserIdentity.FromCustomer(c));
                        AfterSuccessfulLogin();
                        return;
                    }
                }
                else if (selected == "Admin")
                {
                    if (_adminService.VerifyLogin(user, pass))
                    {
                        var a = _adminService.GetByUserName(user);
                        UserSession.SignIn(UserIdentity.FromAdmin(a, email: null));
                        AfterSuccessfulLogin();
                        return;
                    }
                }
                else if (selected == "Company Manager")
                {
                    if (_employeeService.VerifyLoginFlexible(user, pass))
                    {
                        var emp = _employeeService.GetByLoginKey(user);
                        UserSession.SignIn(UserIdentity.FromManager(emp));
                        AfterSuccessfulLogin();
                        return;
                    }
                }

                MessageBox.Show("Invalid username or password");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }

        private void AfterSuccessfulLogin()
        {
            // If opened by AdminView during logout:
            if (this.Owner is AdminView)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                this.Hide();
                new AdminView().Show();
            }
        }
    }
}
