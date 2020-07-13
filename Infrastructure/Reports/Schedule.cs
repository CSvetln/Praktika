using System;
using ClosedXML.Excel;
using System.IO;
using System.Collections.Generic;
using DBModels;

namespace Helpers.Reports
{
    public class Schedule : IReport
    {
        Dictionary<int, Employee[]> duties;
        DateTime date;

        public Schedule(Dictionary<int, Employee[]> duties, DateTime date)
        {
            this.duties = duties;
            this.date = date;
        }

        public MemoryStream CreateReport()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("График");
            worksheet.Range("A1:E1").Row(1).Merge();
            DateTime Start = new DateTime(date.Year, date.Month, 1);
            worksheet.Cell("A" + 1).Value = String.Format("График дежурств на {0} - {1}", Start.ToLongDateString(), Start.AddMonths(1).AddDays(-1).ToLongDateString());

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
                    for (int j = 0; j < duties[Start.Day].Length; j++)
                    {
                        worksheet.Cell(i, j + 2).Value = duties[Start.Day][j].FullName;

                    }
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