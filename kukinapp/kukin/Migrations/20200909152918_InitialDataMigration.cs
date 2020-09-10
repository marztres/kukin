using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kukin.Migrations
{
    public partial class InitialDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "kukin");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "kukin",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "kukin",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                schema: "kukin",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "kukin",
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "kukin",
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "kukin",
                table: "Ingredients",
                columns: new[] { "IngredientId", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"), true, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed", "Pollo", new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed" });

            migrationBuilder.InsertData(
                schema: "kukin",
                table: "Recipes",
                columns: new[] { "RecipeId", "Active", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3"), true, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed", "Pollo al curry", new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "modelBuilder.seed" });

            migrationBuilder.InsertData(
                schema: "kukin",
                table: "RecipeIngredient",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[] { new Guid("0375633c-1e53-4309-ba08-e3f8517c1589"), new Guid("d5f36d82-e0ac-49be-aa46-44acc8d1dec3") });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                schema: "kukin",
                table: "RecipeIngredient",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient",
                schema: "kukin");

            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "kukin");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "kukin");
        }
    }
}
