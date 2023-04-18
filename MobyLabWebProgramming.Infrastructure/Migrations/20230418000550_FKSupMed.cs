using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class FKSupMed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Medicine_MedicineId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_MedicineId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Supplier");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_SupplierId",
                table: "Medicine",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Supplier_SupplierId",
                table: "Medicine",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Supplier_SupplierId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_SupplierId",
                table: "Medicine");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineId",
                table: "Supplier",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_MedicineId",
                table: "Supplier",
                column: "MedicineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Medicine_MedicineId",
                table: "Supplier",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
