using System.IO;

namespace Helpers.Reports
{
	public interface IReport
	{
		MemoryStream CreateReport();
	}
}
