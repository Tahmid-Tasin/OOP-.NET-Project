using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Store.Repository;
using Store.service;

namespace Store.userinterface
{
    public partial class CustomerCartView : Form
    {
        private readonly ProductService _productService;
        private readonly CategoryRepository _categoryRepository;
        private readonly CompanyService _companyService;
        private readonly BranchService _branchService;

        // Key: (CompanyId, BranchId, ProductId)
// Key: (CompanyId, BranchId, ProductId)
        private readonly Dictionary<Tuple<int, int, int>, int> _cart = 
            new Dictionary<Tuple<int, int, int>, int>();


        private int _selectedCompanyId = 0;
        private int _selectedBranchId = 0;

        public CustomerCartView()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryRepository = new CategoryRepository();
            _companyService = new CompanyService();
            _branchService = new BranchService();

            LoadCompanies();
            LoadCategories();

            cbFilterToggle.SelectedIndex = 0; // Hide filters by default
        }

        private void LoadCompanies()
        {
            var companies = _companyService.GetAll();
            cbCompany.Items.Clear();
            cbCompany.Items.Add(new ComboBoxItem(0, "Select Company"));
            foreach (var c in companies)
            {
                cbCompany.Items.Add(new ComboBoxItem(c.Id, c.Name));
            }
            cbCompany.SelectedIndex = 0;
        }

        private void LoadBranches(int companyId)
        {
            var branches = _branchService.GetByCompany(companyId);
            cbBranch.Items.Clear();
            cbBranch.Items.Add(new ComboBoxItem(0, "Select Branch"));
            foreach (var b in branches)
            {
                cbBranch.Items.Add(new ComboBoxItem(b.Id, b.Name));
            }
            cbBranch.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            var cats = _categoryRepository.GetAll();
            cats.Insert(0, new Store.Repository.Category { ID = 0, NAME = "All" });
            cbCategory.DisplayMember = "NAME";
            cbCategory.ValueMember = "ID";
            cbCategory.DataSource = cats;
            cbCategory.SelectedValue = 0;
        }

        private void LoadProducts()
        {
            if (_selectedCompanyId == 0 || _selectedBranchId == 0)
            {
                flowProducts.Controls.Clear();
                return;
            }

            flowProducts.SuspendLayout();
            flowProducts.Controls.Clear();

            // Fetch inventory items for this company + branch
            var inventories = new InventoryService().Search(
                companyId: _selectedCompanyId,
                branchId: _selectedBranchId
            );

            foreach (var inv in inventories)
            {
                var product = inv.Product; // Product comes from Inventory
                var key = Tuple.Create(_selectedCompanyId, _selectedBranchId, product.ID);

                var card = new ProductCardControl();
                card.Bind(product, _cart.TryGetValue(key, out var q) ? q : 0);
                card.QuantityChanged += (s, qty) =>
                {
                    if (qty <= 0)
                    {
                        if (_cart.ContainsKey(key)) _cart.Remove(key);
                    }
                    else
                    {
                        _cart[key] = qty;
                    }
                    UpdateCartBadge();
                };
                flowProducts.Controls.Add(card);
            }

            flowProducts.ResumeLayout();
        }


        private void UpdateCartBadge()
        {
            int total = _cart.Values.Sum();
            lblCart.Text = "Cart: " + total;
        }

        private void cbFilterToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterPanel.Visible = cbFilterToggle.SelectedIndex == 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            txtSearchBrand.Text = "";
            txtSearchBarcode.Text = "";
            cbCategory.SelectedValue = 0;
            LoadProducts();
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCompany.SelectedItem is ComboBoxItem selected && selected.Id > 0)
            {
                _selectedCompanyId = selected.Id;
                LoadBranches(_selectedCompanyId);
            }
            else
            {
                _selectedCompanyId = 0;
                cbBranch.Items.Clear();
                flowProducts.Controls.Clear();
            }
        }

        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBranch.SelectedItem is ComboBoxItem selected && selected.Id > 0)
            {
                _selectedBranchId = selected.Id;
                LoadProducts();
            }
            else
            {
                _selectedBranchId = 0;
                flowProducts.Controls.Clear();
            }
        }

        // helper for ComboBox
        private class ComboBoxItem
        {
            public int Id { get; }
            public string Name { get; }

            public ComboBoxItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString() => Name;
        }
    }
}
