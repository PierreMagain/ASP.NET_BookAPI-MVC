using Moq;
using System.Collections.Generic;
using TI_Devops_2024_DemoAspMvc.BLL.Services;
using TI_Devops_2024_DemoAspMvc.DAL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using Xunit;

namespace BookServiceTests
{
    public class BookServiceTests
    {

        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_Retourne_Livres()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "Test", ISBN = "99999999999" },
                new Book { Title = "Test2", ISBN = "88888888888" },
            };

            _bookRepositoryMock.Setup(repo => repo.GetAll()).Returns(books);

            IEnumerable<Book> results = _bookService.GetAll();

            Assert.Equal(books, results);
        }
    }
}