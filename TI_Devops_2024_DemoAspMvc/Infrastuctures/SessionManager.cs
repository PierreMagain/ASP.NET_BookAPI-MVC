using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TI_Devops_2024_DemoAspMvc.Models;

namespace TI_Devops_2024_DemoAspMvc.Infrastuctures
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext!.Session;
        }

        public UserSessionDTO? CurrentUser
        {
            get
            {
                string? json = _session.GetString("currentUser");
                if (json == null)
                {
                    return null;
                }
                return JsonSerializer.Deserialize<UserSessionDTO>(json);
            }
            set
            {
                _session.SetString("currentUser", JsonSerializer.Serialize(value));
            }
        }

        public void Logout()
        {
            _session.Remove("currentUser");
        }
    }
}
