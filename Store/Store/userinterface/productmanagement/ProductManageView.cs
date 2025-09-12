using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Store.service;
// using Store.Repository; // not needed here

namespace Store.userinterface
{
    public partial class ProductManageView : Form
    {
        private readonly ProductService _productService;

        public ProductManageView()
        {
            InitializeComponent();
            _productService = new ProductService();

            // Top combo defaults to "Hide Filters"
            cbFilterToggle.SelectedIndex = 0;

            LoadProducts();
        }

        private void LoadProducts()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            var products = _productService.GetAll();
            foreach (var p in products)
            {
                flowLayoutPanel1.Controls.Add(CreateCard(p));
            }
            flowLayoutPanel1.ResumeLayout();
            btnResetSearch.Visible = false; // only shows after searching
        }

        private Control CreateCard(Product p)
        {
            var card = new Panel
            {
                Width = 220,
                Height = 320,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            var pic = new PictureBox
            {
                Width = 200,
                Height = 160,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            if (!string.IsNullOrWhiteSpace(p.IMAGE_PATH) && File.Exists(p.IMAGE_PATH))
            {
                // Load without locking source file
                try
                {
                    using (var fs = new FileStream(p.IMAGE_PATH, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = new Bitmap(fs);
                    }
                }
                catch
                {
                    pic.Image = null;
                }
            }

            var name = new Label
            {
                Text = p.NAME,
                AutoSize = false,
                Width = 200,
                Height = 24,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 180),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            var price = new Label
            {
                Text = $"৳ {p.PRICE}",
                AutoSize = false,
                Width = 200,
                Height = 22,
                ForeColor = Color.ForestGreen,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 206)
            };

            var viewBtn = new Button { Text = "View", Location = new Point(10, 245), Width = 60 };
            var editBtn = new Button { Text = "Edit", Location = new Point(80, 245), Width = 60 };
            var delBtn  = new Button { Text = "Delete", Location = new Point(150, 245), Width = 60 };

            viewBtn.Click += (s, e) =>
            {
                MessageBox.Show($"{p.NAME}\n৳{p.PRICE}\nBrand: {p.BRAND}", "Product");
            };

            // EDIT → open ProductEditForm with existing product
            editBtn.Click += (s, e) =>
            {
                using (var dlg = new ProductEditForm(p))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            };

            delBtn.Click += (s, e) =>
            {
                if (MessageBox.Show("Delete this product?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _productService.Delete(p.ID);
                    LoadProducts();
                }
            };

            card.Controls.Add(pic);
            card.Controls.Add(name);
            card.Controls.Add(price);
            card.Controls.Add(viewBtn);
            card.Controls.Add(editBtn);
            card.Controls.Add(delBtn);

            return card;
        }

        private void cbFilterToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0 = Hide Filters, 1 = Show Filters
            bool show = cbFilterToggle.SelectedIndex == 1;
            filterPanel.Visible = show;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearchName.Text.Trim();
            string brand = txtSearchBrand.Text.Trim();
            string barcode = txtSearchBarcode.Text.Trim();

            // Run search (null for empty to let service ignore)
            var list = _productService.Search(
                string.IsNullOrEmpty(name) ? null : name,
                string.IsNullOrEmpty(brand) ? null : brand,
                string.IsNullOrEmpty(barcode) ? null : barcode,
                null, null, null
            );

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();
            foreach (var p in list)
            {
                flowLayoutPanel1.Controls.Add(CreateCard(p));
            }
            flowLayoutPanel1.ResumeLayout();

            btnResetSearch.Visible = true;
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            txtSearchBrand.Text = "";
            txtSearchBarcode.Text = "";
            LoadProducts();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // ADD → open empty ProductEditForm
            using (var dlg = new ProductEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void backToHomePage(object sender, EventArgs e)
        {
            var adm = new AdminView();
            adm.Show();
            this.Visible = false;
        }
    }
}
