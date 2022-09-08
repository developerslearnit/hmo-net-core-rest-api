using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class NewProviderTable_000022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationDay",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorCoverageHour",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "Providers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("4357dfa8-ce79-4ca3-b8af-3897321bfa4d"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8772), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8772), false, "Client", "Admin" },
            //        { new Guid("6ca401b2-9928-4468-9d48-b3b9b293fed7"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8774), false, "Provider", "Admin" },
            //        { new Guid("ec399131-e73f-4a66-b0cc-1e6981fadf90"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8770), false, "Enrollee", "Admin" },
            //        { new Guid("fb19151b-5f7a-480b-a46e-3cd5e0c69693"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8766), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8767), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("606d8422-6f64-4f2f-b635-7b47046e6f95"), "SENDGRID_KEY", "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" },
            //        { new Guid("94761f60-a127-4e33-a0f5-1f6454697b46"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("b3019d79-f86e-4003-838f-f9f6344aab9c"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("720a4f26-7251-46b5-a221-20490d8b1bb0"), null, new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8509), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8531), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4357dfa8-ce79-4ca3-b8af-3897321bfa4d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6ca401b2-9928-4468-9d48-b3b9b293fed7"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ec399131-e73f-4a66-b0cc-1e6981fadf90"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fb19151b-5f7a-480b-a46e-3cd5e0c69693"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("606d8422-6f64-4f2f-b635-7b47046e6f95"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("94761f60-a127-4e33-a0f5-1f6454697b46"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b3019d79-f86e-4003-838f-f9f6344aab9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("720a4f26-7251-46b5-a221-20490d8b1bb0"));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationDay",
                table: "Providers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorCoverageHour",
                table: "Providers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "Providers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1d4e9022-2be1-4af7-a823-30e81159b320"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8444), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8444), false, "Enrollee", "Admin" },
                    { new Guid("6de85654-ef39-4f06-afdf-33e4700300b8"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8448), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8448), false, "Provider", "Admin" },
                    { new Guid("8432ec26-d8e1-45f7-9f83-025b20d9006b"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8432), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8433), false, "Admin", "Admin" },
                    { new Guid("ed1a2784-c478-45f8-bd5b-6b7c5741c1ed"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8446), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8446), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("ac997fcb-5daa-41c9-ac15-c091b8ad48c7"), "SENDGRID_KEY", "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" },
                    { new Guid("e033f24b-7a8b-4c41-8da7-87d8bcacc0cc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("f03a6e79-41d9-41a2-b20a-d74050ff1982"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2e8ada69-b4df-429f-a871-124f7f70dbed"), null, new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8189), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8209), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
