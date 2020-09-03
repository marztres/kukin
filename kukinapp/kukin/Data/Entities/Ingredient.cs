using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace kukin.Data.Entities
{
    [Table("Ingredients")]
    public class Ingredient : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
