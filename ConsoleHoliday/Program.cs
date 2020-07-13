using System;
using System.Net;
using DBModels;

namespace HolidayUtility
{
    public class Program
    {
        const String BASE_URL = "https://isdayoff.ru";
        const String HOLIDAY_RESPONSE = "1";

        public static void Main(string[] args)
        {
            DateTime start = DateTime.Parse(args[0]);
            int periodLength = int.Parse(args[1]); //0 - дата, с которой загружать, 1 - количество дней

            GetHoliday(start, periodLength);
            Console.ReadKey();
        }

        public static void GetHoliday(DateTime beginDate, int periodLength)
        {
            using (DutyContext db = new DutyContext())
            {
                using (WebClient webClient = new WebClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    DateTime endDate = beginDate.AddDays(periodLength);

                    while (beginDate <= endDate)
                    {
                        string url = String.Format("{0}/{1}?cc=ru", BASE_URL, beginDate.ToString("yyyyMMdd"));
                        string response = webClient.DownloadString(url);

                        if (response == HOLIDAY_RESPONSE)
                        {
                            Console.WriteLine(String.Format("Обнаружен выходной {0}", beginDate));
                            db.Holidays.Add(new Holiday() { DateValue = beginDate });
                        }

                        beginDate = beginDate.AddDays(1);
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
