using System.IO;

namespace Helpers.Mail
{
    public interface IMailSender
    {
		void SendMail(string email, string subject, string body, MemoryStream attachmentFileStream);
	}
}
