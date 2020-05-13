using System.IO;

namespace Infrastructure.Reports
{
	public interface IReport
	{
		MemoryStream CreateReport();
	}
}
