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
            CreateMap<AuthorPL, AuthorDto>().ReverseMap();
            CreateMap<BookPL, BookDto>();
                //.AfterMap((s, d) => d.Author = new AuthorDto())
                //.AfterMap((s, d) => d.Author.AuthorId = s.AuthorId)
                //.AfterMap((s, d) => d.Category = new CategoryDto())
                //.AfterMap((s, d) => d.Category.CategoryId = s.CategoryId);
            CreateMap<BookDto, BookPL>();
                //.AfterMap((s, d) => d.AuthorId = s.Author.AuthorId)
                //.AfterMap((s, d) => d.CategoryId = s.Category.CategoryId);
            CreateMap<CategoryPL, CategoryDto>().ReverseMap();
            CreateMap<LibraryCardPL, LibraryCardDto>().ReverseMap();
            CreateMap<LibraryCardFieldPL, LibraryCardFieldDto>().ReverseMap();
            CreateMap<StudentPL, StudentDto>().ReverseMap();


        }
    }
}
