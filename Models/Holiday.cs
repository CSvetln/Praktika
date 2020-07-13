using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModels
{
    [Table("Holidays")]
    public class Holiday
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public DateTime DateValue { get; set; }
    }
}