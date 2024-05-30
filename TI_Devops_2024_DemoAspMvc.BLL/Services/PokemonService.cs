using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.DAL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.BLL.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<PokemonResult> GetPokemons(string url)
        {
            PokemonResult result = await _pokemonRepository.GetPokemons(url);
            foreach (PokemonSimple p in result.results)
            {
                p.image = await _pokemonRepository.GetImageUrl(p.url);
            }
            return result;
        }
    }
}
