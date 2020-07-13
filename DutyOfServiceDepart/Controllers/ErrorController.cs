using System.Web.Mvc;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
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