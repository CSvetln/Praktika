using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Access
	{
		[Key]
		public int AccessId { get; set; }
		public string Login { get; set; }
		public bool AllowedEdit { get; set; }
	}
}