using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DBModels;
using Helpers.Reports;
using CalendarWebsite.Filters;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
{
    public class ReportController : BaseControllerWithDB
    {
        [Authorize]
        [HttpGet]
        public ActionResult CreateReport()
        {
            ReportForm model = new ReportForm() { Employees = db.Employees.ToList(), EmployeeId = 0, ReportMonth = DateTime.Now.Date };

            return View(model);
        }

        [MyAuthorize]
        [HttpPost]
        public FileResult CreateReport(ReportForm model)
        {
            int d = 0;
            Employee employee = db.Employees.First(x => x.Id == model.EmployeeId);
            ReportClosedXML report = new ReportClosedXML(employee.FullName, d, model.ReportMonth);
            var dutyLists = db.Duties.Include(x => x.Employee).Where(x => x.EmployeeId == model.EmployeeId && x.DutyDate.Year == model.ReportMonth.Year && x.DutyDate.Month == model.ReportMonth.Month).ToList();

            foreach (Duty duty in dutyLists)
            {
                d++;
            }

            using (MemoryStream stream = report.CreateReport())
            {
                string output = String.Format("Отчёт {0}-{1}xlsx", model.ReportMonth.ToLongDateString(), model.ReportMonth.AddMonths(1).AddDays(-1).ToLongDateString());

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", output);
            }
        }
    }
}