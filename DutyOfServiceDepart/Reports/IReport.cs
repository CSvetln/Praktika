using System;
using System.IO;

namespace DutyOfServiceDepart.Reports
{
	public interface IReport
	{
		MemoryStream CreateReport(string EmployeeName, DateTime Date);
	}
}
