using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class ModifyRecipeFields_fixingNameAndActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Recipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                column: "Name",
                value: "Pollo al curry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipes");
        }
    }
}
