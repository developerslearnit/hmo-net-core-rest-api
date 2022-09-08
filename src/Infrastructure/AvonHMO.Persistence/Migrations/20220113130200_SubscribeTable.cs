using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SubscribeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4749b3a9-47c1-46ea-9335-536ded0caac3"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7e6267c0-24fa-4c79-aba3-38b890674380"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bda27973-1042-4c5b-952d-d1cfd8cbe248"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e0719854-6bd9-4524-9d6a-24b50b16e20f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("099643b7-50f4-479f-9d32-cd93f18da1a7"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("55169977-5671-44b8-97cc-6ff1f5d19b85"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("81b1fa24-fbdb-44b1-a154-c29b013e4ba3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("da23f1fd-3020-4bed-8239-adf40adfab8b"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "State",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4749b3a9-47c1-46ea-9335-536ded0caac3"), "Admin", new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5994), new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5994), false, "Admin", "Admin" },
                    { new Guid("7e6267c0-24fa-4c79-aba3-38b890674380"), "Admin", new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5997), new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5997), false, "Enrollee", "Admin" },
                    { new Guid("bda27973-1042-4c5b-952d-d1cfd8cbe248"), "Admin", new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5999), new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(6000), false, "Client", "Admin" },
                    { new Guid("e0719854-6bd9-4524-9d6a-24b50b16e20f"), "Admin", new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(6011), new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(6012), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("099643b7-50f4-479f-9d32-cd93f18da1a7"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("55169977-5671-44b8-97cc-6ff1f5d19b85"), "SENDGRID_KEY", "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" },
                    { new Guid("81b1fa24-fbdb-44b1-a154-c29b013e4ba3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("da23f1fd-3020-4bed-8239-adf40adfab8b"), null, new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5844), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 10, 17, 29, 51, 256, DateTimeKind.Local).AddTicks(5857), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
