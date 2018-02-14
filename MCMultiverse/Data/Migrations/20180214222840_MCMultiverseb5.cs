using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCMultiverse.Data.Migrations
{
    public partial class MCMultiverseb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MCServers_MCServerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Comments",
                newName: "ServerParentId");

            migrationBuilder.RenameColumn(
                name: "MCServerId",
                table: "Comments",
                newName: "CommentParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                newName: "IX_Comments_ServerParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MCServerId",
                table: "Comments",
                newName: "IX_Comments_CommentParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentParentId",
                table: "Comments",
                column: "CommentParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_MCServers_ServerParentId",
                table: "Comments",
                column: "ServerParentId",
                principalTable: "MCServers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentParentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MCServers_ServerParentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ServerParentId",
                table: "Comments",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "CommentParentId",
                table: "Comments",
                newName: "MCServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ServerParentId",
                table: "Comments",
                newName: "IX_Comments_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentParentId",
                table: "Comments",
                newName: "IX_Comments_MCServerId");

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
    }
}
