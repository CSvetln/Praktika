using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using LibraryModels;
using Infrastructure.Reports;
using System.Data.Entity;

namespace DutyOfServiceDepart.Controllers
{
    public class ReportController : Controller
    {
		DutyContext db = new DutyContext();

		[Authorize]
		[HttpGet]
        public ActionResult CreateReport()
        {			
			return View(db.Employees.ToList());			
        }
		
		[MyAuthorize]
		[HttpPost]
		public FileResult CreateReport(string employeeName, DateTime date)
		{
			Report report = new Report();
			int d = 0;
			
			var dutyLists = db.DutyLists.Include(x=>x.Employeer).Where(x => x.Employeer.Name == employeeName && x.DateDuty.Year == date.Year && x.DateDuty.Month == date.Month).ToList();

			foreach (DutyList s in dutyLists)
			{
				d++;
			}
			
			using (MemoryStream stream = report.MakeReport(new ReportClosedXML(employeeName, d, date)))
			{
				string output = String.Format("Отчёт {0}-{1}xlsx", date.ToLongDateString(), date.AddMonths(1).AddDays(-1).ToLongDateString());
				return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", output);
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