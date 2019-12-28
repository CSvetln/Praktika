using DutyOfServiceDepart.Models;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult Index()
		{
			Error error = new Error();
			error =(Error)RouteData.Values["ExceptionObject"];
			///RouteData["ExceptionObject"]
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