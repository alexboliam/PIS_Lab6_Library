using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAuthorsService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        IEnumerable<AuthorDto> GetAuthorByName(string name);
        IEnumerable<AuthorDto> GetAuthorById(Guid authorId);

        void AddAuthor(AuthorDto author);
        void UpdateAuthor(AuthorDto author);
        void DeleteAuthor(AuthorDto author);
    }
}
