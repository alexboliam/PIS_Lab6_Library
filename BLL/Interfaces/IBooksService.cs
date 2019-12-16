using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBooksService
    {
        BookDto GetBookById(Guid id);
        IEnumerable<BookDto> GetAllBooks();
        IEnumerable<BookDto> GetBooksByName(string name);
        IEnumerable<BookDto> GetBooksByAuthorName(string authorName);
        IEnumerable<BookDto> GetBooksByAuthorId(Guid authorId);
        IEnumerable<BookDto> GetBooksByCategoryName(string categoryName);
        IEnumerable<BookDto> GetBooksByCategoryId(Guid categoryId);

        void AddBook(BookDto book);
        void UpdateBook(BookDto book);
        void DeleteBook(BookDto book);
    }
}
