using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public virtual CategoryDto ParentCategory { get; set; }
        public string CategoryName { get; set; }

    }
}
