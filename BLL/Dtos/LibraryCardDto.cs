using System;
using System.Collections.Generic;

namespace BLL.Dtos
{
    public class LibraryCardDto
    {
        public Guid LibraryCardId { get; set; }
        public Guid StudentId { get; set; }
        public virtual StudentDto Student { get; set; }
    }
}
