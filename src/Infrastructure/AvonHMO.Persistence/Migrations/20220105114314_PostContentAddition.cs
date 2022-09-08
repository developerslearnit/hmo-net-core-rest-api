using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class PostContentAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1d119bae-c9aa-4f14-a1ce-6f2096f0e962"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("23c21f69-e97f-44ad-aecf-95b70d3859a8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5fbee343-5d95-48d9-95d5-65c8962f5ff8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6620dcc6-adf3-46f4-bdd2-28a42a4d355b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7dffe0b4-c218-4d1b-9350-532508010b75"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("879e1a72-cebe-431f-9f3d-9afb1e723d64"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("cba775fa-b9d1-48b2-8c7d-da810cf8e0f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("25acb3e9-e0e4-4d5f-8cb0-d3c8ff8c69e3"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CommentParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PostType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excerpt = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeaturedImage = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("d1ef503a-b440-4e6b-a406-5ed43f6c9665"), "Admin", new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8135), new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8136), false, "Admin", "Admin" },
                    { new Guid("d589e1f9-7a0a-485f-af2d-68ae8dcd0ea3"), "Admin", new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8151), new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8151), false, "Client", "Admin" },
                    { new Guid("d95aebd0-330f-47e0-8e06-f89be1b79df7"), "Admin", new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8153), new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8153), false, "Provider", "Admin" },
                    { new Guid("f49339e7-f0f7-4b3e-b50a-28c657fc9de9"), "Admin", new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8148), new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(8149), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1df9b7c7-e0b0-411d-bf3b-eac61ac78630"), "SENDGRID_KEY", "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" },
                    { new Guid("44ce49af-6b55-4163-ac6b-5fee14843fb3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8c018dd7-2eb4-4d3b-8799-8fd79574bf5a"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("11ef5aa5-308b-4e44-b95f-1f11bfc7abaa"), null, new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(7978), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 5, 12, 43, 14, 29, DateTimeKind.Local).AddTicks(7990), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d1ef503a-b440-4e6b-a406-5ed43f6c9665"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d589e1f9-7a0a-485f-af2d-68ae8dcd0ea3"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d95aebd0-330f-47e0-8e06-f89be1b79df7"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f49339e7-f0f7-4b3e-b50a-28c657fc9de9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1df9b7c7-e0b0-411d-bf3b-eac61ac78630"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("44ce49af-6b55-4163-ac6b-5fee14843fb3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8c018dd7-2eb4-4d3b-8799-8fd79574bf5a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("11ef5aa5-308b-4e44-b95f-1f11bfc7abaa"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1d119bae-c9aa-4f14-a1ce-6f2096f0e962"), "Admin", new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6149), new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6151), false, "Enrollee", "Admin" },
                    { new Guid("23c21f69-e97f-44ad-aecf-95b70d3859a8"), "Admin", new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6135), new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6137), false, "Admin", "Admin" },
                    { new Guid("5fbee343-5d95-48d9-95d5-65c8962f5ff8"), "Admin", new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6171), new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6267), false, "Provider", "Admin" },
                    { new Guid("6620dcc6-adf3-46f4-bdd2-28a42a4d355b"), "Admin", new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6160), new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(6162), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("7dffe0b4-c218-4d1b-9350-532508010b75"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("879e1a72-cebe-431f-9f3d-9afb1e723d64"), "SENDGRID_KEY", "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" },
                    { new Guid("cba775fa-b9d1-48b2-8c7d-da810cf8e0f3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("25acb3e9-e0e4-4d5f-8cb0-d3c8ff8c69e3"), null, new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(5532), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2021, 12, 25, 7, 25, 57, 780, DateTimeKind.Local).AddTicks(5567), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
