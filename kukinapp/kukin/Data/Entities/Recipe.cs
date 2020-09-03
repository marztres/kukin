using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace kukin.Data.Entities
{
    [Table("Recipes")]
    public class Recipe: BaseEntity
    {        
        public Guid RecipeId { get; set; }
        public string Name { get; }
        public bool Active { get; }
        public List<Recipe> RecipeIngredients { get; set; }
    }
}
