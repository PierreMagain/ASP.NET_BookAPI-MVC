using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Devops_2024_DemoAspMvc.Domain.Entities
{
    public class PokemonSimple
    {
        public string name { get; set; } = null!;
        public string url { get; set; } = null!;
        public string? image { get; set; } = null!;
    }

    public class PokemonResult
    {
        public int count { get; set; }
        public string next { get; set; } = null!;
        public string previous { get; set; } = null!;
        public List<PokemonSimple> results { get; set; } = new List<PokemonSimple>();
    }
    
}
