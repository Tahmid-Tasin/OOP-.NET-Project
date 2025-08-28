using System;
using System.Windows.Forms;

using Store.service;

namespace Store
{
    public partial class AdminCreateForm : Form
    {
        private readonly AdminService _adminService;
        private readonly EmailSender _emailSender;

        private int _verificationCode;
        private DateTime _codeGeneratedAt;
        private readonly TimeSpan _codeTtl = TimeSpan.FromMinutes(10);
        private readonly Random _rng = new Random();

        public AdminCreateForm()
        {
            InitializeComponent();
            _adminService = new AdminService();
            _emailSender = new EmailSender();
        }

        private void AdminCreateForm_Load(object sender, EventArgs e)
        {
            CodeBox.Enabled = false;
            CreateBtn.Enabled = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            var obj = new LoginForm();
            obj.Show();
            this.Hide();
        }

        private void SendCodeBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gmailText.Text))
            {
                MessageBox.Show("Enter your email first.");
                return;
            }

            try
            {
                _verificationCode = _rng.Next(1000, 10000);
                _codeGeneratedAt = DateTime.Now;

                string subject = "KENO - Verification Code";
                string body = _verificationCode.ToString();

                _emailSender.Send(gmailText.Text.Trim(), subject, body);

                MessageBox.Show(
                    "Verification code sent. Check your email.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                CodeBox.Enabled = true;
                CreateBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (!CodeBox.Enabled)
            {
                MessageBox.Show("Please request and enter the verification code first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CodeBox.Text))
            {
                MessageBox.Show("Enter the verification code.");
                return;
            }

            if ((DateTime.Now - _codeGeneratedAt) > _codeTtl)
            {
                MessageBox.Show("Verification code expired. Please request a new code.");
                CodeBox.Enabled = false;
                CreateBtn.Enabled = false;
                return;
            }

            if (CodeBox.Text.Trim() != _verificationCode.ToString())
            {
                MessageBox.Show("Invalid verification code.");
                return;
            }

            if (string.IsNullOrWhiteSpace(firstNameBox.Text))
            {
                MessageBox.Show("Enter your first name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(lastnameBox.Text))
            {
                MessageBox.Show("Enter your last name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(mobileBox.Text))
            {
                MessageBox.Show("Enter your mobile number.");
                return;
            }
            if (string.IsNullOrWhiteSpace(gmailText.Text))
            {
                MessageBox.Show("Enter your email.");
                return;
            }
            if (string.IsNullOrWhiteSpace(UserNameBox.Text))
            {
                MessageBox.Show("Enter a username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(PassBox.Text))
            {
                MessageBox.Show("Set a password.");
                return;
            }
            if (string.IsNullOrWhiteSpace(CoPassBox.Text))
            {
                MessageBox.Show("Confirm your password.");
                return;
            }
            if (PassBox.Text != CoPassBox.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            var admin = new Admin();
            admin.FirstName = firstNameBox.Text.Trim();
            admin.LastName = lastnameBox.Text.Trim();
            admin.UserName = UserNameBox.Text.Trim();
            admin.Mobile = mobileBox.Text.Trim();
            admin.Password = PassBox.Text;

            try
            {
                int rows = _adminService.Register(admin);

                if (rows > 0)
                {
                    MessageBox.Show("Admin account created successfully.");

                    firstNameBox.Text = "";
                    lastnameBox.Text = "";
                    mobileBox.Text = "";
                    gmailText.Text = "";
                    UserNameBox.Text = "";
                    PassBox.Text = "";
                    CoPassBox.Text = "";
                    CodeBox.Text = "";

                    var login = new LoginForm();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create admin account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating admin: " + ex.Message);
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
        }
    }
}
