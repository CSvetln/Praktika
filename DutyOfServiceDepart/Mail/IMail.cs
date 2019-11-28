using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DutyOfServiceDepart.Mail
{
	public interface IMail
	{
		void SendMail(string Email, string Subject, string Body, MemoryStream stream);
	}
}
