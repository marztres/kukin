using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kukin.Services.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace kukin.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private IWebHostEnvironment _enviroment { get; }
        private IConfiguration _configuration { get; }
        private IRecipeService _recipeService { get; }

        public RecipesController(IWebHostEnvironment env, IConfiguration configuration, IRecipeService recipeService)
        {
            _enviroment = env ?? throw new ArgumentNullException(nameof(env));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _recipeService = recipeService;
        }

        /// <summary>
        /// Gets all recipes
        /// </summary>
        /// <returns> Recipes </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _recipeService.GetAsync());
        }       
    }
}
