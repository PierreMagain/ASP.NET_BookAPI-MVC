using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TI_Devops_2024_DemoAspMvc.Models
{
    public class UserLoginFormDTO
    {
        [DisplayName("Identifiant")]
        [Required]
        public string Login { get; set; } = null!;

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
