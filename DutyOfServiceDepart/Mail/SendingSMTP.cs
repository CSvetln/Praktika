using DutyOfServiceDepart.Mail;
using DutyOfServiceDepart.SendSchedule;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace DutyOfServiceDepart.Mail
{
	public class SendingSMTP:IMail
	{
		private const string login = "servisnyy.otdel.suek@mail.ru";
		private const string password = "suek5863";

		public void SendMail(string email, string subject, string body, Attachment attachment)
		{			
			SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
			Smtp.Credentials = new NetworkCredential(login, password);
			Smtp.EnableSsl = true;
		
			MailMessage Message = new MailMessage();
			Message.From = new MailAddress(login);
			Message.To.Add(new MailAddress(email));
			Message.Subject = subject;
			Message.Body = body;
			if(attachment!=null)
				Message.Attachments.Add(attachment);
			Smtp.Send(Message);
			
			Message.Dispose();
			Smtp.Dispose();		
		}
			
	}
}