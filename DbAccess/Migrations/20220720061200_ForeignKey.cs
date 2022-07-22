using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_Orderid",
                table: "OrderStatuses",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestautantId",
                table: "Orders",
                column: "RestautantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Orderid",
                table: "OrderDetails",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_Orderid",
                table: "OrderDetails",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders",
                column: "RestautantId",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_Orders_Orderid",
                table: "OrderStatuses",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_Orderid",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestautantId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_Orders_Orderid",
                table: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatuses_Orderid",
                table: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestautantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_Orderid",
                table: "OrderDetails");
        }
    }
}
