using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_CreatorId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Requests",
                newName: "ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_CreatorId",
                table: "Requests",
                newName: "IX_Requests_ExecutorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 37, 50, 643, DateTimeKind.Local).AddTicks(8558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 37, 50, 643, DateTimeKind.Local).AddTicks(8688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ExecutorId",
                table: "Requests",
                column: "ExecutorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ExecutorId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ExecutorId",
                table: "Requests",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ExecutorId",
                table: "Requests",
                newName: "IX_Requests_CreatorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 37, 50, 643, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 20, 37, 14, 485, DateTimeKind.Local).AddTicks(5408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 37, 50, 643, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_CreatorId",
                table: "Requests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
