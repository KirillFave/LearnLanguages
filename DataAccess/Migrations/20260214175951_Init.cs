using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WheelLists",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelLists", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WheelItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    ListGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    IsInactive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelItems", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WheelItems_WheelLists_ListGuid",
                        column: x => x.ListGuid,
                        principalTable: "WheelLists",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WheelItems_ListGuid",
                table: "WheelItems",
                column: "ListGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WheelItems");

            migrationBuilder.DropTable(
                name: "WheelLists");
        }
    }
}
