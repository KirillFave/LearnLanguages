using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Scheme_SchemeItem_Entities_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "SchemeItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Column = table.Column<int>(type: "INTEGER", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemeGuid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeItems", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_SchemeItems_Schemes_SchemeGuid",
                        column: x => x.SchemeGuid,
                        principalTable: "Schemes",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchemeItems_SchemeGuid",
                table: "SchemeItems",
                column: "SchemeGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchemeItems");

            migrationBuilder.DropTable(
                name: "Schemes");
        }
    }
}
