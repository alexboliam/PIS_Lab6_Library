using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class AuthorPL
    {
        public Guid AuthorId { get; set; }
        public string FullName { get; set; }
        public virtual IEnumerable<BookPL> Books { get; set; }
    }
}
