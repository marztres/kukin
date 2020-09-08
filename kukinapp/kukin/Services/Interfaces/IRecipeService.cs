using kukin.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Services.Interfaces
{
    public interface IRecipeService
    {
        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns> List of recipes </returns>
        Task<List<RecipeDto>> GetAsync();
    }
}
