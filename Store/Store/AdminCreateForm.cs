using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Store
{
    public partial class AdminCreateForm : Form
    {
        public AdminCreateForm()
        {
            InitializeComponent();
        }

        private void AdminCreateForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            Visible = false;
        }

        int vCode=1000;
        private void SendCodeBtn_Click(object sender, EventArgs e)
        {
            timvcode.Stop();
            string to, from, pass, mail;
            to = gmailText.Text;
            from = "kenobangladesh@gmail.com";
            mail=vCode.ToString();
            pass = "nhng lqdi qpwh nfec";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "KENO - Verification Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification Code Sent. Check Your Email","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodeBox.Enabled = true;
                CreateBtn.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
            vCode += 10;

            if(vCode==9999)
            {
                vCode = 1000;
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (CodeBox.Text == vCode.ToString())
            {
                if (firstNameBox.Text == "")
                {

                    MessageBox.Show("Enter Your First Name");
                }

                else if (lastnameBox.Text == "")
                {
                    MessageBox.Show("Enter Your Last Name");
                }

                else if (mobileBox.Text == "")
                {
                    MessageBox.Show("Enter Your Mobile Number");
                }

                else if (gmailText.Text == "")
                {
                    MessageBox.Show("Enter Your Email");
                }

                else if (UserNameBox.Text == "")
                {
                    MessageBox.Show("Enter User Name");
                }
                else if (PassBox.Text == "")
                {
                    MessageBox.Show("Set a Password");
                }
                else if (CoPassBox.Text == "")
                {
                    MessageBox.Show("Confirm your password");
                }
                else if (PassBox.Text != CoPassBox.Text)
                {
                    MessageBox.Show("Password did not match.");
                }
                else
                {
                    AdminClass admin = new AdminClass();
                    admin.FirstName = firstNameBox.Text;
                    admin.LastName = lastnameBox.Text;
                    admin.UserName = UserNameBox.Text;
                    admin.MOBILE = mobileBox.Text;
                    admin.Password = PassBox.Text;
                    admin.ConnectionDB();
                    Form1 obj = new Form1();
                    obj.Show();
                    Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Invalid Code");
            }
        }
    }
}
