using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Devops_2024_DemoAspMvc.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? PenName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
