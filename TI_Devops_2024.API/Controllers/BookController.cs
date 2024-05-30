using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024.API.Models;
using TI_Devops_2024.API.Mappers;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
        public ActionResult<IEnumerable<Book>> GetALL()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> GetByISBN([FromRoute]string isbn)
        {
            try
            {
                Book? book = _bookService.GetByISBN(isbn);
                if(book is not null)
                {
                    return Ok(book);
                }
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Create([FromBody]BookFormDTO book) 
        {
            if (ModelState.IsValid)
            {
                string isbnAjoute = _bookService.Create(book.ToBook());
                return CreatedAtAction("GetByISBN", new { isbn = isbnAjoute }, isbnAjoute);
            }

            return BadRequest();
        }


    }
}
