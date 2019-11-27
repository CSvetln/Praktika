using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DutyOfServiceDepart.Mail
{
	public class SendSchedule
	{
		public List<string> Emails { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public Attachment Attachment { get; set; }
		public DateTime DateSchedule { get; set; }

		public SendSchedule(List<string> emails, string subject, string body, DateTime dateSchedule)
		{
			this.Emails = emails;
			this.Subject = subject;
			this.Body = body;
			this.DateSchedule = dateSchedule;
			this.Attachment = GetAttachment();
		}

		private Attachment GetAttachment()
		{
			MemoryStream stream = Schedule.GetSchedule(DateSchedule);
			return new Attachment(stream, "График.xlsx");					
		}
		public void Send(IMail mail)
		{
			foreach (string email in Emails)
			{
				mail.SendMail(email, Subject, Body, Attachment);
			}
		}

	}
}