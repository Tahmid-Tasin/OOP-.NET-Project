// NEW UI: Store/userinterface/OrderSummaryForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class OrderSummaryForm : Form
    {
        private readonly List<CartLine> _lines;
        private readonly OrderHistoryService _orderService;
        private readonly CompanyService _companyService;
        private readonly BranchService _branchService;
        private readonly ProductService _productService;

        private decimal _subtotal;

        public OrderSummaryForm(Dictionary<Tuple<int,int,int>, int> cartSnapshot)
        {
            InitializeComponent();

            _orderService = new OrderHistoryService();
            _companyService = new CompanyService();
            _branchService  = new BranchService();
            _productService = new ProductService();

            _lines = BuildLines(cartSnapshot);
            BindGrid();
            CalcTotals();

            btnPay.Click += BtnPay_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private List<CartLine> BuildLines(Dictionary<Tuple<int,int,int>, int> cart)
        {
            var list = new List<CartLine>();
            foreach (var kv in cart)
            {
                int compId = kv.Key.Item1;
                int brId   = kv.Key.Item2;
                int prodId = kv.Key.Item3;
                int qty    = kv.Value;

                var company = _companyService.GetById(compId);
                var branch  = _branchService.GetById(brId);
                var product = _productService.GetById(prodId);

                if (product == null || qty <= 0) continue;

                list.Add(new CartLine
                {
                    CompanyId = compId,
                    BranchId  = brId,
                    ProductId = prodId,
                    Company   = company?.Name ?? "Company",
                    Branch    = branch?.Name ?? "Branch",
                    Product   = product.NAME,
                    Qty       = qty,
                    Price     = product.PRICE,
                    Total     = product.PRICE * qty
                });
            }

            // Newest first
            return list.OrderByDescending(x => x.Product).ToList();
        }

        private void BindGrid()
        {
            dgvLines.AutoGenerateColumns = false;
            dgvLines.DataSource = _lines;

            // Ensure columns set (in case designer lost them)
            Company_Column.DataPropertyName = nameof(CartLine.Company);
            Branch_Column.DataPropertyName  = nameof(CartLine.Branch);
            Product_Column.DataPropertyName = nameof(CartLine.Product);
            Qty_Column.DataPropertyName     = nameof(CartLine.Qty);
            Price_Column.DataPropertyName   = nameof(CartLine.Price);
            Total_Column.DataPropertyName   = nameof(CartLine.Total);
        }

        private void CalcTotals()
        {
            _subtotal = _lines.Sum(x => x.Total);
            lblItems.Text = $"Items: {_lines.Sum(x => x.Qty)}";
            lblSubtotal.Text = $"Subtotal: ৳ {_subtotal:N2}";
            lblGrand.Text = $"৳ {_subtotal:N2}";
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (_lines.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Build a snapshot compatible with OrderHistoryService
                var snapshot = new Dictionary<Tuple<int,int,int>, int>();
                foreach (var line in _lines)
                {
                    snapshot[Tuple.Create(line.CompanyId, line.BranchId, line.ProductId)] = line.Qty;
                }

                _orderService.SaveCartSnapshot(snapshot);

                // ✅ Reset the global cart
                CartStore.Clear();

                // ✅ Ask CustomerCartView to reset product cards & UI
                if (Owner is CustomerCartView cartView)
                {
                    cartView.ResetAllProductCards();
                    cartView.RefreshCartUI();
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save order.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private class CartLine
        {
            public int CompanyId { get; set; }
            public int BranchId  { get; set; }
            public int ProductId { get; set; }

            public string Company { get; set; }
            public string Branch  { get; set; }
            public string Product { get; set; }

            public int Qty { get; set; }
            public decimal Price { get; set; }
            public decimal Total { get; set; }
        }
    }
}
