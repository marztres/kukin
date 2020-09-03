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


    }
}
