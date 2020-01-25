using System;
using LibraryModels;
using System.Net;

namespace ConsoleHoliday
{
	public class Program
	{
		public static void Main()
		{
			//GetHoliday(start, countDays);
			//Console.ReadKey();	
		}

		public static void GetHoliday(DateTime start, int countDays)
		{
			DutyContext db = new DutyContext();

			WebClient webClient = new WebClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			DateTime finish = start.AddDays(countDays);

			while (start <= finish)
			{
				string url = "https://isdayoff.ru/" + start.ToString("yyyyMMdd") + "?cc=ru";
				Console.WriteLine(start.ToString("yyyyMMdd"));
				string response = webClient.DownloadString(url);

				if (response == "1")
				{
					Console.WriteLine("Загружено");
					db.Holidays.Add(new Holidays(start));
				}

				start = start.AddDays(1);
			}

			db.SaveChanges();
			Console.ReadKey();
		}
	}
}
