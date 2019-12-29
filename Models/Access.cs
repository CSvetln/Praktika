using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System;

namespace LibraryModels
{
	public class Access
	{
		[Key]
		public int AccessId { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public bool AllowedEdit { get; set; }

		public SelectList Logins { get; set; }

		public Access(string login, bool allowedEdit, SelectList logins)
		{
			this.Login = login;
			this.AllowedEdit = allowedEdit;
			this.Logins = logins;
		}

		public Access()
		{
		}

	}
}