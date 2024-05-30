using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetByISBN(string isbn);
        Book GetFullByISBN(string isbn);
        int GetCount();
        string Create(Book b);
        bool Update(string isbn, Book b);
        bool Delete(string isbn);
    }
}
