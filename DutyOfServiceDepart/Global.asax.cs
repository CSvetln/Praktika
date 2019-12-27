using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DutyOfServiceDepart
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Database.SetInitializer(new DutyDbInitializer());
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		//protected void Application_Error(object sender, EventArgs e)
		//{
		//	var Exception = Server.GetLastError();

		//	var httpContext = ((HttpApplication)sender).Context;
		//	httpContext.Response.Clear();
		//	httpContext.ClearError();

		//	Models.Error Information = new Models.Error();
		//	Information.ExceptionPageUrl = Request.Url.ToString();
		//	Information.Message = Exception.Message;
		//	Information.StackTrace = Exception.StackTrace;
		//	Information.InnerExceptionMessage = Exception.InnerException == null ? String.Empty : Exception.InnerException.Message;
		//	Information.UserName = HttpContext.Current.User.Identity.Name;

		//	var routeData = new RouteData();
		//	routeData.Values["controller"] = "Error";
		//	routeData.Values["action"] = "Index";
		//	routeData.Values["ExceptionObject"] = Information;

		//	Server.ClearError();

		//	using (Controller controller = new Controllers.ErrorController())
		//	{
		//		((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
		//	}
		//}
	}
}
