using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Toba_Only_Update_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("205983a4-cb21-4cfa-bef0-e1f5deaea60f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("726c9371-1ae5-4e19-93f1-25ebd3a47612"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e2c4e75f-649d-41f7-8c09-edf32f3aea21"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("fdd8e3c2-d423-4070-9d6e-45e71a87dee6"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("13b4ca28-20a7-4e40-b294-c88b3e080a9a"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("e230952d-7a04-482e-8895-685fec15142c"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("fcea6800-fe01-49b2-9cba-3f67601cbc92"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("adaafc26-4af9-4ccc-9f4f-538d0086ee7c"));

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("7ae7cc65-54e8-4d09-b6b8-6ee7651b54ef"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(158), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(159), false, "Client", "Admin" },
            //        { new Guid("9605a236-e66d-4323-a3ad-4ca439ab16c0"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(154), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(154), false, "Admin", "Admin" },
            //        { new Guid("9d85833c-135e-455d-a506-31893a79fefa"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(156), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(157), false, "Enrollee", "Admin" },
            //        { new Guid("e47a4561-4d87-4d87-b646-dad19b2a931d"), "Admin", new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(160), new DateTime(2022, 3, 16, 13, 10, 28, 215, DateTimeKind.Local).AddTicks(161), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("3f0df57d-1d02-48f4-8c54-895a7084305c"), "SENDGRID_KEY", "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" },
            //        { new Guid("5bca8c63-8371-4826-9d2e-9e6d72d02db4"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("ac40b62a-08b3-4443-93e9-08b0b69c4359"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("03714c7e-27f0-443c-9244-dadc197b3a2b"), null, new DateTime(2022, 3, 16, 13, 10, 28, 214, DateTimeKind.Local).AddTicks(9951), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 16, 13, 10, 28, 214, DateTimeKind.Local).AddTicks(9968), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7ae7cc65-54e8-4d09-b6b8-6ee7651b54ef"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9605a236-e66d-4323-a3ad-4ca439ab16c0"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9d85833c-135e-455d-a506-31893a79fefa"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e47a4561-4d87-4d87-b646-dad19b2a931d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3f0df57d-1d02-48f4-8c54-895a7084305c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("5bca8c63-8371-4826-9d2e-9e6d72d02db4"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac40b62a-08b3-4443-93e9-08b0b69c4359"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("03714c7e-27f0-443c-9244-dadc197b3a2b"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("205983a4-cb21-4cfa-bef0-e1f5deaea60f"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2374), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2374), false, "Provider", "Admin" },
                    { new Guid("726c9371-1ae5-4e19-93f1-25ebd3a47612"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2371), false, "Enrollee", "Admin" },
                    { new Guid("e2c4e75f-649d-41f7-8c09-edf32f3aea21"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2367), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2368), false, "Admin", "Admin" },
                    { new Guid("fdd8e3c2-d423-4070-9d6e-45e71a87dee6"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2372), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2373), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("13b4ca28-20a7-4e40-b294-c88b3e080a9a"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("e230952d-7a04-482e-8895-685fec15142c"), "SENDGRID_KEY", "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" },
                    { new Guid("fcea6800-fe01-49b2-9cba-3f67601cbc92"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("adaafc26-4af9-4ccc-9f4f-538d0086ee7c"), null, new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2126), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2143), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
