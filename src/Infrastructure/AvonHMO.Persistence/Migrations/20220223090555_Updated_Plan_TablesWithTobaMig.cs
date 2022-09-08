using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Updated_Plan_TablesWithTobaMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("06015ec9-9a93-4fe1-be36-43556a7b17f1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3dcac47b-5afb-4dd4-aa4f-feefb2dce496"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("638541b4-2371-43f9-909d-48637489e09c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a7652f0d-7173-4014-88f8-93d8984a5177"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("caf4765b-d3a0-4154-917c-f79280fcce36"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f3eb9def-e0a4-4b89-8bb8-c25eec1c1e33"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f4ebc47a-75fe-43ec-ad00-e05f4b05d985"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("149ee338-19da-4ca3-b253-761b5f74e7f8"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Enrollee",
                type: "nvarchar(50)",
                maxLength: 50,
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
                    { new Guid("012b1907-5f03-41e7-9a21-bc9e407314c8"), "Admin", new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3702), new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3702), false, "Admin", "Admin" },
                    { new Guid("18e00eec-827f-4685-80ff-b3f57c71b31b"), "Admin", new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3707), new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3707), false, "Enrollee", "Admin" },
                    { new Guid("828ba59e-3e7a-4a10-82f6-41eedd29a529"), "Admin", new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3710), new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3710), false, "Client", "Admin" },
                    { new Guid("bd35f495-2904-4658-b166-54fc3082b707"), "Admin", new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3712), new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3713), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6fe6640a-b56f-468d-8b5d-01a6696c843b"), "SENDGRID_KEY", "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" },
                    { new Guid("7126e5ff-571e-4809-9686-3baf6663b266"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("7763f76f-7670-4a64-9f32-b9ee3f1ddf23"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("5abbd6d4-c155-4be2-aac6-9c16bdb22c94"), null, new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3489), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 23, 10, 5, 53, 258, DateTimeKind.Local).AddTicks(3504), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("012b1907-5f03-41e7-9a21-bc9e407314c8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("18e00eec-827f-4685-80ff-b3f57c71b31b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("828ba59e-3e7a-4a10-82f6-41eedd29a529"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bd35f495-2904-4658-b166-54fc3082b707"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6fe6640a-b56f-468d-8b5d-01a6696c843b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7126e5ff-571e-4809-9686-3baf6663b266"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7763f76f-7670-4a64-9f32-b9ee3f1ddf23"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("5abbd6d4-c155-4be2-aac6-9c16bdb22c94"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Orders",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Orders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Enrollee",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Enrollee",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("06015ec9-9a93-4fe1-be36-43556a7b17f1"), "Admin", new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2287), new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2287), false, "Provider", "Admin" },
                    { new Guid("3dcac47b-5afb-4dd4-aa4f-feefb2dce496"), "Admin", new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2280), new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2280), false, "Admin", "Admin" },
                    { new Guid("638541b4-2371-43f9-909d-48637489e09c"), "Admin", new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2285), new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2285), false, "Client", "Admin" },
                    { new Guid("a7652f0d-7173-4014-88f8-93d8984a5177"), "Admin", new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2283), new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2284), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("caf4765b-d3a0-4154-917c-f79280fcce36"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f3eb9def-e0a4-4b89-8bb8-c25eec1c1e33"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("f4ebc47a-75fe-43ec-ad00-e05f4b05d985"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("149ee338-19da-4ca3-b253-761b5f74e7f8"), null, new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2123), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 23, 7, 35, 30, 869, DateTimeKind.Local).AddTicks(2136), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
