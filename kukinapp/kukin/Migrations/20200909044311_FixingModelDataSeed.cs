using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class FixingModelDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 9, 7, 1, 4, 7, 888, DateTimeKind.Local).AddTicks(4028), new DateTime(2020, 9, 7, 1, 4, 7, 888, DateTimeKind.Local).AddTicks(4052) });
        }
    }
}
