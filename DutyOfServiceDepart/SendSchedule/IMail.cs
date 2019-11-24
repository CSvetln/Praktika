using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyOfServiceDepart.SendSchedule
{
	interface IMail
	{
		  void SendMail(string Email, string Subject, string Body, DateTime date);
	}
}
