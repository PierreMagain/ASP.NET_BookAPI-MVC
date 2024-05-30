using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Devops_2024_DemoAspMvc.Domain.Entities
{
    public class Book
    {
        public string ISBN { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
