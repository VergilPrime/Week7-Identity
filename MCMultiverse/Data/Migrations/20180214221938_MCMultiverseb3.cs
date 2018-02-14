using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCServer_AspNetUsers_ApplicationUserId",
                table: "MCServer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MCServer",
                table: "MCServer");

            migrationBuilder.RenameTable(
                name: "MCServer",
                newName: "MCServers");

            migrationBuilder.RenameIndex(
                name: "IX_MCServer_ApplicationUserId",
                table: "MCServers",
                newName: "IX_MCServers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MCServers",
                table: "MCServers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OnId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Timestamp = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MCServers_AspNetUsers_ApplicationUserId",
                table: "MCServers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCServers_AspNetUsers_ApplicationUserId",
                table: "MCServers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MCServers",
                table: "MCServers");

            migrationBuilder.RenameTable(
                name: "MCServers",
                newName: "MCServer");

            migrationBuilder.RenameIndex(
                name: "IX_MCServers_ApplicationUserId",
                table: "MCServer",
                newName: "IX_MCServer_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MCServer",
                table: "MCServer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MCServer_AspNetUsers_ApplicationUserId",
                table: "MCServer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
