using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class StudentPL
    {
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Login { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string FullName { get; set; }
        public virtual LibraryCardPL LibraryCard { get; set; }
    }
}
