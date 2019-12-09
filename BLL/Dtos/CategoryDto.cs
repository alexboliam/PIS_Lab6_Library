using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public virtual CategoryDto ParentCategory { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for category name is 50")]
        public string CategoryName { get; set; }

    }
}
