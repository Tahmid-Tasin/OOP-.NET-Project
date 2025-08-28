using System.Net;
using System.Net.Mail;

namespace Store.service

{
    public class EmailSender
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;
        private readonly string _from;
        private readonly string _password;

        public EmailSender()
        {
            _smtpHost = "smtp.gmail.com";
            _smtpPort = 587;
            _enableSsl = true;

            _from = "kenobangladesh@gmail.com";
            _password = "nhng lqdi qpwh nfec";
        }

        public void Send(string to, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(_from);
            message.Subject = subject;
            message.Body = body;

            var smtp = new SmtpClient(_smtpHost);
            smtp.Port = _smtpPort;
            smtp.EnableSsl = _enableSsl;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(_from, _password);

            smtp.Send(message);
        }
    }
}
