using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class NewTypeNewConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Medicine_MedicineId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineType_Medicine_MedicineId",
                table: "MedicineType");

            migrationBuilder.DropIndex(
                name: "IX_MedicineType_MedicineId",
                table: "MedicineType");

            migrationBuilder.DropIndex(
                name: "IX_MedicineCategory_MedicineId",
                table: "MedicineCategory");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "MedicineType");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "MedicineCategory");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MedicineType",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MedicineType",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MedicineCategory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MedicineCategory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Medicine",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Medicine",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineCategoryId",
                table: "Medicine",
                column: "MedicineCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineTypeId",
                table: "Medicine",
                column: "MedicineTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_MedicineCategory_MedicineCategoryId",
                table: "Medicine",
                column: "MedicineCategoryId",
                principalTable: "MedicineCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_MedicineType_MedicineTypeId",
                table: "Medicine",
                column: "MedicineTypeId",
                principalTable: "MedicineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_MedicineCategory_MedicineCategoryId",
                table: "Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_MedicineType_MedicineTypeId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_MedicineCategoryId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_MedicineTypeId",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MedicineType");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MedicineType");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MedicineCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MedicineCategory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Medicine");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineId",
                table: "MedicineType",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineId",
                table: "MedicineCategory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MedicineType_MedicineId",
                table: "MedicineType",
                column: "MedicineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategory_MedicineId",
                table: "MedicineCategory",
                column: "MedicineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Medicine_MedicineId",
                table: "MedicineCategory",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineType_Medicine_MedicineId",
                table: "MedicineType",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
