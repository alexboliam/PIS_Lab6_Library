using AutoMapper;
using BLL.Dtos;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class LibraryCardsService : ILibraryCardsService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public LibraryCardsService(IMapper mapper, IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public IEnumerable<LibraryCardDto> GetAllLibraryCards()
        {
            return mapper.Map<IEnumerable<LibraryCardDto>>(unit.Students.FindAll().ToList());
        }

        public LibraryCardDto GetLibraryCardByStudent(StudentDto student)
        {
            return mapper.Map<LibraryCardDto>(unit.Students.FindByCondition(x=>x.StudentId == student.StudentId).FirstOrDefault());
        }
    }
}
