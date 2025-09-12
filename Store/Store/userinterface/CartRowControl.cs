// STEP 02 — CartRowControl.cs

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Store.userinterface
{
    public partial class CartRowControl : UserControl
    {
        private Tuple<int, int, int> _key; // (companyId, branchId, productId)
        private decimal _unitPrice;
        private int _qty;
        private Product _product;

        public event Action RemoveRequested;

        public CartRowControl()
        {
            InitializeComponent();
        }

        public void Bind(
            int companyId, string companyName,
            int branchId, string branchName,
            Product product, int qty)
        {
            _key = Tuple.Create(companyId, branchId, product.ID);
            _product = product;
            _unitPrice = product.PRICE;
            _qty = qty;

            lblTitle.Text = product.NAME;
            lblSub.Text = companyName + " • " + branchName;

            lblUnit.Text = "৳ " + _unitPrice.ToString("N2");
            lblQty.Text = "x " + _qty.ToString();
            lblTotal.Text = "৳ " + (_unitPrice * _qty).ToString("N2");

            // image
            pic.Image = null;
            if (!string.IsNullOrWhiteSpace(product.IMAGE_PATH) && File.Exists(product.IMAGE_PATH))
            {
                try
                {
                    using (var fs = new FileStream(product.IMAGE_PATH, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = new Bitmap(fs);
                    }
                }
                catch { pic.Image = null; }
            }
        }

        public Tuple<int, int, int> Key { get { return _key; } }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (RemoveRequested != null) RemoveRequested();
        }
    }
}
