using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class MarkedAddressAndEmailOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0b966135-e99b-495a-911b-e3999d0f2b1e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3b454e0f-6c1e-4cea-8f31-6fb7bc06bf45"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3c51ddf9-0dad-454c-a469-1d45c879483e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8adf7bca-ecdd-4728-b6c8-e9d991d15e45"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("513e9d9d-7111-43e4-a708-6fcbed4acf63"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7460d9c5-f53b-465b-b394-aab15d75f297"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("96fdbe89-3aaa-4f44-8f5f-a22e3aca6e82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("c14d038b-da79-48f9-a551-50fd90a9c5f4"));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4777626f-019e-463e-b381-2018a8cc6b11"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6294), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6294), false, "Admin", "Admin" },
                    { new Guid("60e5d814-64c8-4434-8adb-8d3c2ecc5064"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6297), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6297), false, "Enrollee", "Admin" },
                    { new Guid("7dd50bb9-7c6d-48ff-ac4d-26e8608253da"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6302), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6302), false, "Provider", "Admin" },
                    { new Guid("d378131d-87a8-4a34-a249-354c9d0ae5ad"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6299), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6300), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("742be0ce-2e19-4cd3-b330-24d736e421b8"), "SENDGRID_KEY", "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" },
                    { new Guid("aa03601b-7c37-4d1f-a6ba-b66d7436caf5"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b685780c-b212-43cd-87ef-958f2645d7f5"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("231fb3d5-4b11-4e82-9020-8d3f644bbe8d"), null, new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6080), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6095), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4777626f-019e-463e-b381-2018a8cc6b11"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("60e5d814-64c8-4434-8adb-8d3c2ecc5064"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7dd50bb9-7c6d-48ff-ac4d-26e8608253da"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d378131d-87a8-4a34-a249-354c9d0ae5ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("742be0ce-2e19-4cd3-b330-24d736e421b8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("aa03601b-7c37-4d1f-a6ba-b66d7436caf5"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b685780c-b212-43cd-87ef-958f2645d7f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("231fb3d5-4b11-4e82-9020-8d3f644bbe8d"));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0b966135-e99b-495a-911b-e3999d0f2b1e"), "Admin", new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1858), new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1859), false, "Admin", "Admin" },
                    { new Guid("3b454e0f-6c1e-4cea-8f31-6fb7bc06bf45"), "Admin", new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1861), new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1862), false, "Enrollee", "Admin" },
                    { new Guid("3c51ddf9-0dad-454c-a469-1d45c879483e"), "Admin", new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1866), new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1866), false, "Provider", "Admin" },
                    { new Guid("8adf7bca-ecdd-4728-b6c8-e9d991d15e45"), "Admin", new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1864), new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1864), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("513e9d9d-7111-43e4-a708-6fcbed4acf63"), "SENDGRID_KEY", "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" },
                    { new Guid("7460d9c5-f53b-465b-b394-aab15d75f297"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("96fdbe89-3aaa-4f44-8f5f-a22e3aca6e82"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c14d038b-da79-48f9-a551-50fd90a9c5f4"), null, new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1717), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 14, 1, 59, 707, DateTimeKind.Local).AddTicks(1730), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
