using System.Web.Mvc;
using DBModels;

namespace CalendarWebsite.Models
{
	public class UserAddForm
	{
		public User User { get; set; }

		public string[] Logins { get; set; }
	}
}