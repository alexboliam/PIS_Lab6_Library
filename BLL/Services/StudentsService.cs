using AutoMapper;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Dtos;
using BLL.Interfaces;

namespace BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public StudentsService(IMapper mapper, IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public StudentDto GetStudentByName(string name)
        {
            return mapper.Map<StudentDto>( unit.Students.FindByCondition(x => x.FullName == name).FirstOrDefault() );
        }
        public StudentDto GetStudentById(Guid id)
        {
            return mapper.Map<StudentDto>(unit.Students.FindByCondition(x => x.StudentId == id).FirstOrDefault());
        }
        public IEnumerable<StudentDto> GetAllStudents()
        {
            return mapper.Map<IEnumerable<StudentDto>>( unit.Students.FindAll().OrderBy(x=>x.FullName).ToList() );
        }

        public bool AddStudent(StudentDto student)
        {
            var newStudent = mapper.Map<DAL.Models.Student>(student);

            var check = unit.Students.FindByCondition(x => x.Login == student.Login).Count();

            if(check != 0)
            {
                return false;
            }
            else
            {
                unit.Students.Create(newStudent);
                unit.Save();
                return true;
            }
        }
        public void UpdateStudent(StudentDto student)
        {
            var newStudent = mapper.Map<DAL.Models.Student>(student);

            newStudent.LibraryCard = LoadCard(student);

            unit.Students.Update(newStudent);
            unit.Save();
        }
        public void DeleteStudent(StudentDto student)
        {
            var deleteStudent = mapper.Map<DAL.Models.Student>(student);

            deleteStudent.LibraryCard = LoadCard(student);

            unit.Students.Delete(deleteStudent);
            unit.Save();
        }

        public Guid? Authorize(string login)
        {
            var student = unit.Students.FindByCondition(x => x.Login == login).FirstOrDefault();
            if(student==null)
            {
                return null;
            }
            else
            {
                return (Guid?)student.StudentId;
            }
        }

        #region Private methods
        private DAL.Models.LibraryCard LoadCard(StudentDto student)
        {
            return unit.LibraryCards.FindByCondition(x => x.StudentId.Equals(student.StudentId)).FirstOrDefault();
        } 
        #endregion

    }
}
