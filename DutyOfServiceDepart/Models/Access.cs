using System.ComponentModel.DataAnnotations;

namespace DutyOfServiceDepart.Models
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