using System;
using System.Windows.Forms;

using Store.userinterface;

namespace Store
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void AdminView_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var productView = new ProductManageView();
            productView.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            EmployeeManage emp = new EmployeeManage();
            emp.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        private void OutletBtn_Click(object sender, EventArgs e)
        {
            var outlet = new OutletManageView();
            outlet.Show();
            this.Visible = false;
        }
    }
}
