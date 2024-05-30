using TI_Devops_2024_DemoAspMvc.Domain.Entities;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Mappers
{
    public static class UserMappers
    {
        public static User ToEntity(this UserRegisterFormDTO u)
        {
            return new User()
            {
                Username = u.Username,
                Email = u.Email,
                Password = u.Password,
            };
        }

        public static UserSessionDTO ToSessionDTO(this User u)
        {
            return new UserSessionDTO()
            {
                Id = u.Id,
                Username = u.Username,
            };
        }
    }
}
