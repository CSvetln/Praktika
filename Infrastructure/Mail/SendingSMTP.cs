using System.IO;
using System.Net;
using System.Net.Mail;

namespace Helpers.Mail
{
	public class SendingSMTP : IMailSender
	{
		string Login { get; set; } 
		string Password { get; set; } 

		public SendingSMTP(string login, string password)
		{
			this.Login = login;
			this.Password = password;
		}

		public void SendMail(string email, string subject, string body, MemoryStream attachmentFileStream)
		{
			SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
			smtp.Credentials = new NetworkCredential(Login, Password);
			smtp.EnableSsl = true;

			MailMessage message = new MailMessage();

			message.From = new MailAddress(Login);
			message.To.Add(new MailAddress(email));
			message.Subject = subject;
			message.Body = body;
			message.Attachments.Add(new Attachment(attachmentFileStream, "График.xlsx"));

			smtp.Send(message);

			message.Dispose();
			smtp.Dispose();
		}
	}
}