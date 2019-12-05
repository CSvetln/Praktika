using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;
using Infrastructure.Reports;

namespace DutyOfServiceDepart.Controllers
{
    public class ReportController : Controller
    {
		DutyContext db = new DutyContext();

		[Authorize]
		[HttpGet]
        public ActionResult CreateReport()
        {			
			return View(db.Employees);			
        }
		
		[MyAuthorize]
		[HttpPost]
		public FileResult CreateReport(string employeeName, DateTime date)
		{
			Report report = new Report();
			int d = 0;

			
			var dutyLists = db.DutyLists.Where(x => x.Employee.Name == employeeName && x.DateDuty.Year == date.Year && x.DateDuty.Month == date.Month).ToList();

			foreach (DutyList s in dutyLists)
			{
				d++;
			}
			
			using (MemoryStream stream = report.MakeReport(new ReportClosedXML(employeeName, d, date)))
			{
				return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Отчёт.xlsx");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}