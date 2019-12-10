using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper mapper;

        public StudentsController(IStudentsService studentsService, IMapper mapper)
        {
            this.studentsService = studentsService;
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
    }
}