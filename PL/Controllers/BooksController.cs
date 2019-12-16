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
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;
        private IMapper mapper;
        public BooksController(IBooksService booksService, IMapper mapper)
        {
            this.booksService = booksService;
            this.mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetBooks([FromQuery(Name = "author")] string author, [FromQuery(Name = "category")] string category, [FromQuery(Name = "name")] string name)
        {
            try
            {
                var books = booksService.GetAllBooks();
                List<BookDto> newbooks = new List<BookDto>();
                if (this.CheckQuery(author))
                {
                    books = books.Intersect(books.Where(x => x.Author.FullName == author)).ToList();
                }
                if (this.CheckQuery(category))
                {
                    var catBooks = booksService.GetBooksByCategoryName(category);
                    books = books.Intersect(books.Where(x => x.Category.CategoryName == category)).ToList();
                }
                if (this.CheckQuery(name))
                {
                    books = books.Intersect(books.Where(x=>x.Name==name)).ToList();
                }


                if (books == null || books.Count() < 1)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<BookPL>>(books));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of books.");
            }
        }

        [HttpGet("{BookId}")]
        public IActionResult GetAuthorById(Guid BookId)
        {
            try
            {
                var book = booksService.GetBookById(BookId);

                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<BookPL>(book));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get book with id:" + BookId.ToString() + " . Error Message: " + ex);
            }
        }

        [HttpPost()]
        public IActionResult AddBook([FromBody] BookPL book)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                book.BookId = Guid.NewGuid();
                var newBook = mapper.Map<BookDto>(book);
                booksService.AddBook(newBook);

                return StatusCode(201, "Book was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Book is not added. Exception message: " + ex);
            }
        }

        [HttpPut("{BookId}")]
        public IActionResult UpdateBook(Guid BookId,[FromBody] BookPL book)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                book.BookId = BookId;
                var newBook = mapper.Map<BookDto>(book);
                booksService.UpdateBook(newBook);
                return StatusCode(204, "Book was updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Book is not updated. Exception message: " + ex);
            }
        }

        [HttpDelete("{BookId}")]
        public IActionResult DeleteBook(Guid BookId, [FromBody] BookPL book)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                book.BookId = BookId;
                var newBook = mapper.Map<BookDto>(book);
                booksService.DeleteBook(newBook);
                return StatusCode(204, "Book was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Book is not deleted. Exception message: " + ex);
            }
        }

        private bool CheckQuery(string value)
        {
            return (value != null && value != string.Empty ) ? true : false;
        }
    }
}