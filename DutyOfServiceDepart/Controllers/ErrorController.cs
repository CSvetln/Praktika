using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
    public class ErrorController : Controller
    {
     
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