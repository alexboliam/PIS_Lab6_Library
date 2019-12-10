using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PL.Models;
using BLL.Dtos;

namespace PL.Mappers
{
    public class PLMappingProfile : Profile
    {
        public PLMappingProfile()
        {
            CreateMap<AuthorPL, AuthorDto>();
            CreateMap<BookPL, BookDto>();
            CreateMap<CategoryPL, CategoryDto>();
            CreateMap<LibraryCardPL, LibraryCardDto>();
            CreateMap<LibraryCardFieldPL, LibraryCardFieldDto>();
            CreateMap<StudentPL, StudentDto>();

            CreateMap<AuthorPL, AuthorDto>().ReverseMap();
            CreateMap<BookPL, BookDto>().ReverseMap();
            CreateMap<CategoryPL, CategoryDto>().ReverseMap();
            CreateMap<LibraryCardPL, LibraryCardDto>().ReverseMap();
            CreateMap<LibraryCardFieldPL, LibraryCardFieldDto>().ReverseMap();
            CreateMap<StudentPL, StudentDto>().ReverseMap();

        }
    }
}
