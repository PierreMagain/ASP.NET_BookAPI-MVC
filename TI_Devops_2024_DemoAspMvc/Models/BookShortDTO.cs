using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.Models
{
    public class BookShortDTO
    {
        public string ISBN { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime PublishDate { get; set; }
    }
}
