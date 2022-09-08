using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Simeons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3c0dae74-a25c-4c6c-830b-666c7f35ca0f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("45f9d95c-d2dc-4671-9523-739b2c13c29d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("66675121-6c96-4fb0-83f6-5088c7b6708b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fb02b4e3-b350-4d9f-862a-367fdecf382a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("212f1995-264d-48e1-995e-4bebf30d0f71"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("70930e7e-ced8-4d98-9983-fa6535438dcf"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f35b79d5-8e6e-44f6-bb1a-1671b55b7c84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("28847881-71a6-4ded-bccd-d15f289a24e2"));

            migrationBuilder.DropColumn(
                name: "PlanName",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PlanName",
                table: "RequestQuotes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3c0dae74-a25c-4c6c-830b-666c7f35ca0f"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3248), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3248), false, "Client", "Admin" },
                    { new Guid("45f9d95c-d2dc-4671-9523-739b2c13c29d"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3245), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3246), false, "Enrollee", "Admin" },
                    { new Guid("66675121-6c96-4fb0-83f6-5088c7b6708b"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3249), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3250), false, "Provider", "Admin" },
                    { new Guid("fb02b4e3-b350-4d9f-862a-367fdecf382a"), "Admin", new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3243), new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3243), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("212f1995-264d-48e1-995e-4bebf30d0f71"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("70930e7e-ced8-4d98-9983-fa6535438dcf"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f35b79d5-8e6e-44f6-bb1a-1671b55b7c84"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("28847881-71a6-4ded-bccd-d15f289a24e2"), null, new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3061), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 12, 55, 21, 857, DateTimeKind.Local).AddTicks(3075), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
