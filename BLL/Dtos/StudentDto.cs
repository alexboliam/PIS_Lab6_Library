using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string FullName { get; set; }
        public virtual LibraryCardDto LibraryCard { get; set; }
    }
}
