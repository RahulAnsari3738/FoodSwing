using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    public partial class res : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestautantIID",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RestautantId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_RestautantIID",
                table: "Carts",
                column: "RestautantIID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Restaurants_RestautantIID",
                table: "Carts",
                column: "RestautantIID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Restaurants_RestautantIID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_RestautantIID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RestautantIID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RestautantId",
                table: "Carts");
        }
    }
}
