using ERP.ERPDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ERP.Utility
{
    public class Email
    {
        private readonly AppDbContext context;
        private readonly string emailAddress;
        private readonly string subject;
        private readonly string message;

        public Email(AppDbContext context, string EmailAddress, string Subject, string Message)
        {
            this.context = context;
            emailAddress = EmailAddress;
            subject = Subject;
            message = Message;
        }
        public async Task Send()
        {
            string Host = "";
            string Username = "";
            string Password = "";
            int Port = 25;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Username);
                mail.To.Add(emailAddress);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = message;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.Port = Port;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Timeout = 1000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(Username, Password);
                smtp.Send(mail);
            }
            catch { }
        }
    }
}
