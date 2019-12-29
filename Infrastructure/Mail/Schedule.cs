using System;
using ClosedXML.Excel;
using System.IO;
using System.Collections.Generic;

namespace Infrastructure.Mail
{
	public class Schedule
	{
		public static MemoryStream GetSchedule(Dictionary<int, string> duties, DateTime date)
		{
			var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add("График");
			worksheet.Range("A1:E1").Row(1).Merge();
			DateTime Start = new DateTime(date.Year, date.Month, 1);
			worksheet.Cell("A" + 1).Value = "График дежурств на " + Start.ToLongDateString() + "-" + Start.AddMonths(1).AddDays(-1).ToLongDateString();

			worksheet.Cell(2, 1).Value = "Число";
			worksheet.Cell(2, 1).Style.Font.Bold = true;
			worksheet.Cell(2, 2).Value = "Дежурный";
			worksheet.Cell(2, 2).Style.Font.Bold = true;

			int i = 3;

			while (true)
			{
				worksheet.Cell(i, 1).Value = Start.Day.ToString();
				if (duties.ContainsKey(Start.Day))
				{
					worksheet.Cell(i, 2).Value = duties[Start.Day];
				}
				else
				{
					worksheet.Cell(i, 2).Value = " ";
				}
				i++;
				Start = Start.AddDays(1);
				if (date.Month != Start.Month)
				{ break; }
			}

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			stream.Position = 0;
			return stream;
		}
	}
}