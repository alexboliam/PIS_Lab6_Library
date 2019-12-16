using AutoMapper;
using BLL.Dtos;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class AuthorsService : IAuthorsService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public AuthorsService(IMapper mapper, IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = unit.Authors.FindAll().ToList();
            return mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public IEnumerable<AuthorDto> GetAuthorById(Guid authorId)
        {
            var authors = unit.Authors.FindByCondition(x => x.AuthorId.Equals(authorId)).ToList();
            return mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public IEnumerable<AuthorDto> GetAuthorByName(string name)
        {
            var authors = unit.Authors.FindByCondition(x => x.FullName.Contains(name)).ToList();
            return mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public void AddAuthor(AuthorDto author)
        {
            var newAuthors = mapper.Map<DAL.Models.Author>(author);

            unit.Authors.Create(newAuthors);
            unit.Save();
        }
        public void DeleteAuthor(AuthorDto author)
        {
            var newAuthors = mapper.Map<DAL.Models.Author>(author);

            unit.Authors.Delete(newAuthors);
            unit.Save();
        }
        public void UpdateAuthor(AuthorDto author)
        {
            var newAuthors = mapper.Map<DAL.Models.Author>(author);

            unit.Authors.Update(newAuthors);
            unit.Save();
        }
    }
}
