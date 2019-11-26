using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.SendSchedule
{
	public class EmailAttachment
	{
		public String Name { get; set; }

		public byte[] Content { get; set; }
	}

	public class EMailMessage
	{
		public String Subject { get; set; }

		public String Body { get; set; }

		public EmailAttachment Attachment { get; set; }

		public bool IsImportant { get; set; } = false;

		public void Send(String ToAddress, String[] CcRecipients = null)
		{
			Send(new string[] { ToAddress }, CcRecipients);
		}

		public void Send(String[] ToAddresses, String[] CcRecipients = null)
		{
			if (!ToAddresses.Any())
			{
				return;
			}

			ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);// { UseDefaultCredentials = true };
			service.Credentials = new WebCredentials("servisnyy.otdel.suek@mail.ru", "suek5863", "MYDOMAIN");
			//service.EnableScpLookup = false;
			service.AutodiscoverUrl("servisnyy.otdel.suek@mail.ru");//, RedirectionUrlValidationCallback);

			EmailMessage Email = new EmailMessage(service) { Subject = Subject, Body = Body, Importance = IsImportant ? Importance.High : Importance.Normal };

			Email.ToRecipients.AddRange(ToAddresses);

			if (Attachment != null)
			{
				Email.Attachments.AddFileAttachment(Attachment.Name, Attachment.Content);
			}
			if (CcRecipients != null)
			{
				foreach (String CcRecipient in CcRecipients)
				{
					Email.BccRecipients.Add(new EmailAddress(CcRecipient));
				}
			}
			Email.Save();
			Email.Send();

			return;
		}

		private static bool RedirectionUrlValidationCallback(string redirectionUrl)
		{
			return true;
			//bool result = false;

			//Uri redirectionUri = new Uri(redirectionUrl);

			//if (redirectionUri.Scheme == "https")
			//{
			//	result = true;
			//}
			//return result;
		}
	}
}