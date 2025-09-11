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
        private readonly int _companyId;   // 👈 link to manager's company

        // Default fallback
        public AdminView() : this("Unknown", "User", "", 0) { }

        // Pass: display name, role, company name, company id
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
            // Header (right)
            lblUserName.Text = _displayName;
            lblUserRole.Text = _role;

            // Header (left) - company name
            lblCompanyName.Text = string.IsNullOrWhiteSpace(_companyName)
                ? "No Company"
                : _companyName;

            // Role-based menu
            if (_role == "Admin")
            {
                // Admin sees Dashboard, Company, Managers, Products
                button4.Visible = true;      // Dashboard
                CompanyBtn.Visible = true;   // Company
                EmployeeBtn.Visible = true;  // Managers
                button7.Visible = true;      // Products

                // Hide Stock + Review + Branch
                button5.Visible = false;
                button6.Visible = false;
                BranchBtn.Visible = false;

                button4.PerformClick(); // Default → Dashboard
            }
            else if (_role == "Company Manager")
            {
                // Company Managers see Stock + Branch
                button4.Visible = false;
                CompanyBtn.Visible = false;
                EmployeeBtn.Visible = false;
                button7.Visible = false;
                button6.Visible = false;

                button5.Visible = true;      // Stock
                BranchBtn.Visible = true;    // Branches

                button5.PerformClick(); // Default → Stock
            }
            else
            {
                // Fallback: only Stock
                button4.Visible = false;
                CompanyBtn.Visible = false;
                EmployeeBtn.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
                BranchBtn.Visible = false;

                button5.Visible = true;
                button5.PerformClick();
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
        private void button5_Click(object sender, EventArgs e) => LoadContent(new StockView());
        private void button4_Click(object sender, EventArgs e) => MessageBox.Show("Dashboard placeholder.");
        private void button2_Click(object sender, EventArgs e) => MessageBox.Show("VIP Customers module not implemented yet.");

        private void BranchBtn_Click(object sender, EventArgs e)
        {
            // Pass companyId into BranchManage
            LoadContent(new BranchManage(_companyId));
        }

        private void button1_Click(object sender, EventArgs e) // Logout
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void CompanyBtn_Click(object sender, EventArgs e) => LoadContent(new CompanyManage());
    }
}
