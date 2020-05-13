using System.Web.Mvc;

namespace DutyOfServiceDepart.Models
{
	public class Access
	{
		public string Login { get; set; }

		public SelectList Logins { get; set; }
	}
}