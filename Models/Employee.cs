using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MidlleName { get; set; }

        [StringLength(100, MinimumLength = 6)]
        [MinLength(6)]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [MinLength(4)]
        [MaxLength(100)]
        [Required]
        public string DomainLogin { get; set; }

        public String FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", LastName, FirstName, MidlleName);
            }
        }

        public virtual ICollection<Duty> DutyLists { get; set; }

        public virtual ICollection<AccidentWork> AccidentWorks { get; set; }
    }
}