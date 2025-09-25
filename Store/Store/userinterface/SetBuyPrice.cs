using System;
using System.Windows.Forms;
using Store.Repository;
using Store.model;
using Store.service;

namespace Store.userinterface
{
    public partial class SetBuyPrice : Form
    {
        private readonly Product _product;

        // <-- New constructor that accepts a Product
        public SetBuyPrice(Product product)
        {
            InitializeComponent();
            _product = product ?? throw new ArgumentNullException(nameof(product));

            // show current buying price (if zero this will show 0)
            buypricebox.Text = _product.Buying_Price.ToString("0.##");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // optional: validation live feedback
        }

        // Cancel button (keep existing wiring if button1 is Cancel)
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Save button (keep existing wiring if button2 is Save)
        private void button2_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(buypricebox.Text.Trim(), out decimal newPrice))
            {
                _product.Buying_Price = newPrice;

                // Save to database using ProductService (which calls ProductRepository)
                var service = new ProductService();
                service.SaveBuyingPrice(_product.ID, newPrice);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
