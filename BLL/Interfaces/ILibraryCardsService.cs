using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ILibraryCardsService
    {
        IEnumerable<LibraryCardDto> GetAllLibraryCards();
        LibraryCardDto GetLibraryCardById(Guid id);
        public LibraryCardDto GetLibraryCardByStudent(StudentDto student);
        void AddLibraryCard(LibraryCardDto libraryCard);
        void UpdateLibraryCard(LibraryCardDto libraryCard);
        void DeleteLibraryCard(LibraryCardDto libraryCard);
        bool TakeBook(Guid bookId, Guid studentId, DateTime issueDate);
        bool ReturnBook(Guid bookId, Guid studentId, DateTime returnDate);


        IEnumerable<LibraryCardFieldDto> GetFields(Guid libraryCardId);
        LibraryCardFieldDto GetFieldById(Guid FieldId);

        void AddField(LibraryCardFieldDto field);
        void UpdateField(LibraryCardFieldDto field);
        void DeleteField(LibraryCardFieldDto field);
    }
}
