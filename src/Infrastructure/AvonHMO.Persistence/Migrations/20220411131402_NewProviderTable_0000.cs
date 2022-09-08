using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class NewProviderTable_0000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("4c6eed53-88b1-4848-983c-6059e8c5a80f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("62542324-f3c0-470b-9928-c3f0fffb094a"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("70e67e5f-3ac7-4aaf-96e0-a96f09824e85"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8191b13b-b12d-4957-a307-7dd73d6143a0"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("0347b62c-9ed8-454b-a6d3-1a3d9223880b"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("3c54f0ab-d746-462d-bfe9-7cb796a25acd"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6e0d992a-a684-4823-b922-c29dc2287ca8"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("f8e4e4f9-14d4-40b5-8155-17a75ee77545"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationHour",
                table: "Providers",
                type: "nvarchar(510)",
                maxLength: 510,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "Providers",
                type: "nvarchar(510)",
                maxLength: 510,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "LGA",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HMOOfficerGSM",
                table: "Providers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Providers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1d4e9022-2be1-4af7-a823-30e81159b320"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8444), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8444), false, "Enrollee", "Admin" },
            //        { new Guid("6de85654-ef39-4f06-afdf-33e4700300b8"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8448), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8448), false, "Provider", "Admin" },
            //        { new Guid("8432ec26-d8e1-45f7-9f83-025b20d9006b"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8432), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8433), false, "Admin", "Admin" },
            //        { new Guid("ed1a2784-c478-45f8-bd5b-6b7c5741c1ed"), "Admin", new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8446), new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8446), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("ac997fcb-5daa-41c9-ac15-c091b8ad48c7"), "SENDGRID_KEY", "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" },
            //        { new Guid("e033f24b-7a8b-4c41-8da7-87d8bcacc0cc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("f03a6e79-41d9-41a2-b20a-d74050ff1982"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("2e8ada69-b4df-429f-a871-124f7f70dbed"), null, new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8189), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 14, 14, 0, 670, DateTimeKind.Local).AddTicks(8209), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1d4e9022-2be1-4af7-a823-30e81159b320"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6de85654-ef39-4f06-afdf-33e4700300b8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8432ec26-d8e1-45f7-9f83-025b20d9006b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ed1a2784-c478-45f8-bd5b-6b7c5741c1ed"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac997fcb-5daa-41c9-ac15-c091b8ad48c7"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("e033f24b-7a8b-4c41-8da7-87d8bcacc0cc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f03a6e79-41d9-41a2-b20a-d74050ff1982"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2e8ada69-b4df-429f-a871-124f7f70dbed"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationHour",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(510)",
                oldMaxLength: 510,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(510)",
                oldMaxLength: 510);

            migrationBuilder.AlterColumn<string>(
                name: "LGA",
                table: "Providers",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HMOOfficerGSM",
                table: "Providers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Providers",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4c6eed53-88b1-4848-983c-6059e8c5a80f"), "Admin", new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2353), new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2354), false, "Admin", "Admin" },
                    { new Guid("62542324-f3c0-470b-9928-c3f0fffb094a"), "Admin", new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2373), false, "Provider", "Admin" },
                    { new Guid("70e67e5f-3ac7-4aaf-96e0-a96f09824e85"), "Admin", new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2371), new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2372), false, "Client", "Admin" },
                    { new Guid("8191b13b-b12d-4957-a307-7dd73d6143a0"), "Admin", new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2369), new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2369), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("0347b62c-9ed8-454b-a6d3-1a3d9223880b"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("3c54f0ab-d746-462d-bfe9-7cb796a25acd"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("6e0d992a-a684-4823-b922-c29dc2287ca8"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("f8e4e4f9-14d4-40b5-8155-17a75ee77545"), null, new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2075), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 14, 7, 21, 937, DateTimeKind.Local).AddTicks(2093), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
