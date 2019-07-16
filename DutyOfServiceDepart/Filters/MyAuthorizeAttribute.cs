using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DutyOfServiceDepart.Models;

namespace DutyOfServiceDepart.Filters
{
	public class MyAuthorizeAttribute: AuthorizeAttribute
	{
		DutyContext db = new DutyContext();
		
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			string Login = HttpContext.Current.User.Identity.Name;
		
			Access access = db.Accesses.Where(x => x.Login == Login).First();

			if (access == null)
			{
				filterContext.Result = new RedirectToRouteResult(
					new System.Web.Routing.RouteValueDictionary {
					{ "controller", "Error" }, { "action", "NoAuthorization" }});
			}
			else
			{
				if (!access.AllowedEdit)
				{
					filterContext.Result = new RedirectToRouteResult(
						new System.Web.Routing.RouteValueDictionary {
					{ "controller", "Home" }, { "action", "Index" }});
				}
			}
		}
	}
}