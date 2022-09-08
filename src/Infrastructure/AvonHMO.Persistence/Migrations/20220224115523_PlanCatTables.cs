using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class PlanCatTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a25ecd60-5e30-42d8-9aa9-f849b822a4bc"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ae75d0e4-44eb-4acb-a552-a5a3a451ce78"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d7dd38cf-ab07-4942-a817-b251c55306d3"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f3d88a04-6719-49a4-aace-492cda5f0092"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3db0eba9-9441-448f-a8ef-ef89f16ea913"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8c7d3edb-c1ab-47ce-a152-f8c6c0981dad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9db5fb6a-f437-4d3d-a062-547df4139b18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("72beb0b1-0ee7-48c0-b23f-d49d553f6558"));

            migrationBuilder.CreateTable(
                name: "PlanCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3c0dae74-a25c-4c6c-830b-666c7f35ca0f"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3248), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3248), false, "Client", "Admin" },
                    { new Guid("45f9d95c-d2dc-4671-9523-739b2c13c29d"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3245), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3246), false, "Enrollee", "Admin" },
                    { new Guid("66675121-6c96-4fb0-83f6-5088c7b6708b"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3249), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3250), false, "Provider", "Admin" },
                    { new Guid("fb02b4e3-b350-4d9f-862a-367fdecf382a"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3243), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3243), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("212f1995-264d-48e1-995e-4bebf30d0f71"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("70930e7e-ced8-4d98-9983-fa6535438dcf"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f35b79d5-8e6e-44f6-bb1a-1671b55b7c84"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("28847881-71a6-4ded-bccd-d15f289a24e2"), null, new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3061), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3075), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanCategories");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3c0dae74-a25c-4c6c-830b-666c7f35ca0f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("45f9d95c-d2dc-4671-9523-739b2c13c29d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("66675121-6c96-4fb0-83f6-5088c7b6708b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fb02b4e3-b350-4d9f-862a-367fdecf382a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("212f1995-264d-48e1-995e-4bebf30d0f71"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("70930e7e-ced8-4d98-9983-fa6535438dcf"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f35b79d5-8e6e-44f6-bb1a-1671b55b7c84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("28847881-71a6-4ded-bccd-d15f289a24e2"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("a25ecd60-5e30-42d8-9aa9-f849b822a4bc"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9555), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9555), false, "Client", "Admin" },
                    { new Guid("ae75d0e4-44eb-4acb-a552-a5a3a451ce78"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9553), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9553), false, "Enrollee", "Admin" },
                    { new Guid("d7dd38cf-ab07-4942-a817-b251c55306d3"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9550), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9550), false, "Admin", "Admin" },
                    { new Guid("f3d88a04-6719-49a4-aace-492cda5f0092"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9557), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9558), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("3db0eba9-9441-448f-a8ef-ef89f16ea913"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8c7d3edb-c1ab-47ce-a152-f8c6c0981dad"), "SENDGRID_KEY", "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" },
                    { new Guid("9db5fb6a-f437-4d3d-a062-547df4139b18"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("72beb0b1-0ee7-48c0-b23f-d49d553f6558"), null, new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9377), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9393), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
