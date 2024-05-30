using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.DAL.Interfaces;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.DAL.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly HttpClient _httpClient;

        public PokemonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetImageUrl(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(json);

            return document.RootElement.GetProperty("sprites")
                                       .GetProperty("other")
                                       .GetProperty("dream_world")
                                       .GetProperty("front_default")
                                       .ToString();
        }

        public async Task<PokemonResult> GetPokemons(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            PokemonResult result = JsonSerializer.Deserialize<PokemonResult>(json)!;

            return result;
        }
    }
}
