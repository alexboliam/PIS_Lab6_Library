using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class LibraryCardPL
    {
        public Guid LibraryCardId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
        public virtual StudentPL Student { get; set; }
    }
}
