﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = booksService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of books.");
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetBooksByName(string name)
        {
            try
            {
                var books = booksService.GetBooksByName(name);

                if (books==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}