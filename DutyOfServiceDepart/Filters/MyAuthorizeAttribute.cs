using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;

namespace CalendarWebsite.Filters
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            using (DutyContext db = new DutyContext())
            {
                string domainLogin = HttpContext.Current.User.Identity.Name;

                User user = db.Users.Where(x => x.DomainLogin == domainLogin).FirstOrDefault();

                if (user == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Error" }, { "action", "NoAuthorization" }});
                }

                else
                {
                    if (!user.CanEdit)
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary {
                        { "controller", "Error" }, { "action", "NotAvailable" }});
                    }
                }
            }
        }
    }
}