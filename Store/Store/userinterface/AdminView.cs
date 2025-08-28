using System;
using System.Windows.Forms;

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
    }
}
