using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Migrations
{
    public partial class MCMultiverse03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "Votes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinecraftUserName",
                table: "Votes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "MinecraftUserName",
                table: "Votes");
        }
    }
}
