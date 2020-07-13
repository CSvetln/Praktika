using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
    [Table("AccidentWorks")]
	public class AccidentWork
	{
		[Key]
		public Int32 Id { get; set; }

		[Required]
		public DateTime AccidentDate { get; set; } //дата чп	
		
		public int? EmployeeId { get; set; }

		public virtual Employee Employee { get; set; } //кого вызвали туда

        [Required]
        public string Description { get; set; } //описание чп
	}
}