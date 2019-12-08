using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string FullName { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
