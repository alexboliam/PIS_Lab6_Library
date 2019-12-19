﻿using System;
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
    [Route("api/auth")]
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

        /// <summary>
        /// Log In request for client's current session. Returns student Id.
        /// </summary>
        /// <param name="Login">Unique string with max length 50.</param>
        /// <response code="200">**Success**. Return specified student.</response>
        /// <response code="409">**Conflict**. Student with specified login not found.</response>
        /// <response code="500">**Server error**. Internal server error.</response>
        /// <returns></returns>
        [HttpGet("{login}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult Authorize(string login)
        {
            try
            {
                var id = studentsService.Authorize(login);
                if(id == null)
                {
                    return StatusCode(409, "Student with that login not found");
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

        /// <summary>
        /// Register student in database.
        /// </summary>
        /// <param name="student"> Requesting JSON model fields:
        ///
        /// studentId     | Can be missed. New Id will be generated by server.
        /// login         | Required, max length 50 chars, must be unique
        /// fullName      | Required, max length 5o chars
        /// libraryCard   | Can be missed. New library card will be generated by server.
        /// </param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/authorize
        ///     {        
        ///       "login": "sample-login",
        ///       "fullName": "Sample Login"     
        ///     }
        /// </remarks>
        /// <response code="200">**Success**. Returns the newly registered student's Id.</response>
        /// <response code="400">**Bad Request**. Model is not valid or null.</response>  
        /// <response code="409">**Conflict**. Student with such login already exists.</response>  
        /// <response code="500">**Server error**. Internal server error.</response>  
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
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
                var id = studentsService.AddStudent(newStudent);
                if(id != null)
                {
                    return Ok((Guid)id);
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