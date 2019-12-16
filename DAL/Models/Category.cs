using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for category name is 50")]
        public string CategoryName { get; set; }

    }
}
