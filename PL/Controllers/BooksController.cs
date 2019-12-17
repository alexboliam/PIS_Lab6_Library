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
        ILibraryCardsService libraryCardsService;
        private IBooksService booksService;
        private IMapper mapper;
        public BooksController(IBooksService booksService, ILibraryCardsService libraryCardsService, IMapper mapper)
        {
            this.booksService = booksService;
            this.libraryCardsService = libraryCardsService;
            this.mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetBooks([FromQuery(Name = "author")] string author, [FromQuery(Name = "category")] string category, [FromQuery(Name = "name")] string name)
        {
            try
            {
                var books = booksService.GetAllBooks();

                if (!string.IsNullOrEmpty(author))
                {
                    books = books.Intersect(books.Where(x => x.Author.FullName == author)).ToList();
                }
                if (!string.IsNullOrEmpty(category))
                {
                    books = books.Intersect(books.Where(x => x.Category.CategoryName == category)).ToList();
                }
                if (!string.IsNullOrEmpty(name))
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
                return StatusCode(500, "Internal server error. Cannot get list of books. Error message: " + ex);
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

        [HttpPut("take")]
        public IActionResult TakeBook([FromQuery]Guid bookId, [FromQuery]Guid studentId, DateTime issueDate)
        {
            try
            {
                var taken = libraryCardsService.TakeBook(bookId, studentId, issueDate);

                if(taken)
                {
                    return StatusCode(204, "Book was taken.");
                }
                else
                {
                    return StatusCode(500, "Book was not taken.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Book is not taken. Exception message: " + ex);
            }
        }

        [HttpPut("return")]
        public IActionResult ReturnBook([FromQuery]Guid bookId, [FromQuery]Guid studentId, DateTime returnDate)
        {
            try
            {
                var taken = libraryCardsService.ReturnBook(bookId, studentId, returnDate);

                if (taken)
                {
                    return StatusCode(204, "Book was returned.");
                }
                else
                {
                    return StatusCode(500, "Book was not returned.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Book is not returned. Exception message: " + ex);
            }
        }
    }
}