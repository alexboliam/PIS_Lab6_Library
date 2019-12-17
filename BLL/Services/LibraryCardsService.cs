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

        #region Library Cards stuff
        public IEnumerable<LibraryCardDto> GetAllLibraryCards()
        {
            return mapper.Map<IEnumerable<LibraryCardDto>>(unit.Students.FindAll().ToList());
        }
        public LibraryCardDto GetLibraryCardById(Guid id)
        {
            return mapper.Map<LibraryCardDto>(unit.LibraryCards.FindByCondition(x => x.LibraryCardId.Equals(id)).FirstOrDefault());
        }
        public LibraryCardDto GetLibraryCardByStudent(StudentDto student)
        {
            return mapper.Map<LibraryCardDto>(unit.Students.FindByCondition(x=>x.StudentId == student.StudentId).FirstOrDefault());
        }

        public void AddLibraryCard(LibraryCardDto libraryCard)
        {
            var newLibraryCards = mapper.Map<DAL.Models.LibraryCard>(libraryCard);

            newLibraryCards.Student = LoadStudent(libraryCard);

            unit.LibraryCards.Create(newLibraryCards);
            unit.Save();
        }
        public void DeleteLibraryCard(LibraryCardDto libraryCard)
        {
            var newLibraryCards = mapper.Map<DAL.Models.LibraryCard>(libraryCard);

            newLibraryCards.Student = LoadStudent(libraryCard);

            unit.LibraryCards.Delete(newLibraryCards);
            unit.Save();
        }
        public void UpdateLibraryCard(LibraryCardDto libraryCard)
        {
            var newLibraryCards = mapper.Map<DAL.Models.LibraryCard>(libraryCard);

            newLibraryCards.Student = LoadStudent(libraryCard);

            unit.LibraryCards.Update(newLibraryCards);
            unit.Save();
        }
        #endregion

        public bool TakeBook(Guid bookId, Guid studentId, DateTime issueDate)
        {
            var book = unit.Books.FindByCondition(x => x.BookId.Equals(bookId)).FirstOrDefault();
            var student = unit.Students.FindByCondition(x => x.StudentId.Equals(studentId)).FirstOrDefault();

            if (book != null && book.IsAvailable == true) // if this book is available
            {
                var fields = unit.LibraryCardFields.FindByCondition(x => x.LibraryCard.StudentId.Equals(studentId) && x.Book.IsAvailable == false);
                
                if (student != null && fields.Count() <= 10)
                { // if student exists and his/her limit of non-returned books is not exceeded
                    var libraryCard = student.LibraryCard; // take his/her library card

                    unit.LibraryCardFields.Create( new DAL.Models.LibraryCardField() {
                                Id = Guid.NewGuid(), // generate new id
                                Book = book, // student got this book
                                LibraryCard = libraryCard, // field is in this library card
                                IssueDate = issueDate, // note current date
                                ReturnDate = null // student still didn't return it
                            });

                    book.IsAvailable = false;

                    unit.Save(); // save changes
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public bool ReturnBook(Guid bookId, Guid studentId, DateTime returnDate)
        {
            var book = unit.Books.FindByCondition(x => x.BookId.Equals(bookId)).FirstOrDefault();
            var student = unit.Students.FindByCondition(x => x.StudentId.Equals(studentId)).FirstOrDefault();

            if (book != null)
            {
                var fields = unit.LibraryCardFields.FindByCondition(x => x.LibraryCard.StudentId.Equals(studentId) && x.Book.IsAvailable == false);

                if (student != null && fields.FirstOrDefault(x => x.Book == book) != null)
                {
                   

                    var field = fields.FirstOrDefault(x => x.Book == book);
                    field.ReturnDate = returnDate;
                    unit.LibraryCardFields.Update(field);

                    book.IsAvailable = true;

                    unit.Save();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        #region Fields stuff
        public IEnumerable<LibraryCardFieldDto> GetFields(Guid libraryCardId)
        {
            var libraryCard = unit.LibraryCards.FindByCondition(x => x.LibraryCardId.Equals(libraryCardId)).FirstOrDefault();

            if (libraryCard != null)
            {
                var fields = unit.LibraryCardFields.FindByCondition(x => x.LibraryCard.LibraryCardId.Equals(libraryCardId)).ToList();
                return mapper.Map<IEnumerable<LibraryCardFieldDto>>(fields);
            }
            else
            {
                return null;
            }
        }
        public LibraryCardFieldDto GetFieldById(Guid FieldId)
        {
            var field = unit.LibraryCardFields.FindByCondition(x => x.Id.Equals(FieldId)).FirstOrDefault();
            return mapper.Map<LibraryCardFieldDto>(field);
        }
        public void AddField(LibraryCardFieldDto field)
        {
            var newField = mapper.Map<DAL.Models.LibraryCardField>(field);

            newField.LibraryCard = LoadCard(field);
            newField.Book = LoadBook(field);

            unit.LibraryCardFields.Create(newField);
            unit.Save();
        }
        public void UpdateField(LibraryCardFieldDto field)
        {
            var newField = mapper.Map<DAL.Models.LibraryCardField>(field);

            newField.LibraryCard = LoadCard(field);
            newField.Book = LoadBook(field);

            unit.LibraryCardFields.Update(newField);
            unit.Save();
        }
        public void DeleteField(LibraryCardFieldDto field)
        {
            var deletedField = mapper.Map<DAL.Models.LibraryCardField>(field);

            deletedField.LibraryCard = LoadCard(field);
            deletedField.Book = LoadBook(field);

            unit.LibraryCardFields.Delete(deletedField);
            unit.Save();
        }
        #endregion

        #region Private methods
        private DAL.Models.Student LoadStudent(LibraryCardDto libraryCard)
        {
            return unit.Students.FindByCondition(x => x.StudentId == libraryCard.StudentId).FirstOrDefault();
        }
        private DAL.Models.LibraryCard LoadCard(LibraryCardFieldDto field)
        {
            return unit.LibraryCards.FindByCondition(x => x.LibraryCardId == field.LibraryCard.LibraryCardId).FirstOrDefault();
        }
        private DAL.Models.Book LoadBook(LibraryCardFieldDto field)
        {
            return unit.Books.FindByCondition(x => x.BookId == field.Book.BookId).FirstOrDefault();
        }
        #endregion

    }
}
