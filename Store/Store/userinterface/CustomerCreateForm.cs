using System;
using System.Windows.Forms;

using Store.service;

namespace Store
{
    public partial class CustomerCreateForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly EmailSender _emailSender;

        private int _verificationCode;
        private DateTime _codeGeneratedAt;
        private readonly TimeSpan _codeTtl = TimeSpan.FromMinutes(10);
        private readonly Random _rng = new Random();

        public CustomerCreateForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
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

            if (string.IsNullOrWhiteSpace(FullNameBox.Text))
            {
                MessageBox.Show("Enter your Full name.");
                return;
            }
          //  if (string.IsNullOrWhiteSpace(lastnameBox.Text))
           // {
              //  MessageBox.Show("Enter your last name.");
               // return;
           // }
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
            if (string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                MessageBox.Show("Enter your address.");
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

            var customer = new Customer();
            customer.FullName = FullNameBox.Text.Trim();
            customer.Address = AddressBox.Text.Trim();
            customer.Email = gmailText.Text.Trim();
            customer.Mobile = mobileBox.Text.Trim();
            customer.Password = PassBox.Text;

            try
            {
                int rows = _customerService.Register(customer);

                if (rows > 0)
                {
                    MessageBox.Show("Customer account created successfully.");

                    FullNameBox.Text = "";
                  
                    mobileBox.Text = "";
                    gmailText.Text = "";
                    AddressBox.Text = "";
                    PassBox.Text = "";
                    CoPassBox.Text = "";
                    CodeBox.Text = "";

                    var login = new LoginForm();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create Customer account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating Customer: " + ex.Message);
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void firstNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void gmailText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
