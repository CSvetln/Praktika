using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Helpers
{
	public static class ListHelpersForIndex
	{		
		public static MvcHtmlString CreateCal(this HtmlHelper html, string[] items)
		{
			TagBuilder ul = new TagBuilder("ul");
			foreach (string item in items)
			{
				TagBuilder li = new TagBuilder("li");
				li.SetInnerText(item);
				ul.InnerHtml += li.ToString();
			}
			return new MvcHtmlString(ul.ToString());
		}
		
	}
}