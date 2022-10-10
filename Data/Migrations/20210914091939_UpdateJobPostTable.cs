using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateJobPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobPost",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 684, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 684, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 684, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 684, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 684, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 9, 14, 9, 19, 38, 633, DateTimeKind.Utc).AddTicks(8541));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobPost");

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 39, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 39, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 39, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 39, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 39, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 14, 5, 18, 18, DateTimeKind.Utc).AddTicks(8693));
        }
    }
}
