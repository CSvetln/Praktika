using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Reports
{
	public class Report
	{
		public MemoryStream MakeReport(IReport report)
		{
			return report.CreateReport();
		}
	}
}