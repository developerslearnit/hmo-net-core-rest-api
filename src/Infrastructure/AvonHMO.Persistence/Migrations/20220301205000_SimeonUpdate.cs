using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SimeonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7125b6cb-0e14-4226-abd1-cb897ebae4e1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("889d9ba4-e436-428d-9bc5-2398cc082620"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9eb77eb5-255d-4291-93e2-013cb0b929b6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ac1a8fce-fe13-4346-8248-6900e99e0e9b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b688417c-e387-4e0e-a0f8-7a8038779eea"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b8e5e581-502a-4945-beca-8dba6c18a08b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c8069ad9-898a-4a00-bf6c-8f0a4aa43411"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("f6725edc-8bf3-49b6-8051-c32fb2e04589"));

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "DependantRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DependantRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnrolleeFeedbacks",
                columns: table => new
                {
                    EnrolleeFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeFeedbacks", x => x.EnrolleeFeedbackId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("05c65caf-3bb4-456f-804e-812cf8b26969"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8246), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8246), false, "Enrollee", "Admin" },
                    { new Guid("8db3be97-249b-42dd-9ea0-7e763353df0d"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8243), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8243), false, "Admin", "Admin" },
                    { new Guid("dd16fac1-9746-4794-a5d3-5176adb7af96"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8260), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8260), false, "Provider", "Admin" },
                    { new Guid("de18c9b1-dcea-4208-a2ab-d7932fdeb49b"), "Admin", new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8248), new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(8248), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6185c107-51fd-4f67-a97a-04228e496eed"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("a00f20ac-daa7-4e79-b7f2-4cec51c77ef7"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ecc741f1-f1b2-43c6-abac-5bc001389369"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("6d4a71d8-23b2-494c-839b-0e6736e9b366"), null, new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(7892), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 1, 21, 49, 58, 680, DateTimeKind.Local).AddTicks(7908), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolleeFeedbacks");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("05c65caf-3bb4-456f-804e-812cf8b26969"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8db3be97-249b-42dd-9ea0-7e763353df0d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dd16fac1-9746-4794-a5d3-5176adb7af96"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("de18c9b1-dcea-4208-a2ab-d7932fdeb49b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6185c107-51fd-4f67-a97a-04228e496eed"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a00f20ac-daa7-4e79-b7f2-4cec51c77ef7"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ecc741f1-f1b2-43c6-abac-5bc001389369"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("6d4a71d8-23b2-494c-839b-0e6736e9b366"));

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "DependantRequests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DependantRequests");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7125b6cb-0e14-4226-abd1-cb897ebae4e1"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3370), false, "Provider", "Admin" },
                    { new Guid("889d9ba4-e436-428d-9bc5-2398cc082620"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3356), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3356), false, "Enrollee", "Admin" },
                    { new Guid("9eb77eb5-255d-4291-93e2-013cb0b929b6"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3353), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3353), false, "Admin", "Admin" },
                    { new Guid("ac1a8fce-fe13-4346-8248-6900e99e0e9b"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3358), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3358), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("b688417c-e387-4e0e-a0f8-7a8038779eea"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b8e5e581-502a-4945-beca-8dba6c18a08b"), "SENDGRID_KEY", "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" },
                    { new Guid("c8069ad9-898a-4a00-bf6c-8f0a4aa43411"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("f6725edc-8bf3-49b6-8051-c32fb2e04589"), null, new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3174), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3191), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
