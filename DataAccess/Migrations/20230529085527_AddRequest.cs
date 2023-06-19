using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CategoryId", "Date", "ExecutorId", "PriorityId", "RequestTypeId", "SenderId", "StatusId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, (short)3, new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5274), null, (short)1, (short)5, 1, (short)2, "email test edilme isi", "#email Test" },
                    { 2, (short)2, new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5283), 1, (short)3, (short)2, 3, (short)1, "odenislerin silinmesi emeliyyati", "Odenislerin silinmesi" },
                    { 3, (short)4, new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5284), 2, (short)2, (short)5, 3, (short)1, "odenislerin arasdirilimasi emeliyyati", "Odenislerin arasdirilimasi" },
                    { 4, (short)5, new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5285), null, (short)2, (short)7, 2, (short)3, "email egov emeliyyati", "email egov" },
                    { 5, (short)4, new DateTime(2023, 5, 29, 12, 55, 27, 40, DateTimeKind.Local).AddTicks(5286), 3, (short)2, (short)3, 1, (short)3, "muqavile emeliyyati", "muqavile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
