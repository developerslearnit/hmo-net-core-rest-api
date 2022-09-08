using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Simeons_update_17_03_2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("7ae7cc65-54e8-4d09-b6b8-6ee7651b54ef"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("9605a236-e66d-4323-a3ad-4ca439ab16c0"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("9d85833c-135e-455d-a506-31893a79fefa"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e47a4561-4d87-4d87-b646-dad19b2a931d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("3f0df57d-1d02-48f4-8c54-895a7084305c"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("5bca8c63-8371-4826-9d2e-9e6d72d02db4"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("ac40b62a-08b3-4443-93e9-08b0b69c4359"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("03714c7e-27f0-443c-9244-dadc197b3a2b"));

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "RequestAuthorizations");

            migrationBuilder.AddColumn<string>(
                name: "PlanName",
                table: "RequestQuotes",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvonEnrolleId",
                table: "RequestAuthorizations",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("0feb927a-9e59-4b45-a786-cdee2773b832"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2706), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2706), false, "Enrollee", "Admin" },
            //        { new Guid("3bb39042-d00a-4a7f-9768-382eb56ac454"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2708), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2708), false, "Client", "Admin" },
            //        { new Guid("420fa37b-2e27-4f38-a65e-3b858f667eeb"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2710), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2710), false, "Provider", "Admin" },
            //        { new Guid("f32fc052-f25c-40a6-b725-de697f2cac4e"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2703), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2704), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("32a4141e-25a4-4c10-bde0-516917798841"), "SENDGRID_KEY", "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" },
            //        { new Guid("4bcb3ae9-ae07-43c1-b631-17dd4c7b30ea"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("65760f9c-dc9c-4e35-93fc-29c5f6d0a09b"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("6126eb0b-f46b-42de-8791-0beb40091eaa"), null, new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2544), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2560), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0feb927a-9e59-4b45-a786-cdee2773b832"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3bb39042-d00a-4a7f-9768-382eb56ac454"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("420fa37b-2e27-4f38-a65e-3b858f667eeb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f32fc052-f25c-40a6-b725-de697f2cac4e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("32a4141e-25a4-4c10-bde0-516917798841"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4bcb3ae9-ae07-43c1-b631-17dd4c7b30ea"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("65760f9c-dc9c-4e35-93fc-29c5f6d0a09b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("6126eb0b-f46b-42de-8791-0beb40091eaa"));

            migrationBuilder.DropColumn(
                name: "PlanName",
                table: "RequestQuotes");

            migrationBuilder.DropColumn(
                name: "AvonEnrolleId",
                table: "RequestAuthorizations");

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
                    { new Guid("7ae7cc65-54e8-4d09-b6b8-6ee7651b54ef"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(158), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(159), false, "Client", "Admin" },
                    { new Guid("9605a236-e66d-4323-a3ad-4ca439ab16c0"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(154), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(154), false, "Admin", "Admin" },
                    { new Guid("9d85833c-135e-455d-a506-31893a79fefa"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(156), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(157), false, "Enrollee", "Admin" },
                    { new Guid("e47a4561-4d87-4d87-b646-dad19b2a931d"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(160), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(161), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("3f0df57d-1d02-48f4-8c54-895a7084305c"), "SENDGRID_KEY", "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" },
                    { new Guid("5bca8c63-8371-4826-9d2e-9e6d72d02db4"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ac40b62a-08b3-4443-93e9-08b0b69c4359"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("03714c7e-27f0-443c-9244-dadc197b3a2b"), null, new DateTime(2022, 3, 16, 13, 10, 28, 214, DateTimeKind.Local).AddTicks(9951), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 16, 13, 10, 28, 214, DateTimeKind.Local).AddTicks(9968), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
