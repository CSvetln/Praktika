using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
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