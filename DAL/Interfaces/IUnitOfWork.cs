using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        ICategoryRepository Category { get; }
        ILibraryCardRepository LibraryCards { get; }
        ILibraryCardFieldRepository LibraryCardFields { get; }
        IStudentRepository Students { get; }
        void Save();
    }
}
