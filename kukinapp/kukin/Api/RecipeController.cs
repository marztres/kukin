using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class RecipeController : ControllerBase
    {
        private IWebHostEnvironment _enviroment { get; }
        private IConfiguration _configuration { get; }

        public RecipeController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _enviroment = env ?? throw new ArgumentNullException(nameof(env));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Gets all recipes
        /// </summary>
        /// <returns> Recipes </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Task.FromResult(_enviroment));
        }

        /// <summary>
        /// Gets Recipes configuration
        /// </summary>
        /// <returns> All recipes configurations </returns>
        [HttpGet("config")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Config()
        {
            List<string> kukinConfig = new List<string>();
            kukinConfig.Add(_configuration["KukinConfig:version"]);
            kukinConfig.Add(_configuration["KukinConfig:enableLog"]);
            kukinConfig.Add(_configuration["KukinConfig:kukinSecure"]);

            return Ok(await Task.FromResult(kukinConfig));
        }
    }
}
