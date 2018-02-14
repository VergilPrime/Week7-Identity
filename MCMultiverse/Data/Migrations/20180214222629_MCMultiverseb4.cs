using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MCServerId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MCServerId",
                table: "Comments",
                column: "MCServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_MCServers_MCServerId",
                table: "Comments",
                column: "MCServerId",
                principalTable: "MCServers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MCServers_MCServerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MCServerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MCServerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");
        }
    }
}
