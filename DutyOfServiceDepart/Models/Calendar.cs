using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using DBModels;

namespace CalendarWebsite.Models
{
    public class Calendar
    {
        public Dictionary<DateTime, Employee[]> Duties { get; set; } = new Dictionary<DateTime, Employee[]>();

        public DateTime CurrentDate { get; set; }

        public SelectList Emps { get; set; }

        public List<int> Holidays { get; set; }

        public Calendar Vacation { get; set; }

        private static Calendar GetInstanse(DateTime? start)
        {
            DutyContext db = new DutyContext();
            DateTime target = start ?? DateTime.Now.Date;
            Calendar calendar = new Calendar();
            calendar.CurrentDate = target;

            calendar.Emps = new SelectList(db.Employees.ToList(), "EmployeeId", "Name");

            calendar.Holidays = db.Holidays.Where(x => x.DateValue.Year == calendar.CurrentDate.Year
                  && x.DateValue.Month == calendar.CurrentDate.Month).Select(x => x.DateValue.Day).ToList();

            return calendar;
        }

        public static Calendar GetCalendarDuty(DateTime? start)
        {
            /*Метод создаёт экземепляр класса Calendar и записывает в него текущую дату и дежурных сотрудников в этом месяце */
            DutyContext db = new DutyContext();

            Calendar calendar = GetInstanse(start);

            var dutyLists = db.Duties.Include(x => x.Employee).Where(x => x.DutyDate.Year == calendar.CurrentDate.Year
                    && x.DutyDate.Month == calendar.CurrentDate.Month).OrderBy(x => x.DutyDate).ToList();

            var dates = dutyLists.Select(x => x.DutyDate).Distinct();

            foreach (DateTime s in dates)
            {
                Employee[] emps = dutyLists.Where(x => x.DutyDate == s).Select(x => x.Employee).ToArray();
                calendar.Duties.Add(s, emps); // Duties - массив пар значений - число месяца и сотрудник 
            }

            return calendar;
        }

        public static Calendar GetCalendarVacation(DateTime? start)
        {
            DutyContext db = new DutyContext();

            Calendar calendar = GetInstanse(start);

            DateTime current = new DateTime(calendar.CurrentDate.Year, calendar.CurrentDate.Month, 1);
            int allDayMonth = DateTime.DaysInMonth(calendar.CurrentDate.Year, calendar.CurrentDate.Month);
            DateTime last = new DateTime(calendar.CurrentDate.Year, calendar.CurrentDate.Month, allDayMonth);

            var vacations = db.Vacations.Include(x => x.Employee).Where(x => x.BeginDate >= current && x.BeginDate <= last
                || x.BeginDate < current && x.EndDate >= current).ToList();

            while (current <= last)
            {
                var emps = vacations.Where(x => x.BeginDate <= current && x.EndDate >= current).Select(x => x.Employee).ToArray();

                if (emps.Length != 0)
                    calendar.Duties.Add(current, emps);

                current = current.AddDays(1);
            }

            return calendar;
        }
    }
}