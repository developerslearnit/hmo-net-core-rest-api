using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Simeons_RequestQuote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7dfcca04-e52e-4f8e-a0e5-cfcfdc2ecce4"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("b716fdc7-5433-49f7-87aa-759b608669d7"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dca66c64-da8b-40b9-b8af-bb65bdfdd092"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fdcced39-e2f6-41f5-a286-384def96e02d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("79422d55-75ac-4241-8b49-31bffbed9afe"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a24b4f46-d0c3-4e3b-958d-212493668424"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c6bd86da-ddb7-4b9b-9d00-c4a77b007637"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("c09f09a2-f1b1-480f-8fb5-81ea4f1fbcb8"));

            migrationBuilder.DropColumn(
                name: "PlanCode",
                table: "RequestQuotes");

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "RequestQuotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3f24dbdc-9bbe-4435-bd2a-6f2301281b75"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2098), false, "Enrollee", "Admin" },
                    { new Guid("4800990f-be2d-43c8-8db9-00dcdc20ead2"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2100), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2100), false, "Client", "Admin" },
                    { new Guid("a1e8e5df-4c7e-45d0-ab43-84439a66e307"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2094), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2095), false, "Admin", "Admin" },
                    { new Guid("ef04ec8a-330a-42e7-a015-ae81e6026ac4"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2103), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("461d287d-8715-463f-a700-3d521acf5178"), "SENDGRID_KEY", "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" },
                    { new Guid("7d797270-98b5-4614-9339-c1305ba456e3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("ac99f398-33db-475b-96ca-970c7806249a"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("5cc033ae-cb3b-48b4-9572-756ef5a14e45"), null, new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(1830), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(1850), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3f24dbdc-9bbe-4435-bd2a-6f2301281b75"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4800990f-be2d-43c8-8db9-00dcdc20ead2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a1e8e5df-4c7e-45d0-ab43-84439a66e307"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ef04ec8a-330a-42e7-a015-ae81e6026ac4"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("461d287d-8715-463f-a700-3d521acf5178"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7d797270-98b5-4614-9339-c1305ba456e3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac99f398-33db-475b-96ca-970c7806249a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("5cc033ae-cb3b-48b4-9572-756ef5a14e45"));

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "RequestQuotes");

            migrationBuilder.AddColumn<int>(
                name: "PlanCode",
                table: "RequestQuotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7dfcca04-e52e-4f8e-a0e5-cfcfdc2ecce4"), "Admin", new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9729), new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9729), false, "Client", "Admin" },
                    { new Guid("b716fdc7-5433-49f7-87aa-759b608669d7"), "Admin", new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9731), new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9731), false, "Provider", "Admin" },
                    { new Guid("dca66c64-da8b-40b9-b8af-bb65bdfdd092"), "Admin", new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9727), new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9727), false, "Enrollee", "Admin" },
                    { new Guid("fdcced39-e2f6-41f5-a286-384def96e02d"), "Admin", new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9724), new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9724), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("79422d55-75ac-4241-8b49-31bffbed9afe"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("a24b4f46-d0c3-4e3b-958d-212493668424"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("c6bd86da-ddb7-4b9b-9d00-c4a77b007637"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c09f09a2-f1b1-480f-8fb5-81ea4f1fbcb8"), null, new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9607), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 15, 23, 36, 372, DateTimeKind.Local).AddTicks(9622), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
