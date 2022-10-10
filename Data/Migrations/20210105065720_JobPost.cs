using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class JobPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Postion = table.Column<string>(nullable: true),
                    JobCode = table.Column<int>(nullable: false),
                    EmploymentType = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    JobSpecification = table.Column<string>(nullable: true),
                    ApplyProcess = table.Column<string>(nullable: true),
                    JobLocation = table.Column<string>(nullable: true),
                    DeadLine = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPost", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 811, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 811, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 811, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 811, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 811, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 5, 6, 57, 19, 794, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_JobCode",
                table: "JobPost",
                column: "JobCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPost");

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 838, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2020, 12, 31, 8, 15, 5, 820, DateTimeKind.Utc).AddTicks(6551));
        }
    }
}
