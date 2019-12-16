using System.ComponentModel.DataAnnotations;

namespace DutyOfServiceDepart.Models
{
	public class Employee
	{
		[Key]
		public int EmployeId { get; set; }

		[Required]
		public string Name { get; set; }

		[StringLength(100, MinimumLength = 6)]
		[MinLength(6)]
		[MaxLength(100)]
		[Required]
		public string Email { get; set; }

		[StringLength(100, MinimumLength =4)]
		[MinLength(4)]
		[MaxLength(100)]
		[Required]
		public string Login { get; set; }

		public Employee(string name, string email, string login)
		{
			this.Name = name;
			this.Email = email;
			this.Login = login;
		}

		public Employee()
		{
		}

	}
}