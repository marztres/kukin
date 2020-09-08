using kukin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Repositories.Interfaces
{
    public interface IRecipeRepository
    {        
        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns>List of recipes</returns>
        Task<List<Recipe>> GetAsync();        
    }
}
