using AutoMapper;
using BLL.Dtos;
using DAL.Models;

namespace BLL.Mappers
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<LibraryCard, LibraryCardDto>();
            CreateMap<LibraryCardField, LibraryCardFieldDto>();
            CreateMap<Student, StudentDto>();


            CreateMap<AuthorDto, Author>();
            CreateMap<BookDto, Book>();
            CreateMap<CategoryDto, Category>();
            CreateMap<LibraryCardDto, LibraryCard>();
            CreateMap<LibraryCardFieldDto, LibraryCardField>();
            CreateMap<StudentDto, Student>();
        }
    }
}
