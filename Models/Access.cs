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

		public Access(string login, bool allowedEdit)
		{
			this.Login = login;
			this.AllowedEdit = allowedEdit;
		}

		public Access()
		{
		}

	}
}