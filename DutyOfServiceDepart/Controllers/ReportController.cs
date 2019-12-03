using System;
using System.IO;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;
using DutyOfServiceDepart.Reports;

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
			using (MemoryStream stream = report.MakeReport(new ReportClosedXML(employeeName, date)))
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