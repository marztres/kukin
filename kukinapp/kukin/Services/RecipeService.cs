using AutoMapper;
using kukin.Data.Entities;
using kukin.Models.Dtos;
using kukin.Repositories.Interfaces;
using kukin.Services.Exceptions;
using kukin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Services
{
    public class RecipeService : IRecipeService
    {
        private const string RECIPE_NOT_FOUND = "Recipe not found.";
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper) {
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <inheritdoc />
        public async Task<List<RecipeDto>> GetAsync()
        {
            var recipes = await _recipeRepository.GetAsync();
            var recipesDto = _mapper.Map<List<RecipeDto>>(recipes);

            return recipesDto;
        }
    }
}
