using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Updated_Plan_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6cb3a6a9-937e-41bc-a763-b51f1614d850"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("832c7fb0-302b-4634-98c6-8548d8aea2d5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("931348b5-e784-4c21-b871-226699022bbd"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("aee6e917-31d9-4ffc-9227-1d1a431553eb"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("87c298c8-ce19-44ef-9f79-fa041d203658"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("96e8c161-0c26-45cc-ae56-6cafbf69ec7b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ad3ab5e0-3bf7-4e43-8ead-a49bae82bb8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("a5413fff-237b-42aa-b739-1d9bb178c8a3"));

            migrationBuilder.AddColumn<string>(
                name: "PlanColor",
                table: "PlanTypes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanIcon",
                table: "PlanTypes",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanBgImage",
                table: "Plans",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanColor",
                table: "Plans",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanIcon",
                table: "Plans",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PlanColor",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "PlanIcon",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "PlanBgImage",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanColor",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanIcon",
                table: "Plans");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6cb3a6a9-937e-41bc-a763-b51f1614d850"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3215), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3215), false, "Client", "Admin" },
                    { new Guid("832c7fb0-302b-4634-98c6-8548d8aea2d5"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3217), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3217), false, "Provider", "Admin" },
                    { new Guid("931348b5-e784-4c21-b871-226699022bbd"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3203), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3203), false, "Enrollee", "Admin" },
                    { new Guid("aee6e917-31d9-4ffc-9227-1d1a431553eb"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3200), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3200), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("87c298c8-ce19-44ef-9f79-fa041d203658"), "SENDGRID_KEY", "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" },
                    { new Guid("96e8c161-0c26-45cc-ae56-6cafbf69ec7b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ad3ab5e0-3bf7-4e43-8ead-a49bae82bb8b"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a5413fff-237b-42aa-b739-1d9bb178c8a3"), null, new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3047), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3063), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
