using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ILibraryCardsService
    {
        IEnumerable<LibraryCardDto> GetAllLibraryCards();
    }
}
