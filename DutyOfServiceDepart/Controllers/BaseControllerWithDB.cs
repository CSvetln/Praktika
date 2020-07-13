using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;

namespace CalendarWebsite.Controllers
{
    public class BaseControllerWithDB : Controller
    {
        protected DutyContext db = new DutyContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}