using AutoMapper;
using kukin.Data.Entities;
using kukin.Models.Dtos;

namespace kukin.Mapping
{
    public class EntityMappers : Profile
    {
        public EntityMappers() {
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
        }
    }
}
