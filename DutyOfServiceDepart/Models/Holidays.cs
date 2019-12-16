﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Holidays
	{
		[Key]
		public DateTime Holiday { get; set; }

		public Holidays(DateTime holiday)
		{
			this.Holiday = holiday;
		}

	}
}