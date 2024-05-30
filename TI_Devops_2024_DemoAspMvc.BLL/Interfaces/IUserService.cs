using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.BLL.Interfaces
{
    public interface IUserService
    {
        int Register(User u);
        User Login(string login, string password);
    }
}
