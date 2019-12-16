using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class CategoryPL
    {
        public Guid CategoryId { get; set; }
        public virtual CategoryPL ParentCategory { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for category name is 50")]
        public string CategoryName { get; set; }

    }
}
