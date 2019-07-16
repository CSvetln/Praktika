using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using DutyOfServiceDepart.Models;

namespace DutyOfServiceDepart.Controllers
{
    public class ReportController : Controller
    {
		DutyContext db = new DutyContext();
        [HttpGet]
        public ActionResult CreateReport()
        {
            return View(db.Employees);
        }
		[HttpPost]
		public FileResult CreateReport(string EmployeeName, DateTime Date)
		{
			int d = 0;
			foreach (DutyList s in db.DutyLists.Where(x => x.Employee.Name == EmployeeName && x.DateDuty.Year == Date.Year && x.DateDuty.Month == Date.Month).ToList())
			{
				d++;
			}
			var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add("Лист1");

			worksheet.Cell("A" + 1).Value = "Дежурный";
			worksheet.Cell("B" + 1).Value = "Период";
			worksheet.Cell("C" + 1).Value = "Количество дежурств";

			worksheet.Cell("A" + 2).Value = EmployeeName;
			worksheet.Cell("B" + 2).Value = Date.ToLongDateString() + "-" + Date.AddMonths(1).AddDays(-1).ToLongDateString();
			worksheet.Cell("C" + 2).Value = d;


			for (int i = 1; i < 4; i++)
			{
				worksheet.Cell(1, i).Style.Font.Bold = true;
			}
			worksheet.Cells().Style.Font.FontName = "Times New Roman";
			worksheet.Cells().Style.Border.BottomBorder = XLBorderStyleValues.Medium;
			worksheet.Cells().Style.Border.RightBorder = XLBorderStyleValues.Medium;
			worksheet.Cells().Style.Font.FontSize = 14;

			worksheet.Columns().AdjustToContents(); //ширина столбца по содержимому

			using (MemoryStream stream = new MemoryStream())
			{
				workbook.SaveAs(stream);
				return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчёт.xlsx");
			}
		}
		
	}
}