using TI_Devops_2024.API.Models;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024.API.Mappers
{
    public static class BookMapper
    {
        public static Book ToBook(this BookFormDTO book)
        {
            return new Book
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Description = book.Description,
                PublishDate = book.PublishDate,
                AuthorId = book.AuthorId,
            };
        }
    }
}
