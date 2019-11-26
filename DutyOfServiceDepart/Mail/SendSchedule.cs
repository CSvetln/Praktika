using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DutyOfServiceDepart.SendSchedule
{
	public class SendSchedule
	{
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public Attachment Attachment { get; set; }
		public DateTime DateSchedule { get; set; }

		public SendSchedule(string email, string subject, string body, DateTime dateSchedule)
		{
			this.Email = email;
			this.Subject = subject;
			this.Body = body;
			this.DateSchedule = dateSchedule;
			this.Attachment = GetAttachment();
		}

		private Attachment GetAttachment()
		{
			using (MemoryStream stream = Schedule.GetSchedule(DateSchedule))
			{
				return new Attachment(stream, "График.xlsx");
			}
		}
		public void Send(IMail mail)
		{
			mail.SendMail(Email, Subject, Body, Attachment);
		}

	}
}