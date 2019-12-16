using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Dtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    [Route("api/librarycards")]
    [ApiController]
    public class LibraryCardsController : ControllerBase
    {
        private ILibraryCardsService libraryCardsService;
        private IMapper mapper;
        public LibraryCardsController(ILibraryCardsService libraryCardsService, IMapper mapper)
        {
            this.libraryCardsService = libraryCardsService;
            this.mapper = mapper;
        }

        #region Library Cards stuff
        [HttpGet()]
        public IActionResult GetLibraryCards()
        {
            try
            {
                var libraryCards = libraryCardsService.GetAllLibraryCards();

                if (libraryCards == null || libraryCards.Count() < 1)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<LibraryCardPL>>(libraryCards));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of library cards. Error message: " + ex);
            }
        }

        [HttpGet("{LibraryCardId}")]
        public IActionResult GetLibraryCardById(Guid LibraryCardId)
        {
            try
            {
                var libraryCard = libraryCardsService.GetLibraryCardById(LibraryCardId);

                if (libraryCard == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mapper.Map<LibraryCardPL>(libraryCard));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get library card with id:" + LibraryCardId.ToString() + " . Error Message: " + ex);
            }
        }

        [HttpPost()]
        public IActionResult AddLibraryCard([FromBody] LibraryCardPL libraryCard)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                libraryCard.LibraryCardId = Guid.NewGuid();
                var newCard = mapper.Map<LibraryCardDto>(libraryCard);
                libraryCardsService.AddLibraryCard(newCard);

                return StatusCode(201, "Library card was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card is not added. Exception message: " + ex);
            }
        }

        [HttpPut("{LibraryCardId}")]
        public IActionResult UpdateBook(Guid LibraryCardId, [FromBody] LibraryCardPL libraryCard)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                libraryCard.LibraryCardId = LibraryCardId;
                var newLibraryCard = mapper.Map<LibraryCardDto>(libraryCard);
                libraryCardsService.UpdateLibraryCard(newLibraryCard);
                return StatusCode(204, "Library card was updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card is not updated. Exception message: " + ex);
            }
        }

        [HttpDelete("{LibraryCardId}")]
        public IActionResult DeleteBook(Guid LibraryCardId, [FromBody] LibraryCardPL libraryCard)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                libraryCard.LibraryCardId = LibraryCardId;
                var newLibraryCard = mapper.Map<LibraryCardDto>(libraryCard);
                libraryCardsService.DeleteLibraryCard(newLibraryCard);
                return StatusCode(204, "Library card was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card is not deleted. Exception message: " + ex);
            }
        }
        #endregion

        #region Library Card Fields stuff
        [HttpGet("{LibraryCardId}/fields")]
        public IActionResult GetFields(Guid LibraryCardId)
        {
            try
            {
                var fields = libraryCardsService.GetFields(LibraryCardId);

                if (fields == null || fields.Count() < 1)
                {
                    return StatusCode(204, "No fields found for this library card");
                }
                else
                {
                    return Ok(mapper.Map<IEnumerable<LibraryCardFieldPL>>(fields));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of fields. Error message: " + ex);
            }
        }

        [HttpGet("fields/{FieldId}")]
        public IActionResult GetFieldsById(Guid FieldId)
        {
            try
            {
                var field = libraryCardsService.GetFieldById(FieldId);

                if (field == null)
                {
                    return StatusCode(204, "Cannot find library card field with id[" + FieldId + "]");
                }
                else
                {
                    return Ok(mapper.Map<LibraryCardFieldPL>(field));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Cannot get list of fields. Error message: " + ex);
            }
        }

        [HttpPost("{LibraryCardId}/fields")]
        public IActionResult AddField([FromBody] LibraryCardFieldPL field)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                field.Id = Guid.NewGuid();
                var newField = mapper.Map<LibraryCardFieldDto>(field);
                libraryCardsService.AddField(newField);

                return StatusCode(201, "Library card field was added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card field is not added. Exception message: " + ex);
            }
        }

        [HttpPut("{LibraryCardId}/fields/{FieldId}")]
        public IActionResult UpdateField(Guid LibraryCardId, Guid FieldId, [FromBody] LibraryCardFieldPL field)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                field.LibraryCard.LibraryCardId = LibraryCardId;
                field.Id = FieldId;

                var newField = mapper.Map<LibraryCardFieldDto>(field);

                libraryCardsService.UpdateField(newField);

                return StatusCode(204, "Library card field was updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card field is not updated. Exception message: " + ex);
            }
        }

        [HttpDelete("{LibraryCardId}/fields/{FieldId}")]
        public IActionResult DeleteField(Guid LibraryCardId, Guid FieldId, [FromBody] LibraryCardFieldPL field)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                field.LibraryCard.LibraryCardId = LibraryCardId;
                field.Id = FieldId;

                var newField = mapper.Map<LibraryCardDto>(field);

                libraryCardsService.DeleteLibraryCard(newField);
                return StatusCode(204, "Library card field was deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Library card field is not deleted. Exception message: " + ex);
            }
        }

        #endregion
    }
}