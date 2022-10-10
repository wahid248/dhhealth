using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateNewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MediumImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SmallImageId",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "LargeImageUrl",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediumImagUrl",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallImageUrl",
                table: "News",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeImageUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MediumImagUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SmallImageUrl",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "LargeImageId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediumImageId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmallImageId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 44, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 44, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 44, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 44, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 44, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 2, 6, 8, 3, 19, 0, DateTimeKind.Utc).AddTicks(2076));
        }
    }
}
