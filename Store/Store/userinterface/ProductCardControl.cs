using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Store.userinterface
{
    // A reusable UserControl that shows a product card with image, info, and cart controls
    public partial class ProductCardControl : UserControl
    {
        private Product _product;
        private int _quantity;

        public event EventHandler<int> QuantityChanged;

        public ProductCardControl()
        {
            InitializeComponent();
        }

        public void Bind(Product product, int qty = 0)
        {
            _product = product;
            _quantity = qty;

            lblName.Text = product.NAME;
            lblPrice.Text = $"৳ {product.PRICE:N2}";
            lblWeight.Text = string.IsNullOrWhiteSpace(product.DESCRIPTION) ? "" : product.DESCRIPTION;
            qtyLabel.Text = qty.ToString();

            if (!string.IsNullOrWhiteSpace(product.IMAGE_PATH) && File.Exists(product.IMAGE_PATH))
            {
                try
                {
                    using (var fs = new FileStream(product.IMAGE_PATH, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = new Bitmap(fs);
                    }
                }
                catch
                {
                    pic.Image = null;
                }
            }
            else
            {
                pic.Image = null;
            }

            UpdateCartUI();
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            _quantity++;
            UpdateCartUI();
            QuantityChanged?.Invoke(this, _quantity);
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            if (_quantity > 0) _quantity--;
            UpdateCartUI();
            QuantityChanged?.Invoke(this, _quantity);
        }

        private void UpdateCartUI()
        {
            qtyLabel.Text = _quantity.ToString();
            if (_quantity > 0)
            {
                lblInBag.Text = $"{_quantity} in bag";
                bottomBar.Visible = true;
            }
            else
            {
                bottomBar.Visible = false;
            }
        }
    }
}
