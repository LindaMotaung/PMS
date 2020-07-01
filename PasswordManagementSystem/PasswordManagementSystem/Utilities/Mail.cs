using PasswordManagementSystem.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Utilities
{
    public class Mail
    {
        GeneralExceptions generalExceptions = new GeneralExceptions();

        public void sendMail(string from, List<string> to, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(from);
                if (to.Count >= 1 && to != null)
                {
                    foreach (var index in to)
                    {
                        mail.To.Add(index);
                    }
                }

                mail.Subject = "Password Reset";
                mail.Body = body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.mailtrap.io";
                smtp.Credentials = new System.Net.NetworkCredential("f2863e2d1da5c8", "f4aa8b30a9d489");

                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (SmtpException ex)
            {
                //Log exception to the db
                generalExceptions.LogExceptions("SendMail", Convert.ToString(ex.InnerException), ex.Message, DateTime.Now);
            }
        }
    }
}
