using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Login { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string FullName { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
    }
}
