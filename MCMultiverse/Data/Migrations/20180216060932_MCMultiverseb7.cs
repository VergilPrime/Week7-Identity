using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Favorites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ApplicationUserId1",
                table: "Favorites",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_ApplicationUserId1",
                table: "Favorites",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_ApplicationUserId1",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_ApplicationUserId1",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Favorites");
        }
    }
}
