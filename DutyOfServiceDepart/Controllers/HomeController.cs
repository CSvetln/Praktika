using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Mail;
using ClosedXML.Excel;
using System.IO;

namespace DutyOfServiceDepart.Controllers
{
	public class HomeController : Controller
	{
		DutyContext db = new DutyContext();

		[Authorize]
		[HttpGet]
		public ActionResult Index(DateTime? Start)
		{
			Calendar calendar;
			DateTime Target1 = Start.HasValue ? Start.Value : DateTime.Now.Date;

			calendar = GetCalendar(Target1);
			
			SelectList selectLogin = new SelectList(db.Employees, "EmployeId", "Name");
			ViewBag.Emp = selectLogin;
			return View(calendar);
		}

		private Calendar GetCalendar(DateTime Target)
		{
			using (DutyContext db = new DutyContext())
			{
				Calendar calendar = new Calendar();
				calendar.CurrentDate = Target;

				foreach (DutyList s in db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year && x.DateDuty.Month == calendar.CurrentDate.Month).ToList())
				{
					calendar.Duties.Add(s.DateDuty.Day, s.Employee);

				}
				return calendar;
			}
		}
		[MyAuthorize]
		[HttpPost]
		public ActionResult Edit(int selectedEmpId, DateTime DateEdit)
		{
			using (DutyContext db = new DutyContext())
			{
				Employee NewEmployee = db.Employees.Find(selectedEmpId);
				List<DutyList> dutyList = db.DutyLists.Where(x => x.DateDuty == DateEdit).ToList();
				if (dutyList.Count != 0)
				{
					foreach (DutyList s in dutyList)
					{
						db.Entry(s).State = EntityState.Modified;
						s.Employee = NewEmployee;
					}
				}
				else
				{
					DutyList NewDutyList = new DutyList() { DateDuty = DateEdit, Employee = NewEmployee, DecrDuty = String.Empty };
					db.DutyLists.Add(NewDutyList);
				}
				db.SaveChanges();
				string File = TimeTable(DateEdit);
				IMail sending = new SendingMailRu();
				
				sending.SendMail(NewEmployee.Email, File, "Изменения в графике дежурств", "Изучите новый график");		
				
				return RedirectToAction("Index");
			}
		}
		private string TimeTable(DateTime CurDate)
		{
			string path = Server.MapPath("~/Files/График дежурств.xlsx");
			FileStream fs;
			using (fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				var workbook = new XLWorkbook();
				var worksheet = workbook.Worksheets.Add("График");
				worksheet.Range("A1:E1").Row(1).Merge();
				DateTime Start = new DateTime(CurDate.Year, CurDate.Month, 1);
				worksheet.Cell("A" + 1).Value = "График дежурств на " + Start.ToLongDateString() + "-" + Start.AddMonths(1).AddDays(-1).ToLongDateString();

				Calendar calendar = new Calendar();
				calendar.CurrentDate = CurDate;
				using (DutyContext db = new DutyContext())
				{
					foreach (DutyList s in db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year && x.DateDuty.Month == calendar.CurrentDate.Month).ToList())
					{
						calendar.Duties.Add(s.DateDuty.Day, s.Employee);
					}
				}
				worksheet.Cell(2, 1).Value = "Число";
				worksheet.Cell(2, 1).Style.Font.Bold = true;
				worksheet.Cell(2, 2).Value = "Дежурный";
				worksheet.Cell(2, 2).Style.Font.Bold = true;
				int i = 3;
				while (true)
				{
					worksheet.Cell(i, 1).Value = Start.Day.ToString();
					if (calendar.Duties.ContainsKey(Start.Day))
					{
						worksheet.Cell(i, 2).Value = calendar.Duties[Start.Day].Name;
					}
					else
					{
						worksheet.Cell(i, 2).Value = " ";
					}
					i++;
					Start = Start.AddDays(1);
					if (calendar.CurrentDate.Month != Start.Month)
					{ break; }
				}
				while (!IsFileInUse(path))
				{
				
						workbook.SaveAs(fs);
						break;
					
				}

				return path;
			}
		}
		private static bool IsFileInUse(string path)
		{
			
			try
			{
				using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
									
				}
			}
			catch (IOException)
			{
				return true;
			}

			return false;
		}
		

		[MyAuthorize]
		public ViewResult SendAll(DateTime CurDate)
		{
			using (DutyContext db = new DutyContext())
			{
				string File = TimeTable(CurDate);
				IMail sending = new SendingMailRu();
				foreach (Employee e in db.Employees)
				{
					sending.SendMail(e.Email, File, "График дежурств", "Изучите график дежурств на текущий месяц");
				}

				return View();
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