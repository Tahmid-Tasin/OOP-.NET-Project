using System;
using System.Windows.Forms;

namespace Store.userinterface
{
    public partial class InventoryViewForm : Form
    {
        private readonly Inventory _model;

        public InventoryViewForm(Inventory model)
        {
            InitializeComponent();
            _model = model;
            FillDetails();
        }

        private void FillDetails()
        {
            if (_model == null) return;

            valProduct.Text  = _model.Product?.NAME ?? "-";
            valBrand.Text    = _model.Product?.BRAND ?? "-";
            valBranch.Text   = _model.Branch?.Name ?? "-";
            valQuantity.Text = _model.Quantity.ToString("N2");
            valUpdated.Text  = _model.UpdatedAt.ToString("yyyy-MM-dd HH:mm");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
