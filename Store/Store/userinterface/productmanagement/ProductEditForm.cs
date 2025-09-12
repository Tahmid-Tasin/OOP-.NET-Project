using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Store.Repository; // CategoryRepository, Product model
using Store.service;    // ProductService

namespace Store.userinterface
{
    public partial class ProductEditForm : Form
    {
        private readonly ProductService _service;
        private readonly CategoryRepository _categoryRepo;

        private readonly bool _isEdit;
        private readonly int _editId;
        private string _imagePath;

        // ADD mode
        public ProductEditForm() : this(null) { }

        // EDIT mode
        public ProductEditForm(Product existing)
        {
            InitializeComponent();

            _service = new ProductService();
            _categoryRepo = new CategoryRepository();

            LoadCategories();

            if (existing == null)
            {
                _isEdit = false;
                _editId = 0;
                lblTitle.Text = "Add Product";
                btnSave.Text = "Save";
                _imagePath = null;
            }
            else
            {
                _isEdit = true;
                _editId = existing.ID;
                lblTitle.Text = "Edit Product";
                btnSave.Text = "Update";

                txtName.Text = existing.NAME;
                txtBrand.Text = existing.BRAND;
                txtDescription.Text = existing.DESCRIPTION;
                txtPrice.Text = existing.PRICE.ToString(CultureInfo.InvariantCulture);
                txtBarcode.Text = existing.BARCODE;

                // Select category after list is loaded
                try { cbCategory.SelectedValue = existing.CATEGORY_ID; } catch { /* ignore */ }

                _imagePath = existing.IMAGE_PATH;
                TryLoadImage(existing.IMAGE_PATH);
            }
        }

        private void LoadCategories()
        {
            var cats = _categoryRepo.GetAll();
            cbCategory.DataSource = cats;
            cbCategory.DisplayMember = "NAME";
            cbCategory.ValueMember = "ID";
        }

        private void TryLoadImage(string path)
        {
            picProduct.Image = null;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;

            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    picProduct.Image = new Bitmap(fs);
                }
            }
            catch
            {
                picProduct.Image = null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif" })
            {
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string dir = Path.Combine(appData, "SuperShop", "Images");
                    Directory.CreateDirectory(dir);

                    string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);
                    string destPath = Path.Combine(dir, newFileName);

                    File.Copy(ofd.FileName, destPath, true);
                    _imagePath = destPath;

                    using (var fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                    {
                        picProduct.Image = new Bitmap(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image load failed: " + ex.Message, "Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            var name = (txtName.Text ?? "").Trim();
            var brand = (txtBrand.Text ?? "").Trim();
            var description = (txtDescription.Text ?? "").Trim();
            var barcode = (txtBarcode.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return;
            }

            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Category is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategory.DroppedDown = true; return;
            }

            // Price parsing (try invariant first, then current culture)
            decimal price;
            if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out price))
            {
                if (!decimal.TryParse(txtPrice.Text.Trim(), out price))
                {
                    MessageBox.Show("Enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus(); return;
                }
            }
            if (price <= 0)
            {
                MessageBox.Show("Price must be greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus(); return;
            }

            int categoryId = Convert.ToInt32(cbCategory.SelectedValue);

            var product = new Product
            {
                NAME = name,
                CATEGORY_ID = categoryId,
                BRAND = brand,
                DESCRIPTION = description,
                PRICE = price,
                BARCODE = barcode,
                IMAGE_PATH = _imagePath,
                IS_ACTIVE = true
            };

            if (_isEdit)
            {
                product.ID = _editId;
                var rows = _service.Update(product);
                if (rows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var rows = _service.Register(product);
                if (rows > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Save failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
