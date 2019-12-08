using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class LibraryCardField
    {
        public Guid Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public virtual LibraryCard LibraryCard { get; set; }
    }
}
