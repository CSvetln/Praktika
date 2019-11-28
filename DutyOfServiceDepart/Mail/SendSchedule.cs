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
		public string[] Emails { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime DateSchedule { get; set; }

		public SendSchedule(string[] emails, string subject, string body, DateTime dateSchedule)
		{
			this.Emails = emails;
			this.Subject = subject;
			this.Body = body;
			this.DateSchedule = dateSchedule;
		}

		private MemoryStream GetAttachment()
		{
			return Schedule.GetSchedule(DateSchedule);
						
		}
		public void Send(IMail mail)
		{
			foreach (string email in Emails)
			{
				mail.SendMail(email, Subject, Body, GetAttachment());
			}
		}

	}
}