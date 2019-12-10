using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class BookPL
    {
        public Guid BookId { get; set; }
        public bool IsAvailable { get; set; }
        public virtual CategoryPL Category { get; set; }
        public virtual AuthorPL Author { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name length must be less then 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Description length must be less then 250 characters")]
        public string Description { get; set; }
    }
}
