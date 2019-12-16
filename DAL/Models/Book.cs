using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Book
    {
        public Guid BookId { get; set; } 
        public bool IsAvailable { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Name length must be less then 150 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(2500, ErrorMessage = "Description length must be less then 2500 characters")]
        public string Description { get; set; }   
        
    }
}
