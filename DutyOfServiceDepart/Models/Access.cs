using System.ComponentModel.DataAnnotations;

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