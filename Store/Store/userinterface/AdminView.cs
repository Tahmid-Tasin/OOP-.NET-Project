// File: userinterface/AdminView.cs
using System;
using System.Windows.Forms;
using Store.service;
using Store.userinterface;

namespace Store
{
    public partial class AdminView : Form
    {
        private bool _initialized;

        public AdminView()
        {
            InitializeComponent();
            this.Shown += AdminView_Shown;
            UserSession.OnChanged += HandleSessionChanged;
            HideAllRoleMenus();
        }

        private void AdminView_Shown(object sender, EventArgs e)
        {
            if (_initialized) return;
            _initialized = true;

            if (!(UserSession.Current?.IsAuthenticated ?? false))
            {
                using (var login = new LoginForm())
                {
                    Hide();
                    login.ShowDialog(this);
                }
                if (!(UserSession.Current?.IsAuthenticated ?? false))
                {
                    Close();
                    return;
                }
                Show();
            }

            InitForCurrentUser();
        }

        private void AdminView_Load(object sender, EventArgs e) { }

        private void HandleSessionChanged()
        {
            if (InvokeRequired) { BeginInvoke((Action)HandleSessionChanged); return; }
            InitForCurrentUser();
        }

        private void InitForCurrentUser()
        {
            var id = UserSession.Current ?? UserIdentity.Guest();

            lblUserName.Text = id.DisplayName;
            lblUserRole.Text = id.Role == UserRole.Manager ? "Company Manager" : id.Role.ToString();

            lblCompanyName.Visible = (id.Role == UserRole.Manager);
            if (lblCompanyName.Visible) lblCompanyName.Text = id.CompanyName ?? "Company";

            ApplyRoleVisibility(id.Role);

           // if (id.Role == UserRole.Admin)            button4.PerformClick();
            if (id.Role == UserRole.Manager)     button5.PerformClick();
            else if (id.Role == UserRole.Customer)    ItemsBtn.PerformClick();
        }

        private void HideAllRoleMenus()
        {
            button4.Visible = false;   // Dashboard
            CompanyBtn.Visible = false;
            EmployeeBtn.Visible = false;
            button7.Visible = false;   // Products (admin)
            reviewbtn.Visible = false;   // Review
            BranchBtn.Visible = false;
            button5.Visible = false;   // Stock
            ProductsBtn.Visible = false; // Purchase History (customer)
            ItemsBtn.Visible = false;    // Products (customer)
        }

        private void ApplyRoleVisibility(UserRole role)
        {
            HideAllRoleMenus();
            switch (role)
            {
                case UserRole.Admin:
                    button4.Visible = true;
                    CompanyBtn.Visible = true;
                    EmployeeBtn.Visible = true;
                    button7.Visible = true;
                    reviewbtn.Visible = true;
                    break;
                case UserRole.Manager:
                    button5.Visible = true;
                    BranchBtn.Visible = true;
                    break;
                case UserRole.Customer:
                    ProductsBtn.Text = "Purchase History";
                    ItemsBtn.Text = "Products";
                    ProductsBtn.Visible = true;
                    ItemsBtn.Visible = true;
                    reviewbtn.Visible = true;
                    break;
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
       
        private void EmployeeBtn_Click(object sender, EventArgs e) => LoadContent(new EmployeeManage());
       // private void button4_Click(object sender, EventArgs e) => MessageBox.Show("Dashboard placeholder.");
        private void button2_Click(object sender, EventArgs e) => MessageBox.Show("VIP Customers module not implemented yet.");

        private void button5_Click(object sender, EventArgs e)
        {
            var id = UserSession.Current;
            int companyId = id?.CompanyId ?? 0;
            LoadContent(new InventoryManage(companyId));
        }

        private void BranchBtn_Click(object sender, EventArgs e)
        {
            var id = UserSession.Current;
            int companyId = id?.CompanyId ?? 0;
            LoadContent(new BranchManage(companyId));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.SignOut();
            using (var login = new LoginForm())
            {
                Hide();
                login.ShowDialog(this);
            }
            if (UserSession.Current?.IsAuthenticated == true)
            {
                Show();
                InitForCurrentUser();
            }
            else
            {
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void CompanyBtn_Click(object sender, EventArgs e) => LoadContent(new CompanyManage());
        
        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            var id = UserSession.Current;
            if (id != null && id.Role == UserRole.Customer && id.UserId.HasValue)
            {
                LoadContent(new PurchaseHistoryForm(id.UserId.Value));
            }
            else
            {
                MessageBox.Show("Only customers can view purchase history.", "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reviewbtn_Click(object sender, EventArgs e)
        {
            var id = UserSession.Current;
            if (id != null && id.Role == UserRole.Customer && id.UserId.HasValue)
            {
               // LoadContent(new PurchaseHistoryForm(id.UserId.Value));
               ReviewScene rs = new ReviewScene();
                rs.Show();
                this.Visible = false;
            }
            else
            {

                AdminReviewPage ad = new AdminReviewPage();
                this.Visible = false;
                ad.Show();
            }
        }

        private void ItemsBtn_Click(object sender, EventArgs e) => LoadContent(new CustomerCartView());

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UserSession.OnChanged -= HandleSessionChanged;
            base.OnFormClosed(e);
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Dashboard da = new Dashboard();
            da.Show();
            this.Close();
        }


    }
}
