using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RFileId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 19, 11, 41, 16, 552, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 19, 11, 41, 16, 552, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 6, 19, 11, 41, 16, 552, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 19, 11, 41, 16, 552, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 6, 19, 11, 41, 16, 552, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RFileId",
                table: "Requests",
                column: "RFileId",
                unique: true,
                filter: "[RFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Files_RFileId",
                table: "Requests",
                column: "RFileId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Files_RFileId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RFileId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RFileId",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5286));
        }
    }
}
