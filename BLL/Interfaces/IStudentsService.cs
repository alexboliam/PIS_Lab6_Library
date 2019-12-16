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
        StudentDto GetStudentById(Guid id);

        bool AddStudent(StudentDto student);
        void UpdateStudent(StudentDto student);
        void DeleteStudent(StudentDto student);

        Guid? Authorize(string login);
    }
}
