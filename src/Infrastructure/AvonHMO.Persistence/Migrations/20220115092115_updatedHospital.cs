using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class updatedHospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1f6bd178-57b4-40fa-b8b0-0e354857e965"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("42761d25-237f-4dc0-8b32-28cb27775ffb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("80f57577-bcea-40af-9f99-10a14aff6248"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("914c3b68-14a0-48bf-86a2-f447489b4a1b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("349674b9-e16b-48cf-afab-33fa939ac9da"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("5dbd0b79-5984-45b3-944c-7fda963ab92d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("74e3532f-d345-490f-9336-0a8c88ee80e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("9b03c839-8b58-41a6-aafc-16e629f5dd88"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "HospitalReviews");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "HospitalReviews");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PlanTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "HospitalReviews",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "HospitalReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "Enrollee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1beae35c-c003-4283-adc3-244db97968bb"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2241), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2241), false, "Provider", "Admin" },
                    { new Guid("4e22f3a8-9297-4138-bd63-716308179c0e"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2239), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2239), false, "Client", "Admin" },
                    { new Guid("c837f710-415e-494c-931f-30f659f0387a"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2237), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2238), false, "Enrollee", "Admin" },
                    { new Guid("c90a538b-3d00-459a-80a1-0adcda99de6a"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2235), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2235), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("25f0fe21-de21-4c8f-85b6-db0c63f19e3d"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("86ff51a6-69e2-42ee-899f-1cbafad526fd"), "SENDGRID_KEY", "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" },
                    { new Guid("cc0b08c4-4320-4f9f-bbf9-eb812bd468a3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("1e478de9-6e23-45ca-bacd-d69c8a22f96e"), null, new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2115), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2129), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1beae35c-c003-4283-adc3-244db97968bb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4e22f3a8-9297-4138-bd63-716308179c0e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c837f710-415e-494c-931f-30f659f0387a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c90a538b-3d00-459a-80a1-0adcda99de6a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("25f0fe21-de21-4c8f-85b6-db0c63f19e3d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("86ff51a6-69e2-42ee-899f-1cbafad526fd"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("cc0b08c4-4320-4f9f-bbf9-eb812bd468a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("1e478de9-6e23-45ca-bacd-d69c8a22f96e"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PlanTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "HospitalReviews");

            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "HospitalReviews",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "HospitalReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "HospitalReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1f6bd178-57b4-40fa-b8b0-0e354857e965"), "Admin", new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7643), new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7645), false, "Enrollee", "Admin" },
                    { new Guid("42761d25-237f-4dc0-8b32-28cb27775ffb"), "Admin", new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7652), new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7653), false, "Client", "Admin" },
                    { new Guid("80f57577-bcea-40af-9f99-10a14aff6248"), "Admin", new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7660), new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7661), false, "Provider", "Admin" },
                    { new Guid("914c3b68-14a0-48bf-86a2-f447489b4a1b"), "Admin", new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7631), new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7633), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("349674b9-e16b-48cf-afab-33fa939ac9da"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("5dbd0b79-5984-45b3-944c-7fda963ab92d"), "SENDGRID_KEY", "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" },
                    { new Guid("74e3532f-d345-490f-9336-0a8c88ee80e7"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("9b03c839-8b58-41a6-aafc-16e629f5dd88"), null, new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7081), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 20, 43, 30, 396, DateTimeKind.Local).AddTicks(7113), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
