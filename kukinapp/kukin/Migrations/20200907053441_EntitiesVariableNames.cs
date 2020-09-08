using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class EntitiesVariableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 9, 7, 0, 34, 40, 794, DateTimeKind.Local).AddTicks(7953), new DateTime(2020, 9, 7, 0, 34, 40, 794, DateTimeKind.Local).AddTicks(7977) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 9, 4, 0, 58, 14, 298, DateTimeKind.Local).AddTicks(2667), new DateTime(2020, 9, 4, 0, 58, 14, 301, DateTimeKind.Local).AddTicks(7199) });
        }
    }
}
