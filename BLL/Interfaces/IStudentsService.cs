using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IStudentsService
    {
        StudentDto GetStudentByName(string name);
        IEnumerable<StudentDto> GetAllStudents();
        bool TakeBook(BookDto book, StudentDto student, DateTime issueDate);
        bool ReturnBook(BookDto book, StudentDto student, DateTime returnDate);
    }
}
