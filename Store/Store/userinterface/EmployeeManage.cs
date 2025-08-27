using System;
using System.Windows.Forms;

namespace Store
{
    public partial class EmployeeManage : Form
    {
        public EmployeeManage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.NAME = NameBox.Text;
            emp.ID = Convert.ToInt32(IDBox.Text);
            emp.MOBILE = MobileBox.Text;
            emp.PASSWORD = PassBox.Text;
            emp.ADDRESS = Addressbox.Text;

            NameBox.Text = "";
            IDBox.Text = "";
            MobileBox.Text = "";
            PassBox.Text = "";
            Addressbox.Text = "";

            emp.ConnectDB();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminView adm = new AdminView();
            adm.Show();
            Visible = false;
        }
    }
}
