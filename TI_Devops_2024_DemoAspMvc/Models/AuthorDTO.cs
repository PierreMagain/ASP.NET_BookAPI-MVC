using System.ComponentModel;

namespace TI_Devops_2024_DemoAspMvc.Models
{
    public class AuthorDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nom complet")]
        public string Fullname { get; set; } = null!;

        [DisplayName("Nom de plume")]
        public string? PenName { get; set; }
    }
}
