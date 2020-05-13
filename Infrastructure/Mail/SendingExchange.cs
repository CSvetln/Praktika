using Microsoft.Exchange.WebServices.Data;
using System;
using System.IO;

namespace Infrastructure.Mail
{
	public class SendingExchange:IMail
	{
		public void SendMail(string email, string subject, string body, MemoryStream attachment)
		{
			ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1) { UseDefaultCredentials = true };

			service.AutodiscoverUrl(Environment.UserName + "@suek.ru", RedirectionUrlValidationCallback);

			EmailMessage Email = new EmailMessage(service) { Subject = subject, Body = body, Importance = Importance.Normal };

			Email.ToRecipients.Add(email);

			if (attachment != null)
			{
				Email.Attachments.AddFileAttachment("График.xlsx", attachment);
			}
			
			Email.Save();
			Email.Send();

			return;
		}

		private static bool RedirectionUrlValidationCallback(string redirectionUrl)
		{
			bool result = false;

			Uri redirectionUri = new Uri(redirectionUrl);

			if (redirectionUri.Scheme == "https")
			{
				result = true;
			}
			return result;
		}
	}
}