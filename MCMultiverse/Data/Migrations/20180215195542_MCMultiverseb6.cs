using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCServers_AspNetUsers_ApplicationUserId",
                table: "MCServers");

            migrationBuilder.DropIndex(
                name: "IX_MCServers_ApplicationUserId",
                table: "MCServers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MCServers");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    MCServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.ApplicationUserId, x.MCServerId });
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_MCServers_MCServerId",
                        column: x => x.MCServerId,
                        principalTable: "MCServers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_MCServerId",
                table: "Favorites",
                column: "MCServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MCServers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MCServers_ApplicationUserId",
                table: "MCServers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MCServers_AspNetUsers_ApplicationUserId",
                table: "MCServers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
