using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Configuration;
using Helpers.Mail;
using DBModels;
using CalendarWebsite.Filters;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
{
    public class HomeController : BaseControllerWithDB
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
        {
            Calendar calendar = Calendar.GetCalendarDuty(start);
            calendar.Vacation = Calendar.GetCalendarVacation(start);

            return View(calendar);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Edit(int[] selectedEmpId, DateTime dateEdit)
        {
            var duties = db.Duties.Where(x => x.DutyDate == dateEdit).ToList(); // все дежурства с такой датой
            foreach (Duty s in duties)//очищаем все на эту дату
            {
                db.Duties.Remove(s);
            }

            for (int i = 0; i < selectedEmpId.Length; i++)   // содаем новые
            {
                Employee selectedEmployee = db.Employees.Find(selectedEmpId[i]);
                Duty newDutyList = new Duty() { DutyDate = dateEdit, Employee = selectedEmployee };

                db.Duties.Add(newDutyList);
            }

            db.SaveChanges();

            return RedirectToAction("Index", new { start = dateEdit });
        }

        [MyAuthorize]
        public ActionResult SendAll(DateTime curDate)
        {
            string login = WebConfigurationManager.AppSettings["login"];
            string pass = WebConfigurationManager.AppSettings["pass"];
            string selectedPost = WebConfigurationManager.AppSettings["Post"];
            Dictionary<int, Employee[]> duties = new Dictionary<int, Employee[]>();
            var dutyLists = db.Duties.Include(x => x.Employee).Where(x => x.DutyDate.Year == curDate.Year
                    && x.DutyDate.Month == curDate.Month).OrderBy(x => x.DutyDate).ToList();
            var dates = dutyLists.Select(x => x.DutyDate).Distinct();

            foreach (DateTime s in dates)
            {
                Employee[] emps = dutyLists.Where(x => x.DutyDate == s).Select(x => x.Employee).ToArray();
                duties.Add(s.Day, emps);
            }

            Helpers.SendSchedule sendSchedule = new Helpers.SendSchedule(db.Employees.Select(x => x.Email).ToArray(),
                "График дежурств", "Изучите график дежурств на текущий месяц", curDate, duties);

            switch (selectedPost)
            {
                case "SMTP":
                    sendSchedule.Send(new SendingSMTP(login, pass));
                    break;
                case "Exchange":
                    sendSchedule.Send(new SendingExchange());
                    break;
            }

            return View();
        }
    }
}