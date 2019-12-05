using System.IO;
using System.Net;
using System.Net.Mail;


namespace Infrastructure.Mail
{
	public class SendingSMTP : IMail
	{
		string Login { get; set; } 
		string Password { get; set; } 

		public SendingSMTP(string login, string password)
		{
			this.Login = login;
			this.Password = password;
		}

		public void SendMail(string email, string subject, string body, MemoryStream attachment)
		{
			SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
			Smtp.Credentials = new NetworkCredential(Login, Password);
			Smtp.EnableSsl = true;

			MailMessage Message = new MailMessage();

			Message.From = new MailAddress(Login);
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