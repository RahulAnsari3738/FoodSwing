using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    public partial class ForeignKeyinItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestautantId",
                table: "MenuItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestautantId",
                table: "MenuItems",
                column: "RestautantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestautantId",
                table: "MenuItems",
                column: "RestautantId",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestautantId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_RestautantId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "RestautantId",
                table: "MenuItems");
        }
    }
}
