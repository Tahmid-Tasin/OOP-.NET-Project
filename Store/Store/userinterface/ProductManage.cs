using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Store.service;
using Store.Repository;

namespace Store.userinterface
{
    public partial class ProductManage : Form
    {
        private readonly ProductService _productService;
        private readonly CategoryRepository _categoryRepo;
        private string imagePath = null;

        public ProductManage()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryRepo = new CategoryRepository();

            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            var cats = _categoryRepo.GetAll();
            CategoryBox.DataSource = cats;
            CategoryBox.DisplayMember = "NAME";
            CategoryBox.ValueMember = "ID";
        }

        private void LoadProducts()
        {
            flowLayoutPanel1.Controls.Clear();
            var products = _productService.GetAll();
            foreach (var p in products)
            {
                flowLayoutPanel1.Controls.Add(CreateCard(p));
            }
        }

        private Panel CreateCard(Product p)
        {
            var card = new Panel
            {
                Width = 200,
                Height = 300,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            PictureBox pic = new PictureBox
            {
                Width = 180,
                Height = 150,
                Image = File.Exists(p.IMAGE_PATH) ? Image.FromFile(p.IMAGE_PATH) : null,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10)
            };

            Label name = new Label
            {
                Text = p.NAME,
                AutoSize = false,
                Width = 180,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 170)
            };

            Label price = new Label
            {
                Text = $"৳ {p.PRICE}",
                AutoSize = false,
                Width = 180,
                Height = 25,
                ForeColor = Color.Green,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 200)
            };

            Button viewBtn = new Button { Text = "View", Location = new Point(10, 240), Width = 55 };
            Button editBtn = new Button { Text = "Edit", Location = new Point(70, 240), Width = 55 };
            Button delBtn = new Button { Text = "Delete", Location = new Point(130, 240), Width = 55 };

            viewBtn.Click += (s, e) => MessageBox.Show($"{p.NAME}\n৳{p.PRICE}\nBrand: {p.BRAND}");
            editBtn.Click += (s, e) => EditProduct(p);
            delBtn.Click += (s, e) =>
            {
                if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void UploadImageBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string dir = Path.Combine(appData, "SuperShop", "Images");
                Directory.CreateDirectory(dir);

                // Use unique name (avoid overwriting same filename)
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);
                string destPath = Path.Combine(dir, newFileName);

                // Copy the file (safe, not locked)
                File.Copy(ofd.FileName, destPath, true);
                imagePath = destPath;

                // Load into PictureBox without locking
                using (var fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                {
                    ProductPicture.Image = new Bitmap(fs);
                }
            }
        }


        private void SaveProductBtn_Click(object sender, EventArgs e)
        {
            var p = new Product
            {
                NAME = NameBox.Text,
                CATEGORY_ID = Convert.ToInt32(CategoryBox.SelectedValue),
                BRAND = BrandBox.Text,
                DESCRIPTION = DescriptionBox.Text,
                PRICE = decimal.Parse(PriceBox.Text),
                BARCODE = BarcodeBox.Text,
                IMAGE_PATH = imagePath,
                IS_ACTIVE = true
            };

            if (string.IsNullOrEmpty(IDBox.Text))
            {
                _productService.Register(p);
            }
            else
            {
                p.ID = int.Parse(IDBox.Text);
                _productService.Update(p);
            }

            LoadProducts();
            ResetForm();
        }

        private void EditProduct(Product p)
        {
            IDBox.Text = p.ID.ToString();
            NameBox.Text = p.NAME;
            BrandBox.Text = p.BRAND;
            DescriptionBox.Text = p.DESCRIPTION;
            PriceBox.Text = p.PRICE.ToString();
            BarcodeBox.Text = p.BARCODE;
            imagePath = p.IMAGE_PATH;

            if (File.Exists(p.IMAGE_PATH))
                ProductPicture.Image = Image.FromFile(p.IMAGE_PATH);

            SaveProductBtn.Text = "Update";
        }

        private void ResetForm()
        {
            IDBox.Text = "";
            NameBox.Text = "";
            BrandBox.Text = "";
            DescriptionBox.Text = "";
            PriceBox.Text = "";
            BarcodeBox.Text = "";
            imagePath = null;
            ProductPicture.Image = null;
            SaveProductBtn.Text = "Save";
        }
    }
}
