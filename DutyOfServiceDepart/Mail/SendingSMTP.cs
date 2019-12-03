using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace DutyOfServiceDepart.Mail
{
	public class SendingSMTP:IMail
	{
		private string login = WebConfigurationManager.AppSettings["lodin"];
		private string password = WebConfigurationManager.AppSettings["pass"];

		public void SendMail(string email, string subject, string body, MemoryStream attachment)
		{			
			SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
			Smtp.Credentials = new NetworkCredential(login, password);
			Smtp.EnableSsl = true;

			MailMessage Message = new MailMessage();
		
			Message.From = new MailAddress(login);
			Message.To.Add(new MailAddress(email));
			Message.Subject = subject;
			Message.Body = body;
			Message.Attachments.Add(new Attachment(attachment, "График.xlsx"));
			
			Smtp.Send(Message);
			
			Message.Dispose();
			Smtp.Dispose();		
		}
	}
}