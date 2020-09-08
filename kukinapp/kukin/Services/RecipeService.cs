using AutoMapper;
using kukin.Models.Dtos;
using kukin.Repositories.Interfaces;
using kukin.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kukin.Services
{
    public class RecipeService : IRecipeService
    {
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
