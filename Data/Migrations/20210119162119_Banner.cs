using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banner_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Banner_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 651, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 651, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 651, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 651, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 651, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Page",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 16, 21, 19, 636, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.CreateIndex(
                name: "IX_Banner_ImageId",
                table: "Banner",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_PageId",
                table: "Banner",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banner_PageId_ImageId",
                table: "Banner",
                columns: new[] { "PageId", "ImageId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

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
        }
    }
}
