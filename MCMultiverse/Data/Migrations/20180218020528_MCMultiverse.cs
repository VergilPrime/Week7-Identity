using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerLarge",
                table: "MCServers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerSmall",
                table: "MCServers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinecraftUUID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinecraftUserName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalDonations",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerLarge",
                table: "MCServers");

            migrationBuilder.DropColumn(
                name: "BannerSmall",
                table: "MCServers");

            migrationBuilder.DropColumn(
                name: "MinecraftUUID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MinecraftUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalDonations",
                table: "AspNetUsers");
        }
    }
}
