using System.IO;

namespace Infrastructure.Mail
{
	public interface IMail
	{
		void SendMail(string Email, string Subject, string Body, MemoryStream stream);
	}
}
