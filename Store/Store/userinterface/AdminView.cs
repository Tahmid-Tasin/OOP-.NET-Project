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
            // Optionally load a default page, e.g. Dashboard
            LoadContent(new StockView()); 
        }

        // Generic loader for child forms inside central panel
        private void LoadContent(Form childForm)
        {
            contentPanel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void button7_Click(object sender, EventArgs e) // Products
        {
            LoadContent(new ProductManageView());
        }

        private void button6_Click(object sender, EventArgs e) // Review
        {
            MessageBox.Show("Review module not implemented yet.");
        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            LoadContent(new EmployeeManage());
        }

        private void button5_Click(object sender, EventArgs e) // Stock
        {
            LoadContent(new StockView());
        }

        private void button4_Click(object sender, EventArgs e) // Dashboard
        {
            MessageBox.Show("Dashboard placeholder.");
        }

        private void button2_Click(object sender, EventArgs e) // VIP Customers
        {
            MessageBox.Show("VIP Customers module not implemented yet.");
        }

        private void button1_Click(object sender, EventArgs e) // Logout
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void OutletBtn_Click(object sender, EventArgs e)
        {
            LoadContent(new OutletManageView());
        }
    }
}
