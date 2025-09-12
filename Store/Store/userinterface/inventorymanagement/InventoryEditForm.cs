using System;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class InventoryEditForm : Form
    {
        private readonly InventoryService _service;
        private readonly BranchService _branchService;
        private readonly ProductService _productService;

        private Inventory _model;
        private int _companyId;

        public InventoryEditForm()
        {
            InitializeComponent();
            _service = new InventoryService();
            _branchService = new BranchService();
            _productService = new ProductService();

            LoadDropdowns();
        }

        // Overload for edit mode
        public InventoryEditForm(Inventory model) : this()
        {
            _model = model;
            if (_model != null)
                FillForm();
        }

        private void LoadDropdowns()
        {
            // Load branches
            cbBranch.DataSource = _companyId > 0
                ? _branchService.GetByCompany(_companyId)
                : _branchService.GetAll();
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember   = "Id";

            // Load products
            cbProduct.DataSource = _productService.GetAll();
            cbProduct.DisplayMember = "NAME";
            cbProduct.ValueMember   = "ID";
        }


        private void FillForm()
        {
            if (_model == null) return;

            cbBranch.SelectedValue = _model.BranchId;
            cbProduct.SelectedValue = _model.ProductId;
            numQuantity.Value = _model.Quantity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbBranch.SelectedItem == null || cbProduct.SelectedItem == null)
            {
                MessageBox.Show("Branch and Product must be selected.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_model == null) _model = new Inventory();

            _model.BranchId = (int)cbBranch.SelectedValue;
            _model.ProductId = (int)cbProduct.SelectedValue;
            _model.Quantity = numQuantity.Value;

            // For company admin: CompanyId is fixed to logged-in company
            // (Here we assume you have a global/session context for logged-in company)
            if (_model.CompanyId == 0)
                _model.CompanyId = ((Branch)cbBranch.SelectedItem).CompanyId;

            var rows = _service.AddOrUpdate(_model);
            if (rows > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No changes were saved.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public InventoryEditForm(int companyId) : this()
        {
            _companyId = companyId;
            LoadDropdowns();
        }

        public InventoryEditForm(Inventory model, int companyId) : this(companyId)
        {
            _model = model;
            if (_model != null) FillForm();
        }

    }
}
