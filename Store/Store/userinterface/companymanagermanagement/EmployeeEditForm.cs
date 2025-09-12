using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Store.service;

namespace Store.userinterface
{
    public partial class EmployeeEditForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly CompanyService _companyService;
        private readonly EmailSender _emailSender;

        private readonly bool _isEdit;
        private readonly int _editId;

        // For Add
        public EmployeeEditForm() : this(null) { }

        // For Edit (pass existing Employee)
        public EmployeeEditForm(Employee existing)
        {
            InitializeComponent();

            _employeeService = new EmployeeService();
            _companyService   = new CompanyService();
            _emailSender     = new EmailSender();

            // Load companies immediately
            loadCompanies();

            if (existing == null)
            {
                _isEdit = false;
                lblTitle.Text = "Add Employee";
                btnSave.Text  = "Save";
                PassBox.Enabled = true;
            }
            else
            {
                _isEdit = true;
                _editId = existing.ID;
                lblTitle.Text = "Edit Employee";
                btnSave.Text  = "Update";

                NameBox.Text   = existing.NAME;
                MobileBox.Text = existing.MOBILE;
                EmailBox.Text  = existing.EMAIL;
                AddressBox.Text = existing.ADDRESS;

                if (existing.CompanyId.HasValue)
                    CompanyCombo.SelectedValue = existing.CompanyId.Value;

                PassBox.Text = "";
                PassBox.Enabled = false; // not changing password here
            }
        }

        private void EmployeeEditForm_Shown(object sender, EventArgs e)
        {
            // Make sure nothing is overlaying and first field gets focus
            NameBox.BringToFront();
            MobileBox.BringToFront();
            EmailBox.BringToFront();
            PassBox.BringToFront();
            AddressBox.BringToFront();
            CompanyCombo.BringToFront();
            btnSave.BringToFront();
            btnCancel.BringToFront();

            ActiveControl = NameBox;
            NameBox.Focus();
        }

        private void loadCompanies()
        {
            var companies = _companyService.GetAll();
            CompanyCombo.DataSource = companies;
            CompanyCombo.DisplayMember = "Name";
            CompanyCombo.ValueMember   = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name     = (NameBox.Text   ?? "").Trim();
            var mobile   = (MobileBox.Text ?? "").Trim();
            var email    = (EmailBox.Text  ?? "").Trim();
            var password = PassBox.Text ?? "";
            var address  = (AddressBox.Text ?? "").Trim();
            var companyId = (int?)CompanyCombo.SelectedValue;

            if (!ValidateInputs(name, mobile, email, password, out string err))
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
                    EMAIL = email,
                    PASSWORD = password,
                    ADDRESS = address,
                    CompanyId = companyId
                };

                var rows = _employeeService.Register(emp);
                if (rows > 0)
                {
                    try
                    {
                        var subject = "Welcome to KENO Bangladesh";
                        var body =
$@"Dear {name},

Your employee account has been created.

Email   : {email}
Password: {password}

Please keep your credentials safe.

Regards,
KENO Team";
                        _emailSender.Send(email, subject, body);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Employee created, but failed to send email: " + ex.Message,
                                        "Email Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
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
                    EMAIL = email,
                    ADDRESS = address,
                    CompanyId = companyId
                };

                var rows = _employeeService.Update(emp);
                if (rows > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs(string name, string mobile, string email, string password, out string error)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name is required."; return false;
            }

            if (string.IsNullOrWhiteSpace(mobile))
            {
                error = "Mobile is required."; return false;
            }

            if (!Regex.IsMatch(mobile, @"^\d{6,15}$"))
            {
                error = "Mobile must be 6–15 digits."; return false;
            }

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Valid email is required."; return false;
            }

            if (!_isEdit)
            {
                if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
                {
                    error = "Password is required for new employee (min 4 characters)."; return false;
                }
            }

            if (CompanyCombo.SelectedValue == null)
            {
                error = "Please select an Company."; return false;
            }

            error = null;
            return true;
        }
    }
}
