using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;

namespace Infrastructure.Reports
{
	public class ReportClosedXML : IReport
	{
		String EmployeeName { get; set; }
		int AmountDuty { get; set; }
		DateTime Date { get; set; }

		public ReportClosedXML(string employeeName,int amountDuty, DateTime date)
		{
			this.EmployeeName = employeeName;
			this.AmountDuty = amountDuty;
			this.Date = date;
		}

		public MemoryStream CreateReport()
		{
			//int d = 0;

			//using (DutyContext db = new DutyContext())
			//{
			//	var dutyLists = db.DutyLists.Where(x => x.Employee.Name == EmployeeName && x.DateDuty.Year == Date.Year && x.DateDuty.Month == Date.Month).ToList();

			//	foreach (DutyList s in dutyLists)
			//	{
			//		d++;
			//	}
			//}

			var workBook = new XLWorkbook();
			var workSheet = workBook.Worksheets.Add(Date.ToString("MMMMMMMM"));

			workSheet.Cell("A" + 1).Value = "Дежурный";
			workSheet.Cell("B" + 1).Value = "Период";
			workSheet.Cell("C" + 1).Value = "Количество дежурств";

			workSheet.Cell("A" + 2).Value = EmployeeName;
			workSheet.Cell("B" + 2).Value = Date.ToLongDateString() + "-" + Date.AddMonths(1).AddDays(-1).ToLongDateString();
			workSheet.Cell("C" + 2).Value = AmountDuty;


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