using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = studentsService.GetAllStudents();
                return Ok(students);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of students.");
            }
        }
    }
}