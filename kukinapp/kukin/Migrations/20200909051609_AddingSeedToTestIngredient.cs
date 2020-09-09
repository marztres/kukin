using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class AddingSeedToTestIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"), true, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed", "Pollo", new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                column: "Active",
                value: true);

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[] { new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"), new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"), new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3") });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                column: "Active",
                value: false);
        }
    }
}
