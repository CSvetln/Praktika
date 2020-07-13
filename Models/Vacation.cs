using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
    [Table("Vacations")]
	public class Vacation
	{
		[Key]
		public Int32 Id { get; set; }

        [Required]
        public Int32 EmployeeId { get; set; }
        		
		public virtual Employee Employee { get; set; }

		[Required]
		public DateTime BeginDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }
	}
}