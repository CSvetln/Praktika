using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
    [Table("Duties")]
    public class Duty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DutyDate { get; set; } //дата дежурства

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }   //дежурный
    }
}