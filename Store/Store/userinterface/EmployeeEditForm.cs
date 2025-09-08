using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Store.service; // assumes Employee & EmployeeService live here

namespace Store.userinterface
{
    public partial class EmployeeEditForm : Form
    {
        private readonly EmployeeService _service;
        private readonly bool _isEdit;
        private readonly int _editId;

        // For Add
        public EmployeeEditForm() : this(null) { }

        // For Edit (pass existing Employee)
        public EmployeeEditForm(Employee existing)
        {
            InitializeComponent();
            _service = new EmployeeService();

            if (existing == null)
            {
                _isEdit = false;
                lblTitle.Text = "Add Employee";
                btnSave.Text = "Save";
                PassBox.Enabled = true; // required in Add
            }
            else
            {
                _isEdit = true;
                _editId = existing.ID;
                lblTitle.Text = "Edit Employee";
                btnSave.Text = "Update";

                NameBox.Text = existing.NAME;
                MobileBox.Text = existing.MOBILE;
                AddressBox.Text = existing.ADDRESS;

                PassBox.Text = "";
                PassBox.Enabled = false; // password change not handled here
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = (NameBox.Text ?? "").Trim();
            var mobile = (MobileBox.Text ?? "").Trim();
            var password = PassBox.Text ?? "";
            var address = (AddressBox.Text ?? "").Trim();

            if (!ValidateInputs(name, mobile, password, out string err))
            {
                MessageBox.Show(err, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isEdit)
            {
                var emp = new Employee
                {
                    NAME = name,
                    MOBILE = mobile,
                    PASSWORD = password,
                    ADDRESS = address
                };

                var rows = _service.Register(emp);
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
            else
            {
                var emp = new Employee
                {
                    ID = _editId,
                    NAME = name,
                    MOBILE = mobile,
                    ADDRESS = address
                };

                var rows = _service.Update(emp);
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
        }

        private bool ValidateInputs(string name, string mobile, string password, out string error)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(mobile))
            {
                error = "Mobile is required.";
                return false;
            }

            // Only digits, 6–15 long (tweak as you wish)
            if (!Regex.IsMatch(mobile, @"^\d{6,15}$"))
            {
                error = "Mobile must be 6–15 digits.";
                return false;
            }

            if (!_isEdit)
            {
                if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
                {
                    error = "Password is required for new employee (min 4 characters).";
                    return false;
                }
            }

            error = null;
            return true;
        }
    }
}
