using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyOfServiceDepart.Mail
{
	interface IMail
	{
		  void SendMail(string Email, string File, string Subject, string Body);
	}
}
