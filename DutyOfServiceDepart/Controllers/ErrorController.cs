using DutyOfServiceDepart.Models;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult Index()
		{
			Error error = (Error)RouteData.Values["ExceptionObject"];
			return View(error);
		}

		public ActionResult NoAuthorization()
		{
			return View();
		}

		public ActionResult NotAvailable()
		{
			return View();
		}
		
	}
}