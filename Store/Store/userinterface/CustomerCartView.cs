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
        private readonly Dictionary<int, int> _cart = new Dictionary<int, int>();

        public CustomerCartView()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryRepository = new CategoryRepository();
            LoadCategories();
            cbFilterToggle.SelectedIndex = 1;
            LoadProducts();
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
            flowProducts.SuspendLayout();
            flowProducts.Controls.Clear();

            string name = txtSearchName.Text.Trim();
            string brand = txtSearchBrand.Text.Trim();
            string barcode = txtSearchBarcode.Text.Trim();
            int selId = cbCategory.SelectedValue is int v ? v : 0;
            int? categoryId = selId == 0 ? (int?)null : selId;

            var items = _productService.Search(
                string.IsNullOrWhiteSpace(name) ? null : name,
                string.IsNullOrWhiteSpace(brand) ? null : brand,
                string.IsNullOrWhiteSpace(barcode) ? null : barcode,
                null, null, categoryId
            );

            foreach (var p in items)
            {
                var card = new ProductCardControl();
                card.Bind(p, _cart.TryGetValue(p.ID, out var q) ? q : 0);
                card.QuantityChanged += (s, qty) =>
                {
                    if (qty <= 0)
                    {
                        if (_cart.ContainsKey(p.ID)) _cart.Remove(p.ID);
                    }
                    else
                    {
                        _cart[p.ID] = qty;
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
    }
}
