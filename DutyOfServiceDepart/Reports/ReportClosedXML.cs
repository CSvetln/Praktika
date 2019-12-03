using ClosedXML.Excel;
using DutyOfServiceDepart.Models;
using System;
using System.IO;
using System.Linq;

namespace DutyOfServiceDepart.Reports
{
	public class ReportClosedXML : IReport
	{
		public MemoryStream CreateReport(string employeeName, DateTime date)
		{
			int d = 0;

			using (DutyContext db = new DutyContext())
			{
				var dutyLists = db.DutyLists.Where(x => x.Employee.Name == employeeName && x.DateDuty.Year == date.Year && x.DateDuty.Month == date.Month).ToList();
				foreach (DutyList s in dutyLists)
				{
					d++;
				}
			}

			var workBook = new XLWorkbook();
			var workSheet = workBook.Worksheets.Add(date.ToString("MMMMMMMM"));

			workSheet.Cell("A" + 1).Value = "Дежурный";
			workSheet.Cell("B" + 1).Value = "Период";
			workSheet.Cell("C" + 1).Value = "Количество дежурств";

			workSheet.Cell("A" + 2).Value = employeeName;
			workSheet.Cell("B" + 2).Value = date.ToLongDateString() + "-" + date.AddMonths(1).AddDays(-1).ToLongDateString();
			workSheet.Cell("C" + 2).Value = d;


			for (int i = 1; i < 4; i++)
			{
				workSheet.Cell(1, i).Style.Font.Bold = true;
			}

			workSheet.Cells().Style.Font.FontName = "Times New Roman";
			workSheet.Cells().Style.Border.BottomBorder = XLBorderStyleValues.Medium;
			workSheet.Cells().Style.Border.RightBorder = XLBorderStyleValues.Medium;
			workSheet.Cells().Style.Font.FontSize = 14;

			workSheet.Columns().AdjustToContents(); //ширина столбца по содержимому

			using (MemoryStream stream = new MemoryStream())
			{
				workBook.SaveAs(stream);
				return stream;
			}
		}
	}
}