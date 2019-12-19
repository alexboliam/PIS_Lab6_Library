using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class AuthorPL
    {
        public Guid AuthorId { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
