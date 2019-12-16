using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Dtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsService studentsService;
        private ILibraryCardsService libraryCardsService;
        private IMapper mapper;

        public StudentsController(IStudentsService studentsService, ILibraryCardsService libraryCardsService, IMapper mapper)
        {
            this.studentsService = studentsService;
            this.libraryCardsService = libraryCardsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = studentsService.GetAllStudents();
                return Ok( mapper.Map<IEnumerable<StudentPL>>(students) );
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of students.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            try
            {
                var student = studentsService.GetStudentById(id);
                return Ok(mapper.Map<StudentPL>(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of students.");
            }
        }

        [HttpPost()]
        public IActionResult AddStudent([FromBody]StudentPL student)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                student.StudentId = Guid.NewGuid();
                var newStudent = mapper.Map<StudentDto>(student);
                var added = studentsService.AddStudent(newStudent);
                if(added)
                {
                    return StatusCode(201, "Student was created.");
                }
                else
                {
                    return StatusCode(409, "Student with this login already exists");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Student is not created. Exception message: " + ex);
            }
        }

        [HttpPut("{StudentId}")]
        public IActionResult UpdateStudent(Guid StudentId, [FromBody]StudentPL student)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                student.StudentId = StudentId;
                var newStudent = mapper.Map<StudentDto>(student);
                studentsService.UpdateStudent(newStudent);

                return StatusCode(204, "Student was updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Student is not updated. Maybe student is not found. Exception message: " + ex);
            }
        }

        [HttpDelete("{StudentId}")]
        public IActionResult DeleteStudent(Guid StudentId, [FromBody]StudentPL student)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                student.StudentId = StudentId;
                var newStudent = mapper.Map<StudentDto>(student);
                studentsService.DeleteStudent(newStudent);

                return StatusCode(204, "Student was deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Student is not deleted. Maybe student is not found. Exception message: " + ex);
            }
        }
    }
}