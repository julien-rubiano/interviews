
using System.Net;
using System.Net.Mail;

namespace WebApi.Services
{
  public interface IEmailService
  {
    void SendEmail();
  }

  public class EmailService : IEmailService
  {
    public void SendEmail()
    {
      SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
      client.UseDefaultCredentials = false;
      client.Credentials = new NetworkCredential("mymail@gmail.com", "mypassword");
      client.EnableSsl = true;

      MailMessage mailMessage = new MailMessage();
      mailMessage.From = new MailAddress("mymail@gmail.com");
      mailMessage.To.Add("mymail@gmail.com");
      mailMessage.Body = "body";
      mailMessage.Subject = "subject";
      client.Send(mailMessage);
    }
  }
}
