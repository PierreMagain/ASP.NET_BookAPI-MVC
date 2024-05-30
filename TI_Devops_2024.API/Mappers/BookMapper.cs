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

        public static BookDetailsDTO ToDetailsDTO(this Book book) 
        {
            return new BookDetailsDTO
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Description = book.Description,
                PublishDate = book.PublishDate.ToShortDateString(),
                Author = book.Author.toDTO(),
            };
        }

        public static BookShortDTO ToShortDTO(this Book book)
        {
            return new BookShortDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublishDate = book.PublishDate
            };

        }

        public static IEnumerable<BookShortDTO> ToListDTO(this IEnumerable<Book> books) 
        {
            List<BookShortDTO> list = new List<BookShortDTO>();

            foreach (Book item in books)
            {
                list.Add(item.ToShortDTO());
            }

            return list;
        }
    }
}
