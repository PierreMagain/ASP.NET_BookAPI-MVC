using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.DAL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.BLL.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetByISBN(string isbn)
        {
            Book? book = _bookRepository.GetById(isbn);
            if(book == null)
            {
                throw new KeyNotFoundException($"Book with ISBN : {isbn} doesn't exist");
            }
            return book;
        }

        public Book GetFullByISBN(string isbn)
        {
            Book? book = _bookRepository.GetFullByISBN(isbn);
            if(book == null)
            {
                throw new KeyNotFoundException($"Book with ISBN : {isbn} doesn't exist");
            }
            return book;
        }

        public int GetCount()
        {
            return _bookRepository.Count();
        }

        public string Create(Book b)
        {
            if (_bookRepository.ExistByUnicityCriteria(b))
            {
                throw new Exception("This book already exists");
            }
            return _bookRepository.Create(b);   
        }

        public bool Update(string isbn, Book b)
        {
            if (!_bookRepository.ExistByISBN(isbn))
            {
                throw new KeyNotFoundException($"Book with ISBN : {isbn} doesn't exist");
            }
            if(_bookRepository.ExistByUnicityCriteriaAndNotSameISBN(isbn, b))
            {
                throw new Exception("Error");
            }
            return _bookRepository.Update(isbn, b);
        }

        public bool Delete(string isbn)
        {
            if (!_bookRepository.ExistByISBN(isbn))
            {
                throw new KeyNotFoundException($"Book with ISBN : {isbn} doesn't exist");
            }
            return _bookRepository.Delete(isbn);
        }
    }
}
