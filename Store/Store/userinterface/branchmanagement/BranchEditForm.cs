using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class BranchEditForm : Form
    {
        private readonly BranchService _service;
        private readonly bool _isEdit;
        private readonly int _editId;
        private readonly int _companyId;

        // For Create
        public BranchEditForm(int companyId)
        {
            InitializeComponent();
            _service = new BranchService();
            _isEdit = false;
            _companyId = companyId;

            lblTitle.Text = "Add Branch";
            btnSave.Text = "Save";
        }

        // For Edit
        public BranchEditForm(int companyId, Branch existing) : this(companyId)
        {
            if (existing != null)
            {
                _isEdit = true;
                _editId = existing.Id;
                lblTitle.Text = "Edit Branch";
                btnSave.Text = "Update";

                NameBox.Text     = existing.Name;
                Address1Box.Text = existing.AddressLine1;
                Address2Box.Text = existing.AddressLine2;
                CityBox.Text     = existing.City;
                StateBox.Text    = existing.State;
                PostalBox.Text   = existing.PostalCode;
                CountryBox.Text  = existing.Country;
                PhoneBox.Text    = existing.Phone;
                EmailBox.Text    = existing.Email;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name  = (NameBox.Text ?? "").Trim();
            var addr1 = (Address1Box.Text ?? "").Trim();
            var city  = (CityBox.Text ?? "").Trim();
            var phone = (PhoneBox.Text ?? "").Trim();
            var email = (EmailBox.Text ?? "").Trim();

            if (!ValidateInputs(name, addr1, city, phone, email, out string error))
            {
                MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var branch = new Branch
            {
                CompanyId   = _companyId,
                Name        = name,
                AddressLine1= addr1,
                AddressLine2= (Address2Box.Text ?? "").Trim(),
                City        = city,
                State       = (StateBox.Text ?? "").Trim(),
                PostalCode  = (PostalBox.Text ?? "").Trim(),
                Country     = (CountryBox.Text ?? "").Trim(),
                Phone       = phone,
                Email       = email
            };

            int rows;
            if (_isEdit)
            {
                branch.Id = _editId;
                rows = _service.Update(branch);
            }
            else
            {
                rows = _service.Register(branch);
            }

            if (rows > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(string name, string addr1, string city, string phone, string email, out string error)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Branch name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(addr1))
            {
                error = "Address Line 1 is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                error = "City is required.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^[0-9\-\+\s]{6,20}$"))
            {
                error = "Phone format is invalid.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(email) &&
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Email format is invalid.";
                return false;
            }
            error = null;
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
