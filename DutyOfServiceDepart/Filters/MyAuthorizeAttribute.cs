using System.Linq;
using System.Web;
using System.Web.Mvc;
using DutyOfServiceDepart.Models;

namespace DutyOfServiceDepart.Filters
{
	public class MyAuthorizeAttribute: AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			using (DutyContext db = new DutyContext())
			{
				string Login = HttpContext.Current.User.Identity.Name;

				Access access = new Access();
				if (db.Accesses.Count() > 0)
					access = db.Accesses.Where(x => x.Login == Login).FirstOrDefault();

			
				
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
}