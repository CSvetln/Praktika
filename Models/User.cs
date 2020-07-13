using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{    
    [Table("Users")]
	public class User
    {
		[Key]
		public Int32 Id { get; set; }

		[Required]
		public string DomainLogin { get; set; }

		[Required]
		public bool CanEdit { get; set; }
	}
}