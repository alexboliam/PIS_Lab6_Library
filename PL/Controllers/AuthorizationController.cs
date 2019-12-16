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
    [Route("api/authorize")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IStudentsService studentsService;
        private IMapper mapper;

        public AuthorizationController(IStudentsService studentsService, IMapper mapper)
        {
            this.studentsService = studentsService;
            this.mapper = mapper;
        }

        [HttpGet("{Login}")]
        public IActionResult Authorize(string Login)
        {
            try
            {
                var id = studentsService.Authorize(Login);
                if(id == null)
                {
                    return StatusCode(400, "Student with that login not found");
                }
                else
                {
                    return Ok((Guid)id);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot authorize.");
            }
        }

        [HttpPost()]
        public IActionResult Register(StudentPL student)
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
                    return Ok(student.StudentId);
                }
                else
                {
                    return StatusCode(409, "Student with this login already exists.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot register student. Error message: " + ex);
            }
        }
    }
}