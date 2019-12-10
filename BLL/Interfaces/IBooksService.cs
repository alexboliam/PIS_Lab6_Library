using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBooksService
    {
        public IEnumerable<BookDto> GetAllBooks();
        public IEnumerable<BookDto> GetBooksByName(string name);
        public IEnumerable<BookDto> GetBooksByAuthorName(string authorName);
        public IEnumerable<BookDto> GetBooksByAuthorId(Guid authorId);
        public IEnumerable<BookDto> GetBooksByCategoryName(string categoryName);
        public IEnumerable<BookDto> GetBooksByCategoryId(Guid categoryId);
    }
}
