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
        public virtual AuthorDto Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
