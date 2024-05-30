using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Mappers
{
    public static class AuthorMappers
    {
        public static AuthorDTO toDTO(this Author a)
        {
            return new AuthorDTO()
            {
                Id = a.Id,
                Fullname = $"{a.Firstname} {a.Lastname}",
                PenName = a.PenName
            };
        }
    }
}
