using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SimeonUpdate02032022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("05c65caf-3bb4-456f-804e-812cf8b26969"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8db3be97-249b-42dd-9ea0-7e763353df0d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dd16fac1-9746-4794-a5d3-5176adb7af96"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("de18c9b1-dcea-4208-a2ab-d7932fdeb49b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6185c107-51fd-4f67-a97a-04228e496eed"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a00f20ac-daa7-4e79-b7f2-4cec51c77ef7"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ecc741f1-f1b2-43c6-abac-5bc001389369"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("6d4a71d8-23b2-494c-839b-0e6736e9b366"));

            migrationBuilder.AddColumn<int>(
                name: "MemberNo",
                table: "RequestAuthorizations",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7abd7d75-b523-4dc7-ab5d-25ce0bcffc02"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4444), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4444), false, "Enrollee", "Admin" },
                    { new Guid("7d7d3d79-1d6e-4756-83fd-38994bc03b23"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4440), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4441), false, "Admin", "Admin" },
                    { new Guid("ca2fe0cf-bbda-489a-a1b8-14fecee42dde"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4446), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4446), false, "Client", "Admin" },
                    { new Guid("f612f77f-b181-4c1e-ba76-a36c1acb2b4e"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4447), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4448), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("77142cba-6064-4b84-955e-55315de0f003"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("c559c977-e8a6-4c8b-a3e4-11b0bc2b7f23"), "SENDGRID_KEY", "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" },
                    { new Guid("d4a7e563-b5ef-40d5-b317-933b0d9c1278"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("65c5dbb9-3784-416c-884f-8a7efc9661b2"), null, new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4296), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4312), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7abd7d75-b523-4dc7-ab5d-25ce0bcffc02"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7d7d3d79-1d6e-4756-83fd-38994bc03b23"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ca2fe0cf-bbda-489a-a1b8-14fecee42dde"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f612f77f-b181-4c1e-ba76-a36c1acb2b4e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("77142cba-6064-4b84-955e-55315de0f003"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c559c977-e8a6-4c8b-a3e4-11b0bc2b7f23"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d4a7e563-b5ef-40d5-b317-933b0d9c1278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("65c5dbb9-3784-416c-884f-8a7efc9661b2"));

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "RequestAuthorizations");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("05c65caf-3bb4-456f-804e-812cf8b26969"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8246), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8246), false, "Enrollee", "Admin" },
                    { new Guid("8db3be97-249b-42dd-9ea0-7e763353df0d"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8243), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8243), false, "Admin", "Admin" },
                    { new Guid("dd16fac1-9746-4794-a5d3-5176adb7af96"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8260), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8260), false, "Provider", "Admin" },
                    { new Guid("de18c9b1-dcea-4208-a2ab-d7932fdeb49b"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8248), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8248), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6185c107-51fd-4f67-a97a-04228e496eed"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("a00f20ac-daa7-4e79-b7f2-4cec51c77ef7"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ecc741f1-f1b2-43c6-abac-5bc001389369"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("6d4a71d8-23b2-494c-839b-0e6736e9b366"), null, new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(7892), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(7908), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
