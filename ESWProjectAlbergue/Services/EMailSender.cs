using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
/*
namespace ESWProjectAlbergue.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string strToEmail, string strSubject, string strBody)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Credentials = new NetworkCredential("quintamiaoalbergue@gmail.com", "SWAlbergue5");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("quintamiaoalbergue@gmail.com");
            mail.To.Add(strToEmail);
            mail.Body = strBody;
            mail.Subject = strSubject;
            mail.IsBodyHtml = true;
                
             smtpClient.Send(mail);
            return Task.CompletedTask;
           
        }

        public async Task SendRegistrationEmail(string strEmailStudent)
        {
            string strSubject = "[QUINTA-DO-MIAO] Registo na Quinta do Mi";


            var strbBody = new StringBuilder();
            strbBody.AppendLine("Caro utilizador,<br><br>");
            strbBody.AppendFormat(@"O seu pedido de registo na plataforma da Quinta do Mião foi aprovado.<br><br>");


            strbBody.AppendLine("Cumprimentos, <br> A Equipa da Quinta do Miao.");
            SendEmailAsync(strEmailStudent, strSubject, strbBody.ToString());
        }

    }*/

