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
		public string Login { get; set; }
		public int LevelAccess { get; set; }
	}
}