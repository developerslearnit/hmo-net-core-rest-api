using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedSerialNoToplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "PlanTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerialNo",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("39ade2e3-be11-4439-910f-6e3634194548"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8264), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8265), false, "Admin", "Admin" },
                    { new Guid("811ef985-4b16-4a80-bd92-51c848b24df8"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8269), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8270), false, "Client", "Admin" },
                    { new Guid("84f57e3e-add9-4c75-a3ca-0b3f5742c1a0"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8271), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8272), false, "Provider", "Admin" },
                    { new Guid("a4b319d0-cd42-4965-a7a1-17c9f117b66f"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8267), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8268), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("753569b7-85eb-488d-bf46-daf76296e4bf"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("b1c79294-013a-4c69-aa39-f3a16813d745"), "SENDGRID_KEY", "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" },
                    { new Guid("b308276a-9011-4161-8938-0b0b269c8b6d"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2fa64809-5361-41e6-9460-355d7ae09814"), null, new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8128), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8144), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("39ade2e3-be11-4439-910f-6e3634194548"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("811ef985-4b16-4a80-bd92-51c848b24df8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("84f57e3e-add9-4c75-a3ca-0b3f5742c1a0"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a4b319d0-cd42-4965-a7a1-17c9f117b66f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("753569b7-85eb-488d-bf46-daf76296e4bf"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b1c79294-013a-4c69-aa39-f3a16813d745"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b308276a-9011-4161-8938-0b0b269c8b6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2fa64809-5361-41e6-9460-355d7ae09814"));

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Plans");

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
    }
}
