﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_Devops_2024_DemoAspMvc.Domain.Entities;

namespace TI_Devops_2024_DemoAspMvc.DAL.Interfaces
{
    public interface IPokemonRepository
    {
        Task<PokemonResult> GetPokemons(string url);
        Task<string?> GetImageUrl(string url);
    }
}
