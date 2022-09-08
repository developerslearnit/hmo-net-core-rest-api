using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Referral_requests_entities_two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("76efc9bb-9c32-4807-be2a-be6b90e7530c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9a5ed4cd-0a1d-4d63-8db0-3eb860494e7b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("b33bae85-f688-4954-b258-2b726bf9505b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fde7faa2-c39b-4335-8951-d87427e4fddc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("203c0873-1dde-493f-b580-d251a9ef4ca3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("686c8b9a-1bf2-47c7-8a7b-d4fa5f604939"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9b297d6a-0e70-4369-afcc-779ed6476ecd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("4764ce57-72bd-469f-94f4-5001c42b1917"));

            migrationBuilder.AddColumn<Guid>(
                name: "EnrolleeAccountId",
                table: "Enrollee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("198464ed-14b4-48ba-baff-f7cd6a4a0289"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1323), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1324), false, "Admin", "Admin" },
                    { new Guid("67885dab-c0fc-444d-b8f6-31e74d559adb"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1335), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1336), false, "Provider", "Admin" },
                    { new Guid("692177db-a075-4d63-9654-4195168bde10"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1328), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1329), false, "Enrollee", "Admin" },
                    { new Guid("a5007cd4-9c03-4f95-8023-c7436a79df7f"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1332), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1332), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1a1aa2ce-39ea-4f99-9f54-ff09e303172f"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("4800fae2-3cfe-4719-995d-8fa06f8bb58a"), "SENDGRID_KEY", "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" },
                    { new Guid("ac574f7c-6bab-44df-83b3-41bd01794c7f"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("0d64b762-6588-4887-bdc5-4169b6b5783e"), null, new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1080), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1094), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("198464ed-14b4-48ba-baff-f7cd6a4a0289"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("67885dab-c0fc-444d-b8f6-31e74d559adb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("692177db-a075-4d63-9654-4195168bde10"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a5007cd4-9c03-4f95-8023-c7436a79df7f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1a1aa2ce-39ea-4f99-9f54-ff09e303172f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4800fae2-3cfe-4719-995d-8fa06f8bb58a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac574f7c-6bab-44df-83b3-41bd01794c7f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("0d64b762-6588-4887-bdc5-4169b6b5783e"));

            migrationBuilder.DropColumn(
                name: "EnrolleeAccountId",
                table: "Enrollee");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("76efc9bb-9c32-4807-be2a-be6b90e7530c"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1462), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1462), false, "Enrollee", "Admin" },
                    { new Guid("9a5ed4cd-0a1d-4d63-8db0-3eb860494e7b"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1458), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1459), false, "Admin", "Admin" },
                    { new Guid("b33bae85-f688-4954-b258-2b726bf9505b"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1466), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1467), false, "Provider", "Admin" },
                    { new Guid("fde7faa2-c39b-4335-8951-d87427e4fddc"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1464), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1465), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("203c0873-1dde-493f-b580-d251a9ef4ca3"), "SENDGRID_KEY", "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" },
                    { new Guid("686c8b9a-1bf2-47c7-8a7b-d4fa5f604939"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("9b297d6a-0e70-4369-afcc-779ed6476ecd"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("4764ce57-72bd-469f-94f4-5001c42b1917"), null, new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1269), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1281), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
