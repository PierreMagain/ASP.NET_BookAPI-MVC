using Microsoft.AspNetCore.Mvc;
using TI_Devops_2024_DemoAspMvc.BLL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.Controllers
{
    public class PokemonController : Controller
    {

        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index(string url)
        {
            PokemonResult result = await _pokemonService.GetPokemons(url);
            return View(result);
        }
    }
}
