using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class FixedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_OrderItem_OrderItemId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_OrderItemId",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Medicine");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineId",
                table: "OrderItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MedicineId",
                table: "OrderItem",
                column: "MedicineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Medicine_MedicineId",
                table: "OrderItem",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Medicine_MedicineId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_MedicineId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "OrderItem");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId",
                table: "Medicine",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_OrderItemId",
                table: "Medicine",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_OrderItem_OrderItemId",
                table: "Medicine",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
