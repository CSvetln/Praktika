using Microsoft.Exchange.WebServices.Data;
using System;
using System.IO;

namespace Helpers.Mail
{
    public class SendingExchange : IMailSender
    {
        public void SendMail(string email, string subject, string body, MemoryStream attachmentFileStream)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1) { UseDefaultCredentials = true };

            service.AutodiscoverUrl(Environment.UserName + "@suek.ru", RedirectionUrlValidationCallback);

            EmailMessage message = new EmailMessage(service) { Subject = subject, Body = body, Importance = Importance.Normal };

            message.ToRecipients.Add(email);

            if (attachmentFileStream != null)
            {
                message.Attachments.AddFileAttachment("График.xlsx", attachmentFileStream);
            }

            message.Save();
            message.Send();

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