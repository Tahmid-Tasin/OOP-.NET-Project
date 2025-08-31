using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.userinterface
{
    public partial class SuperShopList : Form
    {
        public SuperShopList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Supershop.Items.Add("Shawpno");
            Supershop.Items.Add("Agora");
            Supershop.Items.Add("Unimart");
            Supershop.Items.Add("Mina Bazar");
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var st = new StockView();
            st.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ad = new AdminView();
            ad.Show();
            Visible = false;
        }
    }
}
