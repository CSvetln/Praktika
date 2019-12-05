using System.IO;

namespace Infrastructure.Reports
{
	public class Report
	{
		public MemoryStream MakeReport(IReport report)
		{
			return report.CreateReport();
		}
	}
}