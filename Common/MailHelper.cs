using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace Common
{
    public class MailHelper
    {
        public void SendMail(string ToEmailAddress, string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var FromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSsl"].ToString());

            string body = content;
            MailMessage message = new MailMessage( new MailAddress(fromEmailAddress, FromEmailDisplayName), new MailAddress(ToEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            
            var client = new SmtpClient();
            //
            client.UseDefaultCredentials = false;
            //
            client.Credentials = new NetworkCredential(fromEmailAddress, FromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}
