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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IMapper mapper;
        private IAuthorsService authorsService;
        public AuthorsController(IAuthorsService authorsService, IMapper mapper)
        {
            this.authorsService = authorsService;
            this.mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            try
            {
                var authors = authorsService.GetAllAuthors();
                
                if (authors == null || authors.Count() < 1)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<AuthorPL>>(authors));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of books.");
            }
        }

        [HttpGet("{AuthorId}")]
        public IActionResult GetAuthorById(Guid AuthorId)
        {
            try
            {
                var author = authorsService.GetAuthorById(AuthorId);

                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<AuthorPL>(author));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get author with id:" + AuthorId.ToString() + " . Error Message: " + ex);
            }
        }

        [HttpPost()]
        public IActionResult AddAuthor([FromBody] AuthorPL author)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                author.AuthorId = Guid.NewGuid();
                var newBook = mapper.Map<AuthorDto>(author);
                authorsService.AddAuthor(newBook);

                return StatusCode(201, "Author was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not added. Exception message: " + ex);
            }
        }

        [HttpPut("{AuthorId}")]
        public IActionResult UpdateBook(Guid AuthorId, [FromBody] AuthorPL author)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                author.AuthorId = AuthorId;
                var newAuthor = mapper.Map<AuthorDto>(author);
                authorsService.UpdateAuthor(newAuthor);
                return StatusCode(204, "Author was updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not updated. Exception message: " + ex);
            }
        }

        [HttpDelete("{AuthorId}")]
        public IActionResult DeleteBook(Guid AuthorId, [FromBody] AuthorPL author)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                author.AuthorId = AuthorId;
                var newAuthor = mapper.Map<AuthorDto>(author);
                authorsService.DeleteAuthor(newAuthor);
                return StatusCode(204, "Author was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Author is not deleted. Exception message: " + ex);
            }
        }


    }
}