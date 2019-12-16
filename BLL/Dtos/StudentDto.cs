using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Dtos
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public virtual LibraryCardDto LibraryCard { get; set; }
    }
}
