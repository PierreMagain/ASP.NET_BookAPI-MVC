using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024.API.Models;
using TI_Devops_2024.API.Mappers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TI_Devops_2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookShortDTO>))]
        public ActionResult<IEnumerable<BookShortDTO>> GetAll()
        {
            
            return Ok(_bookService.GetAll().Select(b => b.ToShortDTO()));
        }

        [Authorize]
        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDetailsDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDetailsDTO> GetByISBN([FromRoute] string isbn)
        {
            Claim? claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int id = int.Parse(claimId.Value);

            if(id != 1)
            {
                return Unauthorized("Seul l'admin peut voir les détails des livres");
            }

            if (string.IsNullOrWhiteSpace(isbn))
                return BadRequest("ISBN ne peut pas être vide");

            try
            {
                return Ok(_bookService.GetFullByISBN(isbn).ToDetailsDTO());
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Create([FromBody] BookFormDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                string isbnAdded = _bookService.Create(book.ToBook());
                return CreatedAtAction(nameof(GetByISBN), new { isbn = isbnAdded }, isbnAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{isbn}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Delete([FromRoute] string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return BadRequest("ISBN ne peut pas être vide");

            try
            {

                bool isDeleted = _bookService.Delete(isbn);

                if (isDeleted)
                {
                    return NoContent();
                }
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return BadRequest();

        }


        [HttpPut("{isbn}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Update([FromRoute] string isbn, [FromBody] BookFormDTO book)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return BadRequest("ISBN ne peut pas être vide");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool isUpdated = _bookService.Update(isbn, book.ToBook());
                if (isUpdated)
                {
                    return NoContent();
                }
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return BadRequest();

        }

        //[HttpPut("{isbn}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Update([FromRoute] string isbn, [FromBody] BookFormDTO book)
        //{
        //    if (string.IsNullOrWhiteSpace(isbn))
        //        return BadRequest("ISBN ne peut pas être vide");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        bool updated = _bookService.Update(isbn, book.ToBook());
        //        if (updated)
        //            return NoContent();
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return BadRequest("Update échouée.");
        //}

        //[HttpDelete("{isbn}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult Delete([FromRoute] string isbn)
        //{
        //    if (string.IsNullOrWhiteSpace(isbn))
        //        return BadRequest("ISBN ne peut pas être vide");

        //    try
        //    {
        //        bool deleted = _bookService.Delete(isbn);
        //        if (deleted)
        //            return NoContent();
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }

        //    return BadRequest();
        //}
    }
}
