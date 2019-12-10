using AutoMapper;
using BLL.Dtos;
using DAL.Models;

namespace PL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<LibraryCard, LibraryCardDto>();
            CreateMap<LibraryCardField, LibraryCardFieldDto>();
            CreateMap<Student, StudentDto>();

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<LibraryCard, LibraryCardDto>().ReverseMap();
            CreateMap<LibraryCardField, LibraryCardFieldDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();

        }
    }
}
