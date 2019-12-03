using System.IO;

namespace DutyOfServiceDepart.Mail
{
	public interface IMail
	{
		void SendMail(string Email, string Subject, string Body, MemoryStream stream);
	}
}
