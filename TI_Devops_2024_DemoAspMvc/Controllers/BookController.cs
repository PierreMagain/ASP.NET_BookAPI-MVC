using Microsoft.AspNetCore.Mvc;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024_DemoAspMvc.Infrastuctures;
using TI_Devops_2024_DemoAspMvc.Mappers;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            List<BookShortDTO> books = _bookService.GetAll()
                                            .Select(b => b.ToShortDTO())
                                            .ToList();

            return View(books);
        }

        [AuthRequired]
        public IActionResult Add()
        {
            List<AuthorDTO> authors = _authorService.GetAll()
                                        .Select(a => a.toDTO())
                                        .ToList();
            ViewData["authors"] = authors;
            return View(new BookFormDTO());
        }

        [AuthRequired]
        [HttpPost]
        public IActionResult Add([FromForm] BookFormDTO form)
        {
            if(!ModelState.IsValid)
            {
                List<AuthorDTO> authors = _authorService.GetAll()
                                        .Select(a => a.toDTO())
                                        .ToList();
                ViewData["authors"] = authors;
                return View(form);
            }
            _bookService.Create(form.ToEntity());
            return RedirectToAction("Index");
        }

        public IActionResult Details(string isbn)
        {
            BookDetailsDTO book = _bookService.GetFullByISBN(isbn).ToDetailsDTO();

            return View(book);
        }

        [AuthRequired]
        public IActionResult Edit(string isbn)
        {
            ViewData["currentIsbn"] = isbn;
            BookFormDTO book = _bookService.GetByISBN(isbn).toFormDTO();
            List<AuthorDTO> authors = _authorService.GetAll()
                                        .Select(a => a.toDTO())
                                        .ToList();
            ViewData["authors"] = authors;
            return View(book);
        }

        [AuthRequired]
        [HttpPost]
        public IActionResult Edit(string currentIsbn, [FromForm] BookFormDTO form)
        {
            if(!ModelState.IsValid)
            {
                List<AuthorDTO> authors = _authorService.GetAll()
                                        .Select(a => a.toDTO())
                                        .ToList();
                ViewData["authors"] = authors;
                ViewData["currentIsbn"] = currentIsbn;
                return View(form);
            }
            _bookService.Update(currentIsbn, form.ToEntity());
            return RedirectToAction("Index");
        }

        [AuthRequired]
        public IActionResult Delete(string isbn)
        {
            _bookService.Delete(isbn);
            return RedirectToAction("Index");
        }
    }
}
