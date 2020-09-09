using kukin.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Data
{
    public static class ModelBuilderDataSeeder
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder) {

            modelBuilder.Entity<Recipe>()
                .HasData(
                    new { 
                        RecipeId = Guid.Parse("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"), 
                        Name = "Pollo al curry", 
                        Active = true, 
                        CreatedAt = new DateTime(2020,9,8,0,0,0,0),
                        UpdatedAt = new DateTime(2020, 9, 8, 0, 0, 0, 0),
                        CreatedBy = "modelBuilder.seed", 
                        UpdatedBy = "modelBuilder.seed" 
                    }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new
                    {
                        IngredientId = Guid.Parse("0375633c-1e53-4309-ba08-e3f8517c1589"),
                        Name = "Pollo",
                        Active = true,
                        CreatedAt = new DateTime(2020, 9, 8, 0, 0, 0, 0),
                        UpdatedAt = new DateTime(2020, 9, 8, 0, 0, 0, 0),
                        CreatedBy = "modelBuilder.seed",
                        UpdatedBy = "modelBuilder.seed"
                    }
                );

            modelBuilder.Entity<RecipeIngredient>()
                .HasData(
                    new
                    {
                        RecipeId = Guid.Parse("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                        IngredientId = Guid.Parse("0375633c-1e53-4309-ba08-e3f8517c1589")                        
                    }
                );

            return modelBuilder;
        }
    }
}
