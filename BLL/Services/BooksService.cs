using AutoMapper;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using BLL.Dtos;
using System.Linq;
using System.Collections.Generic;
using System;
using BLL.Interfaces;

namespace BLL.Services
{
    public class BooksService : IBooksService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public BooksService(IMapper mapper, IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = unit.Books.FindAll().ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
        public IEnumerable<BookDto> GetBooksByName(string name)
        {
            var books = unit.Books.FindByCondition(x => x.Name.Contains(name)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
        public BookDto GetBookById(Guid id)
        {
            var book = unit.Books.FindByCondition(x => x.BookId.Equals(id)).FirstOrDefault();
            return mapper.Map<BookDto>(book);
        }
        public IEnumerable<BookDto> GetBooksByAuthorName(string authorName)
        {
            var books = unit.Books.FindByCondition(x => x.Author.FullName.Contains(authorName)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
        public IEnumerable<BookDto> GetBooksByAuthorId(Guid authorId)
        {
            var books = unit.Books.FindByCondition(x => x.Author.AuthorId.Equals(authorId)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
        public IEnumerable<BookDto> GetBooksByCategoryName(string categoryName)
        {
            var books = unit.Books.FindByCondition(x => x.Category.CategoryName.Contains(categoryName)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
        public IEnumerable<BookDto> GetBooksByCategoryId(Guid categoryId)
        {
            var books = unit.Books.FindByCondition(x => x.Category.CategoryId.Equals(categoryId)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }

        public void AddBook(BookDto book)
        {
            var newBook = mapper.Map<DAL.Models.Book>(book);

            newBook.Author = LoadAuthor(book);
            newBook.Category = LoadCategory(book);

            unit.Books.Create(newBook);
            unit.Save();
        }
        public void UpdateBook(BookDto book)
        { 
            var newBook = mapper.Map<DAL.Models.Book>(book);

            newBook.Author = LoadAuthor(book);
            newBook.Category = LoadCategory(book);

            unit.Books.Update(newBook);
            unit.Save();
        }
        public void DeleteBook(BookDto book)
        {
            var deletedBook = mapper.Map<DAL.Models.Book>(book);

            deletedBook.Author = LoadAuthor(book);
            deletedBook.Category = LoadCategory(book);

            unit.Books.Delete(deletedBook);
            unit.Save();
        }

        private DAL.Models.Author LoadAuthor(BookDto book)
        {
            return unit.Authors.FindByCondition(x => x.FullName == book.Author.FullName).FirstOrDefault();
        }
        private DAL.Models.Category LoadCategory(BookDto book)
        {
            return unit.Category.FindByCondition(x => x.CategoryName == book.Category.CategoryName).FirstOrDefault();
        }
    }
}
