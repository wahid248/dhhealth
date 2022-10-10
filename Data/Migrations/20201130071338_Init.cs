using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsSubscribed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TemplateType = table.Column<int>(nullable: false),
                    TemplateName = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ControllerName = table.Column<string>(maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    BottomText = table.Column<string>(maxLength: 300, nullable: true),
                    Album = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    SectionOrder = table.Column<byte>(nullable: false),
                    TitleSmall = table.Column<string>(maxLength: 200, nullable: true),
                    TitleLarge = table.Column<string>(maxLength: 500, nullable: true),
                    TitleLargeOnTop = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CustomCss = table.Column<string>(nullable: true),
                    SectionTypeId = table.Column<int>(nullable: true),
                    ParentSectionId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Section_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Section_ParentSectionId",
                        column: x => x.ParentSectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageSections",
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
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSections_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageSections_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Body", "CreatedBy", "CreatedOn", "IsDeleted", "ModifiedBy", "ModifiedOn", "TemplateName", "TemplateType" },
                values: new object[,]
                {
                    { 1, "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your query has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>.</div></div></body></html>", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 714, DateTimeKind.Utc).AddTicks(6798), false, null, null, "User Confirmation", 1 },
                    { 2, "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"UserName\"></b> <p id=\"Contact\"></p> <p id=\"Email\"></p><p id=\"message\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>.</div></div></body></html>", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 714, DateTimeKind.Utc).AddTicks(6798), false, null, null, "User Query", 2 },
                    { 3, "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"userName\"></b> <p>This is to inform you that your response has been received. Our team will contact you soon.</p><br><p>Thank you!.</p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>.</div></div></body></html>", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 714, DateTimeKind.Utc).AddTicks(6798), false, null, null, "Job Apply Confirmation", 3 },
                    { 4, "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b id=\"applicantName\"></b> <p id=\"applicantContact\"></p><p id=\"applicantEmail\"></p></div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>.</div></div></body></html>", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 714, DateTimeKind.Utc).AddTicks(6798), false, null, null, "Applicant CV", 4 },
                    { 5, "<html><head><link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'><style>body{font-family: 'Roboto';font-size: 1rem;background-color: #fff;}.content{Margin: 0 auto; max-width: 580px; padding: 10px;}.wrapper{width: 100%; background: #ddd; border-radius: 3px;padding: 30px;}.wrapper img{height:150px; width:100px; display: block;margin-left: auto;margin-right: auto;width: 50%;}.footer{Margin-top: 10px; text-align: center; width: 100%;color: #999999;font-size:0.8rem;}.visit-dh-health{color: #2F8F9C;text-decoration: none;}</style></head><body> <div class=\"content\"> <div class=\"wrapper\"><b>Dear User, </b> <p>Thank you for your Subscribe.</p><p id=\"userEmail\"></p><p>Dh Health Team</p><p>Visit our Website <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>. </div><div class=\"footer\"> <p>Proshanti 3rd & 4th Floor, House: 257 <br>Road: 1, Block: B, Bashundhara R/A,Dhaka 1229.</p><p>Powered by <a class=\"visit-dh-health\" href=\"http://3.0.18.132/ \">Dh.Health<a></p>.</div></div></body></html>", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 714, DateTimeKind.Utc).AddTicks(6798), false, null, null, "News Subscription", 5 }
                });

            migrationBuilder.InsertData(
                table: "Page",
                columns: new[] { "Id", "ActionName", "ControllerName", "CreatedBy", "CreatedOn", "IsDeleted", "IsEnabled", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, "Home", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Home" },
                    { 2, null, "WhoWeAre", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Who We Are" },
                    { 3, null, "OurServices", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Our Services" },
                    { 4, null, "SustainableImpacts", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Sustainable Impacts" },
                    { 5, null, "PartnerWithUs", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Partner With Us" },
                    { 6, null, "OurBrands", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Our Brands" },
                    { 7, null, "Career", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Career" },
                    { 8, null, "News", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "News" },
                    { 9, null, "ContactUs", "SYSTEM", new DateTime(2020, 11, 30, 7, 13, 37, 696, DateTimeKind.Utc).AddTicks(8935), false, true, null, null, "Contact Us" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_CustomerId",
                table: "ContactUs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedBy",
                table: "Image",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_SectionId",
                table: "PageSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_PageId_SectionId",
                table: "PageSections",
                columns: new[] { "PageId", "SectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_CreatedBy",
                table: "Section",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ImageId",
                table: "Section",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ParentSectionId",
                table: "Section",
                column: "ParentSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
