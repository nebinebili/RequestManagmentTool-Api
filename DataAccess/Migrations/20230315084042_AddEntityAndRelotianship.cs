using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddEntityAndRelotianship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Queries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 15, 8, 40, 42, 21, DateTimeKind.Utc).AddTicks(3177),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 15, 8, 35, 19, 999, DateTimeKind.Utc).AddTicks(2058));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Queries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 15, 8, 35, 19, 999, DateTimeKind.Utc).AddTicks(2058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 15, 8, 40, 42, 21, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
