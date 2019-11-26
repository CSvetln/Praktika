using DutyOfServiceDepart.Models;
using System;
using System.Linq;
using System.Data.Entity;
using ClosedXML.Excel;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace DutyOfServiceDepart.SendSchedule
{
	public class Schedule
	{
		public static MemoryStream GetSchedule(DateTime CurDate)
		{
			var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add("График");
			worksheet.Range("A1:E1").Row(1).Merge();
			DateTime Start = new DateTime(CurDate.Year, CurDate.Month, 1);
			worksheet.Cell("A" + 1).Value = "График дежурств на " + Start.ToLongDateString() + "-" + Start.AddMonths(1).AddDays(-1).ToLongDateString();

			Calendar calendar = new Calendar
			{
				CurrentDate = CurDate
			};
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
			MemoryStream stream = new MemoryStream();
			
			workbook.SaveAs(stream);
			stream.Position = 0;
			return stream;
						
		}		
	}
}