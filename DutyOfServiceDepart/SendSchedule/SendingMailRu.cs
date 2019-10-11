using DutyOfServiceDepart.SendSchedule;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace DutyOfServiceDepart.Mail
{
	public class SendingMailRu:IMail
	{
		private const string Login = "servisnyy.otdel.suek@mail.ru";
		private const string Password = "suek5863";

		public void SendMail(string Email, string Subject, string Body, DateTime date)
		{			
			SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
			Smtp.Credentials = new NetworkCredential(Login, Password);
			Smtp.EnableSsl = true;
		
			MailMessage Message = new MailMessage();
			Message.From = new MailAddress(Login);
			Message.To.Add(new MailAddress(Email));
			Message.Subject = Subject;
			Message.Body = Body;
			using (MemoryStream stream = Schedule.GetSchedule(date))
			{
				Message.Attachments.Add(new Attachment(stream, "График.xlsx"));
				Smtp.Send(Message);
			}
			Message.Dispose();
			Smtp.Dispose();		
		}
			
	}
}