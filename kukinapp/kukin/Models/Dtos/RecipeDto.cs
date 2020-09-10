using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Models.Dtos
{
    public class RecipeDto
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public List<IngredientDto> Ingredients { get; set; }
    }
}
