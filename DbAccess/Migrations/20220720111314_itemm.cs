using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    public partial class itemm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuItems_ItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestautantId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuItems_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "MenuItems",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders",
                column: "RestautantId",
                principalTable: "Restaurants",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuItems_ItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestautantId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "ID"
             );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuItems_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "MenuItems",
                principalColumn: "ID"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders",
                column: "RestautantId",
                principalTable: "Restaurants",
                principalColumn: "ID"
               );
        }
    }
}
