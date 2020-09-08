using kukin.Data;
using kukin.Data.Entities;
using kukin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public readonly KukinDbContext _kukinDbContext;
        public RecipeRepository(KukinDbContext kukinDbContext) =>
            _kukinDbContext = kukinDbContext ?? throw new ArgumentNullException(nameof(KukinDbContext));

        /// <inheritdoc />
        public Task<List<Recipe>> GetAsync() {
            return _kukinDbContext.Recipes.ToListAsync();
        }
    }
}
