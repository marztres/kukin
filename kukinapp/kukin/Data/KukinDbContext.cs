using kukin.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace kukin.Data
{
    public class KukinDbContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public KukinDbContext(DbContextOptions<KukinDbContext> options) : base(options) {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("kukin");

            //Compound key entity RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(t => new { t.IngredientId, t.RecipeId });

            //Relation RecipeIngredient with Recipe Entity
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(pt => pt.Recipe)
                .WithMany(p => p.RecipeIngredient)
                .HasForeignKey(pt => pt.RecipeId);

            //Relation RecipeIngredient with Ingredient Entity
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.IngredientRecipe)
                .HasForeignKey(pt => pt.IngredientId);

            modelBuilder.SeedData();
        }
    }
}
