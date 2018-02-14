using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MCServer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastPinged = table.Column<DateTime>(nullable: false),
                    LastPingedOnline = table.Column<DateTime>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCServer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCServer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MCServer_ApplicationUserId",
                table: "MCServer",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MCServer");
        }
    }
}
