using AutoMapper;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Dtos;
using BLL.Interfaces;

namespace BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private IMapper mapper;
        private IUnitOfWork unit;
        public StudentsService(IMapper mapper, IUnitOfWork unit)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public StudentDto GetStudentByName(string name)
        {
            return mapper.Map<StudentDto>( unit.Students.FindByCondition(x => x.FullName == name).FirstOrDefault() );
        }
        public StudentDto GetStudentById(Guid id)
        {
            return mapper.Map<StudentDto>(unit.Students.FindByCondition(x => x.StudentId == id).FirstOrDefault());
        }
        public IEnumerable<StudentDto> GetAllStudents()
        {
            return mapper.Map<IEnumerable<StudentDto>>( unit.Students.FindAll().OrderBy(x=>x.FullName).ToList() );
        }
        public bool TakeBook(BookDto book, StudentDto student, DateTime issueDate) // student takes the book from library
        {
            if (book != null && book.IsAvailable == true) // if this book is available
            {

                if (student != null && student.LibraryCard.Fields.Where(x => x.Book.IsAvailable == false).Count() <= 10)
                { // if student exists and his/her limit of non-returned books is not exceeded
                    var libraryCard = student.LibraryCard; // take his/her library card

                    unit.LibraryCardFields.Create( 
                        mapper.Map<LibraryCardField>(
                            new LibraryCardFieldDto()
                            {
                                Id = Guid.NewGuid(), // generate new id
                                Book = book, // student got this book
                                LibraryCard = libraryCard, // field is in this library card
                                IssueDate = issueDate, // note current date
                                ReturnDate = null // student still didn't return it
                            }));

                    unit.Save(); // save changes
                    return true;
                }
                else { return false; }    
            }
            else { return false; }    
        }
        public bool ReturnBook(BookDto book, StudentDto student, DateTime returnDate)
        {
            if(book!=null)
            {
                if (student != null && student.LibraryCard.Fields.FirstOrDefault(x=>x.Book == book)!=null)
                {
                    book.IsAvailable = true;
                    unit.Books.Update(mapper.Map<Book>(book));

                    var field = student.LibraryCard.Fields.FirstOrDefault(x => x.Book == book);
                    field.ReturnDate = returnDate;
                    unit.LibraryCardFields.Update(mapper.Map<LibraryCardField>(field));

                    unit.Save();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

    }
}
