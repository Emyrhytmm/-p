using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class MailSender
    {
        private static string sendermail;
        private static string senderpassword;

        public static void DefineSenderInformation(string email, string password)
        {
            sendermail = email;
            senderpassword = password;
        }


        public static void Sendmail(string recieverMail, string subject, string messageBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(sendermail);
                message.To.Add(new MailAddress(recieverMail));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = messageBody;
                smtp.Port = 587;
                smtp.Host = "smtp.office365.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(sendermail, senderpassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
                
            }
        }
    }
}
