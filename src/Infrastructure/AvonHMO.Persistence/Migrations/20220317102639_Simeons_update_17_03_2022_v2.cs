using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Simeons_update_17_03_2022_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("0feb927a-9e59-4b45-a786-cdee2773b832"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("3bb39042-d00a-4a7f-9768-382eb56ac454"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("420fa37b-2e27-4f38-a65e-3b858f667eeb"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("f32fc052-f25c-40a6-b725-de697f2cac4e"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("32a4141e-25a4-4c10-bde0-516917798841"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("4bcb3ae9-ae07-43c1-b631-17dd4c7b30ea"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("65760f9c-dc9c-4e35-93fc-29c5f6d0a09b"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("6126eb0b-f46b-42de-8791-0beb40091eaa"));

            migrationBuilder.AddColumn<int>(
                name: "MemberNo",
                table: "RequestAuthorizations",
                type: "int",
                maxLength: 15,
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("24e99a62-86f8-48ad-8b95-0e9b0f26169f"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9931), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9931), false, "Enrollee", "Admin" },
            //        { new Guid("383f9f95-c0b1-47a8-a7db-92ea3322ea2a"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9944), false, "Client", "Admin" },
            //        { new Guid("7d8be949-8076-4dce-b7fb-9a0eff82986f"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9928), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9929), false, "Admin", "Admin" },
            //        { new Guid("cc09bcbd-0afc-4030-954b-ad8ec6200435"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9946), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("0c66d504-7f9f-46a3-8fbb-45b85e66f9f3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("bc137cff-e873-45b5-a2f1-5b62b795be87"), "SENDGRID_KEY", "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" },
            //        { new Guid("e4134b10-8022-4a4e-a927-f8f81145fa7d"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("2f8c1c85-54b9-4ac9-9e7f-85377fa55345"), null, new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9759), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9775), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("24e99a62-86f8-48ad-8b95-0e9b0f26169f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("383f9f95-c0b1-47a8-a7db-92ea3322ea2a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7d8be949-8076-4dce-b7fb-9a0eff82986f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("cc09bcbd-0afc-4030-954b-ad8ec6200435"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("0c66d504-7f9f-46a3-8fbb-45b85e66f9f3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("bc137cff-e873-45b5-a2f1-5b62b795be87"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("e4134b10-8022-4a4e-a927-f8f81145fa7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2f8c1c85-54b9-4ac9-9e7f-85377fa55345"));

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "RequestAuthorizations");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0feb927a-9e59-4b45-a786-cdee2773b832"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2706), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2706), false, "Enrollee", "Admin" },
                    { new Guid("3bb39042-d00a-4a7f-9768-382eb56ac454"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2708), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2708), false, "Client", "Admin" },
                    { new Guid("420fa37b-2e27-4f38-a65e-3b858f667eeb"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2710), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2710), false, "Provider", "Admin" },
                    { new Guid("f32fc052-f25c-40a6-b725-de697f2cac4e"), "Admin", new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2703), new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2704), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("32a4141e-25a4-4c10-bde0-516917798841"), "SENDGRID_KEY", "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" },
                    { new Guid("4bcb3ae9-ae07-43c1-b631-17dd4c7b30ea"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("65760f9c-dc9c-4e35-93fc-29c5f6d0a09b"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("6126eb0b-f46b-42de-8791-0beb40091eaa"), null, new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2544), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 11, 15, 6, 361, DateTimeKind.Local).AddTicks(2560), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
