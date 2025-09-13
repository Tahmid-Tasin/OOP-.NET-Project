// File: Store/userinterface/PurchaseHistoryForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class PurchaseHistoryForm : Form
    {
        private readonly OrderHistoryService _orderService;
        private readonly int _customerId;

        public PurchaseHistoryForm(int customerId)
        {
            InitializeComponent();
            _orderService = new OrderHistoryService();
            _customerId = customerId;
        }

        private void PurchaseHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            var rows = _orderService.GetHistoryForCustomer(_customerId);

            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.DataSource = rows;

            DateColumn.DataPropertyName    = nameof(OrderHistory.CreatedAt);
            CompanyColumn.DataPropertyName = nameof(OrderHistory.CompanyName);
            BranchColumn.DataPropertyName  = nameof(OrderHistory.BranchName);
            ProductColumn.DataPropertyName = nameof(OrderHistory.ProductName);
            QtyColumn.DataPropertyName     = nameof(OrderHistory.Quantity);
            PriceColumn.DataPropertyName   = nameof(OrderHistory.UnitPrice);
            TotalColumn.DataPropertyName   = nameof(OrderHistory.Total);
        }

    }
}
