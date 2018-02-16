﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "MCServers",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "MCServers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MCServers_OwnerId",
                table: "MCServers",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MCServers_AspNetUsers_OwnerId",
                table: "MCServers",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCServers_AspNetUsers_OwnerId",
                table: "MCServers");

            migrationBuilder.DropIndex(
                name: "IX_MCServers_OwnerId",
                table: "MCServers");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "MCServers",
                newName: "Owner");

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "MCServers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
