using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Dtos
{
    public class BookDto
    {
        public Guid BookId { get; set; } 
        public bool IsAvailable { get; set; }
        public virtual CategoryDto Category { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public virtual AuthorDto Author { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name length must be less then 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Description length must be less then 250 characters")]
        public string Description { get; set; }

        
        
    }
}
