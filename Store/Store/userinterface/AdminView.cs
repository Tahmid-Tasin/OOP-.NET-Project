using System;
using System.Windows.Forms;
using Store.userinterface;

namespace Store
{
    public partial class AdminView : Form
    {
        private readonly string _displayName;
        private readonly string _role;
        private readonly string _companyName;
        private readonly int _companyId;

        public AdminView() : this("Unknown", "User", "", 0) { }

        public AdminView(string displayName, string role, string companyName = "", int companyId = 0)
        {
            _displayName = string.IsNullOrWhiteSpace(displayName) ? "Unknown" : displayName;
            _role = string.IsNullOrWhiteSpace(role) ? "User" : role;
            _companyName = companyName ?? "";
            _companyId = companyId;
            InitializeComponent();
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            lblUserName.Text = _displayName;
            lblUserRole.Text = _role;

            if (_role == "Company Manager")
            {
                lblCompanyName.Text = _companyName;
            }
            else
            {
                lblCompanyName.Visible = false;
            }

            if (_role == "Admin")
            {
                button4.Visible = true;
                CompanyBtn.Visible = true;
                EmployeeBtn.Visible = true;
                button7.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                BranchBtn.Visible = false;
                ProductsBtn.Visible = false;
                ItemsBtn.Visible = false;
                button4.PerformClick();
            }
            else if (_role == "Company Manager")
            {
                button4.Visible = false;
                CompanyBtn.Visible = false;
                EmployeeBtn.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
                ProductsBtn.Visible = false;
                ItemsBtn.Visible = false;
                button5.Visible = true;
                BranchBtn.Visible = true;
                button5.PerformClick();
            }
            else if (_role == "Customer")
            {
                button4.Visible = false;
                CompanyBtn.Visible = false;
                EmployeeBtn.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
                BranchBtn.Visible = false;
                button5.Visible = false;

                ProductsBtn.Text = "Purchase History";
                ItemsBtn.Text = "Products";

                ProductsBtn.Visible = true;
                ItemsBtn.Visible = true;

                // Auto-load customer products
                ItemsBtn.PerformClick();
            }
            else
            {
                button4.Visible = false;
                CompanyBtn.Visible = false;
                EmployeeBtn.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
                BranchBtn.Visible = false;
                button5.Visible = false;
                ProductsBtn.Visible = false;
                ItemsBtn.Visible = false;
            }
        }

        private void LoadContent(Form childForm)
        {
            contentPanel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void button7_Click(object sender, EventArgs e) => LoadContent(new ProductManageView());
        private void button6_Click(object sender, EventArgs e) => MessageBox.Show("Review module not implemented yet.");
        private void EmployeeBtn_Click(object sender, EventArgs e) => LoadContent(new EmployeeManage());
        private void button4_Click(object sender, EventArgs e) => MessageBox.Show("Dashboard placeholder.");
        private void button2_Click(object sender, EventArgs e) => MessageBox.Show("VIP Customers module not implemented yet.");
        private void button5_Click(object sender, EventArgs e) => LoadContent(new InventoryManage(_companyId));
        private void BranchBtn_Click(object sender, EventArgs e) => LoadContent(new BranchManage(_companyId));
        private void button1_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void CompanyBtn_Click(object sender, EventArgs e) => LoadContent(new CompanyManage());

        // Purchase history (for now just placeholder)
        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Purchase history will be added soon.");
        }

        // Load customer product/cart view
        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            LoadContent(new CustomerCartView());
        }
    }
}
