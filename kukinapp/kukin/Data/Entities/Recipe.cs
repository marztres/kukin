using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace kukin.Data.Entities
{
    [Table("Recipes")]
    public class Recipe : BaseEntity
    {        
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<RecipeIngredient> RecipeIngredient { get; set; }

        [NotMapped]
        public List<Ingredient> Ingredients { get {
                return RecipeIngredient != null ? RecipeIngredient.Select(selector => selector.Ingredient).ToList() : new List<Ingredient>();
            } 
        }
    }
}
