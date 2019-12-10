﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class LibraryCardPL
    {
        public Guid LibraryCardId { get; set; }
        public virtual StudentPL Student { get; set; }
        public virtual ICollection<LibraryCardFieldPL> Fields { get; set; }
    }
}