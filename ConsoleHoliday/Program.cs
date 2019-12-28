using System;
using LibraryModels;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleHoliday
{
	class Program
	{
		static void Main(string[] args)
		{
			GetHolidayMonth(DateTime.Now);
		}

		public static async void GetHolidayMonth(DateTime start)
		{
			DutyContext db = new DutyContext();

			WebClient webClient = new WebClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			DateTime finish = new DateTime(start.Year + 1, 12, 31);

			while (start != finish)
			{
				string url = "https://isdayoff.ru/" + start.ToString("yyyyMMdd") + "?cc=ru";
				string response = await Task.Run(() => webClient.DownloadString(url));

				if (response == "1")
					db.Holidays.Add(new Holidays(start));

				start = start.AddDays(1);
			}

			db.SaveChanges();
		}
	}
}
