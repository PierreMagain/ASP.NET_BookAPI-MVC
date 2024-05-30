using TI_Devops_2024.API.Models;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024.API.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDTO toDTO(this Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                Fullname = author.Lastname + " " + author.Firstname,
                PenName = author.PenName
            };
        }
    }
}
