using System.Net;
using System.Net.Mail;

namespace TPRM.SAP.Negocio.Utils
{
    public static class EmailUtil
    {
        public static void EnviarEmail(string emailPara, string assunto, string corpo)
        {
            var mensagemEmail = new MailMessage();

            mensagemEmail.From = new MailAddress("", "");
            mensagemEmail.To.Add(emailPara);
            mensagemEmail.Subject = assunto;
            mensagemEmail.Body = corpo;
            mensagemEmail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mensagemEmail.IsBodyHtml = true;

            var smtpClient = new SmtpClient("email-ssl.com.br", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("", "");

            try
            {
                smtpClient.Send(mensagemEmail);
            }
            catch (SmtpException)
            {
                throw;
            }
        }
    }
}
