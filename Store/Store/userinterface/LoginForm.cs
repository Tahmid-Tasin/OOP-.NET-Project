using System;
using System.Windows.Forms;

namespace Store
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserComboBox.Items.Add("Admin");
            UserComboBox.Items.Add("Cashier");
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
                Admin admin = new Admin();
                admin.verify(UserNameBox.Text,pwBox.Text);
                this.Visible = false;
                AdminView ad = new AdminView();
                ad.Show();
                Visible = false;
            }
        }
    }
}
