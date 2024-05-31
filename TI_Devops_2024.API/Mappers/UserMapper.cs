using TI_Devops_2024.API.Models;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024.API.Mappers
{
    public static class UserMapper
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
    }
        
}
