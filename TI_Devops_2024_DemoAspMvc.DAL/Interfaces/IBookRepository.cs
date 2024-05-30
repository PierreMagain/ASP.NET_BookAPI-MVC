using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.DAL.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book,string> 
    {
        Book? GetFullByISBN(string ISBN);

        bool ExistByUnicityCriteria(Book book);
        bool ExistByISBN(string isbn);
        bool ExistByUnicityCriteriaAndNotSameISBN(string isbn,Book book);
    }
}
