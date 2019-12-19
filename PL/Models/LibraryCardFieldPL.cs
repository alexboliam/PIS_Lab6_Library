using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class LibraryCardFieldPL
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Required]
        public virtual BookPL Book { get; set; }

        [Required]
        public virtual LibraryCardPL LibraryCard { get; set; }
    }
}
