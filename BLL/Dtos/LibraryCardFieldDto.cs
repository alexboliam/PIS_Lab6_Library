using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos
{
    public class LibraryCardFieldDto
    {
        public Guid Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Required]
        public virtual BookDto Book { get; set; }

        [Required]
        public virtual LibraryCardDto LibraryCard { get; set; }
    }
}
