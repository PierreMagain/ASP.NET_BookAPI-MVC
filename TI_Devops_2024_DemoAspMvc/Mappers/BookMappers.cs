using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Mappers
{
    public static class BookMappers
    {

        public static BookShortDTO ToShortDTO(this Book b)
        {
            return new BookShortDTO()
            {
                ISBN = b.ISBN,
                Title = b.Title,
                PublishDate = b.PublishDate
            };
        }

        public static Book ToEntity(this BookFormDTO b)
        {
            return new Book()
            {
                ISBN = b.ISBN,
                Title = b.Title,
                Description = b.Description,
                PublishDate = b.PublishDate,
                AuthorId = b.AuthorId
            };
        }

        public static BookFormDTO toFormDTO(this Book b)
        {
            return new BookFormDTO()
            {
                ISBN = b.ISBN,
                Title = b.Title,
                Description = b.Description,
                PublishDate = b.PublishDate,
                AuthorId = b.AuthorId
            };
        }

        public static BookDetailsDTO ToDetailsDTO(this Book b)
        {
            return new BookDetailsDTO()
            {
                ISBN = b.ISBN,
                Title = b.Title,
                Description = b.Description,
                PublishDate = b.PublishDate.ToShortDateString(),
                Author = b.Author!.toDTO()
            };
        }
    }
}
