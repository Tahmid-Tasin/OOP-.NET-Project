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
        private readonly InventoryService _inventoryService;

        // Key: (CompanyId, BranchId, ProductId)  -> Quantity
        private readonly Dictionary<Tuple<int, int, int>, int> _cart =
            new Dictionary<Tuple<int, int, int>, int>();

        private int _selectedCompanyId = 0;
        private int _selectedBranchId = 0;

        // slide cart state
        private bool _cartOpen = false;
        private int _cartTargetWidth = 360;

        public CustomerCartView()
        {
            InitializeComponent();

            _productService = new ProductService();
            _categoryRepository = new CategoryRepository();
            _companyService = new CompanyService();
            _branchService = new BranchService();
            _inventoryService = new InventoryService();

            LoadCompanies();
            LoadCategories();

            cbFilterToggle.SelectedIndex = 0; // Hide filters by default

            // header cart label opens the panel
            lblCart.Cursor = Cursors.Hand;
            lblCart.Click += (s, e) => ToggleCart(!_cartOpen);

            // chevron toggle
            btnCartOpen.Click += (s, e) => ToggleCart(!_cartOpen);

            // animation timer
            cartTimer.Interval = 12;
            cartTimer.Tick += CartTimer_Tick;

            // footer buttons
            btnClearCart.Click += BtnClearCart_Click;
            btnPlaceOrder.Click += BtnPlaceOrder_Click;

            // keep row width responsive
            cartItemsFlow.Resize += (s, e) => ResizeCartRows();
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

            // Search inputs
            string name = txtSearchName.Text.Trim();
            string brand = txtSearchBrand.Text.Trim();
            string barcode = txtSearchBarcode.Text.Trim();
            int selId = cbCategory.SelectedValue is int v ? v : 0;
            int? categoryId = selId == 0 ? (int?)null : selId;

            // Fetch inventory items for this company + branch
            var inventories = _inventoryService.Search(
                companyId: _selectedCompanyId,
                branchId: _selectedBranchId
            );

            // apply optional client-side filters by product attributes, if provided
            if (!string.IsNullOrWhiteSpace(name))
                inventories = inventories.Where(i => i.Product != null && i.Product.NAME != null &&
                                                     i.Product.NAME.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (!string.IsNullOrWhiteSpace(brand))
                inventories = inventories.Where(i => i.Product != null && i.Product.BRAND != null &&
                                                     i.Product.BRAND.IndexOf(brand, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (!string.IsNullOrWhiteSpace(barcode))
                inventories = inventories.Where(i => i.Product != null && i.Product.BARCODE != null &&
                                                     i.Product.BARCODE.IndexOf(barcode, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (categoryId.HasValue)
                inventories = inventories.Where(i => i.Product != null && i.Product.CATEGORY_ID == categoryId.Value).ToList();

            foreach (var inv in inventories)
            {
                var product = inv.Product;
                if (product == null) continue;

                var key = Tuple.Create(_selectedCompanyId, _selectedBranchId, product.ID);

                var card = new ProductCardControl();
                card.Bind(product, _cart.TryGetValue(key, out var q) ? q : 0);
                card.Tag = key; // keep key for sync
                card.QuantityChanged += (s, qty) =>
                {
                    var k = (Tuple<int, int, int>)card.Tag;
                    if (qty <= 0)
                    {
                        if (_cart.ContainsKey(k)) _cart.Remove(k);
                    }
                    else
                    {
                        _cart[k] = qty;
                    }

                    UpdateCartBadge();
                    RenderCart();

                    if (_cart.Count > 0 && !_cartOpen)
                        ToggleCart(true);
                    if (_cart.Count == 0 && _cartOpen)
                        ToggleCart(false);
                };

                flowProducts.Controls.Add(card);
            }

            flowProducts.ResumeLayout();
        }

        private void UpdateCartBadge()
        {
            int total = _cart.Values.Sum();
            lblCart.Text = "Cart: " + total;

            decimal grand = 0m;
            foreach (var kv in _cart)
            {
                var pid = kv.Key.Item3;
                var qty = kv.Value;
                var p = _productService.GetById(pid);
                if (p != null) grand += p.PRICE * qty;
            }
            lblCartTotal.Text = "৳ " + grand.ToString("N2");
        }

        private void RenderCart()
        {
            cartItemsFlow.SuspendLayout();
            cartItemsFlow.Controls.Clear();

            decimal subtotal = 0m;
            int totalItems = 0;

            foreach (var kv in _cart)
            {
                var compId = kv.Key.Item1;
                var brId = kv.Key.Item2;
                var prId = kv.Key.Item3;
                var qty = kv.Value;

                var company = _companyService.GetById(compId);
                var branch = _branchService.GetById(brId);
                var product = _productService.GetById(prId);
                if (product == null) continue;

                decimal lineTotal = product.PRICE * qty;
                subtotal += lineTotal;
                totalItems += qty;

                var row = BuildCartRow(
                    company != null ? company.Name : "Company",
                    branch != null ? branch.Name : "Branch",
                    product,
                    qty,
                    kv.Key
                );

                // Add newest on top inside FlowLayoutPanel
                cartItemsFlow.Controls.Add(row);
                cartItemsFlow.Controls.SetChildIndex(row, 0);
            }

            lblCartSubtotal.Text = "Subtotal: ৳ " + subtotal.ToString("N2");
            lblCartItems.Text = "Items: " + totalItems.ToString();

            ResizeCartRows();
            cartItemsFlow.ResumeLayout();
        }

        private Control BuildCartRow(string companyName, string branchName, Product product, int qty,
            Tuple<int, int, int> key)
        {
            var row = new CartRowControl();
            row.Margin = new Padding(0, 0, 0, 8);
            row.Bind(
                key.Item1, companyName,
                key.Item2, branchName,
                product, qty
            );

            row.RemoveRequested += () =>
            {
                if (_cart.ContainsKey(key)) _cart.Remove(key);
                UpdateCartBadge();
                RenderCart();
                SyncVisibleCardsForKey(key);

                if (_cart.Count == 0) ToggleCart(false);
            };

            return row;
        }

        private void ResizeCartRows()
        {
            // Make rows fit the slide panel width nicely
            int pad = cartItemsFlow.Padding.Left + cartItemsFlow.Padding.Right + 6;
            int target = Math.Max(220, cartPanel.ClientSize.Width - pad);
            foreach (Control c in cartItemsFlow.Controls)
            {
                c.Width = target;
            }
        }

        private void SyncVisibleCardsForKey(Tuple<int, int, int> key)
        {
            // If the removed item is currently visible in the grid (same comp/branch),
            // set its card quantity back to 0
            if (_selectedCompanyId == key.Item1 && _selectedBranchId == key.Item2)
            {
                foreach (Control c in flowProducts.Controls)
                {
                    var card = c as ProductCardControl;
                    if (card == null) continue;
                    var tagKey = card.Tag as Tuple<int, int, int>;
                    if (tagKey == null) continue;
                    if (tagKey.Item3 == key.Item3)
                    {
                        card.SetQuantity(0);
                        break;
                    }
                }
            }
        }

        private void ToggleCart(bool open)
        {
            _cartOpen = open;
            cartTimer.Start();
            btnCartOpen.Text = open ? "»" : "«"; // show opposite arrow as "close" hint
        }

        private void CartTimer_Tick(object sender, EventArgs e)
        {
            int step = 24;
            if (_cartOpen)
            {
                if (cartPanel.Width < _cartTargetWidth)
                {
                    cartPanel.Width = Math.Min(_cartTargetWidth, cartPanel.Width + step);
                }
                else
                {
                    cartTimer.Stop();
                    ResizeCartRows();
                }
            }
            else
            {
                if (cartPanel.Width > 0)
                {
                    cartPanel.Width = Math.Max(0, cartPanel.Width - step);
                }
                else
                {
                    cartTimer.Stop();
                    ResizeCartRows();
                }
            }
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            _cart.Clear();
            UpdateCartBadge();
            RenderCart();
            // reset visible product cards
            foreach (Control c in flowProducts.Controls)
            {
                if (c is ProductCardControl card) card.SetQuantity(0);
            }
            ToggleCart(false);
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            // placeholder — will be replaced in Step 06 (DB-backed order)
            MessageBox.Show("Place Order is not implemented yet.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var selected = cbCompany.SelectedItem as ComboBoxItem;
            if (selected != null && selected.Id > 0)
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
            var selected = cbBranch.SelectedItem as ComboBoxItem;
            if (selected != null && selected.Id > 0)
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
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboBoxItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString() { return Name; }
        }
    }
}
