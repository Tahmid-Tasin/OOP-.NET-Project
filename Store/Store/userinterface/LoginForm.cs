using System;
using System.Windows.Forms;

using Store.service;

namespace Store
{
    public partial class LoginForm : Form
    {
        private readonly AdminService _adminService;
        public LoginForm()
        {
            InitializeComponent();
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
            AdminCreateForm frm = new AdminCreateForm();
            frm.Show();
            Visible = false;

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserComboBox.SelectedIndex == 0)
            {
                string user = UserNameBox.Text.Trim();
                string pass = pwBox.Text;

                bool ok = _adminService.VerifyLogin(user, pass);
                if (ok)
                {
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    AdminView ad = new AdminView();
                    ad.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
