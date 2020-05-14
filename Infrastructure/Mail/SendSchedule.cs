using LibraryModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Mail
{
	public class SendSchedule
	{
		public string[] Emails { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime DateSchedule { get; set; }
		public Dictionary<int, Employee[]> Duties { get; set; }

		public SendSchedule(string[] emails, string subject, string body, DateTime dateSchedule, Dictionary<int, Employee[]> duties)
		{
			this.Emails = emails;
			this.Subject = subject;
			this.Body = body;
			this.DateSchedule = dateSchedule;
			this.Duties = duties;
		}

		private MemoryStream GetAttachment()
		{
			return Schedule.GetSchedule(Duties, DateSchedule);
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