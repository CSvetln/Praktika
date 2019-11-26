using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Reports
{
	public class Report
	{
		public MemoryStream MakeReport(IReport report, string employeeName, DateTime date)
		{
			return report.CreateReport(employeeName, date);
		}
	}
}