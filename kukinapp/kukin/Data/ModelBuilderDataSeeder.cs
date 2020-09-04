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
                        Active = false, 
                        CreatedAt = DateTime.Now, 
                        UpdatedAt = DateTime.Now , 
                        CreatedBy = "modelBuilder.seed", 
                        UpdatedBy = "modelBuilder.seed" 
                    }
                );

            return modelBuilder;
        }
    }
}
