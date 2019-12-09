using System;
using System.Collections.Generic;

namespace BLL.Dtos
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public string FullName { get; set; }
        public virtual IEnumerable<BookDto> Books { get; set; }
    }
}
