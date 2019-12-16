using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHoliday
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}
		//public static async void GetHolidayMonth(DateTime start)
		//{
		//	WebClient webClient = new WebClient();
		//	ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

		//	DateTime finish = start.AddMonths(2);
		//	while (start != finish)
		//	{

		//		string url = "https://isdayoff.ru/" + start.ToString("yyyyMMdd") + "?cc=ru";
		//		string response = await Task.Run(() => webClient.DownloadString(url));

		//		if (response == "1")
		//			db.Holidays.Add(new Holidays(start));

		//		start = start.AddDays(1);
		//	}
		//	//webClient.Dispose();
		//	db.SaveChanges();
		//}
	}
}
