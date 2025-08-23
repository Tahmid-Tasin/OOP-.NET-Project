using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            EmployeeClass emp = new EmployeeClass();
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
    }
}
