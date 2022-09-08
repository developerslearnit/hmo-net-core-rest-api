using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class NewTobaSim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7abd7d75-b523-4dc7-ab5d-25ce0bcffc02"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7d7d3d79-1d6e-4756-83fd-38994bc03b23"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ca2fe0cf-bbda-489a-a1b8-14fecee42dde"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f612f77f-b181-4c1e-ba76-a36c1acb2b4e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("77142cba-6064-4b84-955e-55315de0f003"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c559c977-e8a6-4c8b-a3e4-11b0bc2b7f23"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d4a7e563-b5ef-40d5-b317-933b0d9c1278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("65c5dbb9-3784-416c-884f-8a7efc9661b2"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0c8e62d4-0ee8-4f80-a424-59dd7f4f9aef"), "Admin", new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8511), new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8512), false, "Enrollee", "Admin" },
                    { new Guid("6473a924-c527-417b-87ab-18e68a087463"), "Admin", new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8515), false, "Provider", "Admin" },
                    { new Guid("83278ebc-4990-4575-85e2-1c15f06dd674"), "Admin", new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8508), new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8509), false, "Admin", "Admin" },
                    { new Guid("bd14553b-77ba-4e57-89da-94ca20558102"), "Admin", new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8513), new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8514), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("2b401405-62eb-4a99-94eb-24b43ecf6cdb"), "SENDGRID_KEY", "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" },
                    { new Guid("6329e149-583c-4d5a-a7d2-43a4d1cf8e6d"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("70c86bd5-ba65-4675-9804-3aa4fee6e5b6"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("5690ec7f-ab77-43dc-92ec-f802622e212a"), null, new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8324), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 4, 7, 20, 24, 15, DateTimeKind.Local).AddTicks(8338), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0c8e62d4-0ee8-4f80-a424-59dd7f4f9aef"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6473a924-c527-417b-87ab-18e68a087463"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("83278ebc-4990-4575-85e2-1c15f06dd674"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bd14553b-77ba-4e57-89da-94ca20558102"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("2b401405-62eb-4a99-94eb-24b43ecf6cdb"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6329e149-583c-4d5a-a7d2-43a4d1cf8e6d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("70c86bd5-ba65-4675-9804-3aa4fee6e5b6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("5690ec7f-ab77-43dc-92ec-f802622e212a"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7abd7d75-b523-4dc7-ab5d-25ce0bcffc02"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4444), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4444), false, "Enrollee", "Admin" },
                    { new Guid("7d7d3d79-1d6e-4756-83fd-38994bc03b23"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4440), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4441), false, "Admin", "Admin" },
                    { new Guid("ca2fe0cf-bbda-489a-a1b8-14fecee42dde"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4446), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4446), false, "Client", "Admin" },
                    { new Guid("f612f77f-b181-4c1e-ba76-a36c1acb2b4e"), "Admin", new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4447), new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4448), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("77142cba-6064-4b84-955e-55315de0f003"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("c559c977-e8a6-4c8b-a3e4-11b0bc2b7f23"), "SENDGRID_KEY", "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" },
                    { new Guid("d4a7e563-b5ef-40d5-b317-933b0d9c1278"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("65c5dbb9-3784-416c-884f-8a7efc9661b2"), null, new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4296), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 2, 7, 46, 5, 173, DateTimeKind.Local).AddTicks(4312), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
