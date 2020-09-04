using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class SeedDataRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"), new DateTime(2020, 9, 4, 0, 58, 14, 298, DateTimeKind.Local).AddTicks(2667), "modelBuilder.seed", new DateTime(2020, 9, 4, 0, 58, 14, 301, DateTimeKind.Local).AddTicks(7199), "modelBuilder.seed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"));
        }
    }
}
