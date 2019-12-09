using AutoMapper;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using BLL.Dtos;
using System.Linq;
using System.Collections.Generic;
using System;

namespace BLL.Services
{
    public class SearchService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public SearchService(string connection)
        {
            unit = new UnitOfWork(connection);
            mapper = Mappers.BLLMapperConfig.mapper;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = unit.Books.FindAll();
            return mapper.Map<IEnumerable<BookDto>>(books).ToList();
        }

        public IEnumerable<BookDto> GetBooksByName(string name)
        {
            var books = unit.Books.FindByCondition(x => x.Name.Contains(name)).ToList();
            return mapper.Map<IEnumerable<BookDto>>(books);
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
    }
}
