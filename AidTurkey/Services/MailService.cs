using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
namespace AidTurkey.Services
{
    public class MailService
    {

        public static bool SendEmail(string emailTo, string msgSubject, string msgBody)
        {
            try
            {
                var email = "oguz@quikmotion.com";

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("QuikMotion", email));
                message.To.Add(new MailboxAddress("", emailTo));
              
                message.Subject = msgSubject;

                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = msgBody };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = CallBack;
                    client.Connect(
             "smtp.gmail.com"
           , 587
           , SecureSocketOptions.StartTlsWhenAvailable
        );
                    // client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
                    client.Authenticate(email, "");

                    client.Send(message);


                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }




        }



        private static bool CallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
