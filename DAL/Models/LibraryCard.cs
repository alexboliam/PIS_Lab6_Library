using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class LibraryCard
    {
        public Guid LibraryCardId { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<LibraryCardField> Fields { get; set; }
    }
}
