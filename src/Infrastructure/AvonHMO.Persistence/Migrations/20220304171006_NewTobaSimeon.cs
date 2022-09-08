using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class NewTobaSimeon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("0c8e62d4-0ee8-4f80-a424-59dd7f4f9aef"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("6473a924-c527-417b-87ab-18e68a087463"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("83278ebc-4990-4575-85e2-1c15f06dd674"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("bd14553b-77ba-4e57-89da-94ca20558102"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("2b401405-62eb-4a99-94eb-24b43ecf6cdb"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6329e149-583c-4d5a-a7d2-43a4d1cf8e6d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("70c86bd5-ba65-4675-9804-3aa4fee6e5b6"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("5690ec7f-ab77-43dc-92ec-f802622e212a"));

            migrationBuilder.AddColumn<bool>(
                name: "MonthlyRefill",
                table: "DrugRefillRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TempLog",
                columns: table => new
                {
                    TemLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PayLoad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempLog", x => x.TemLogId);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1457899d-d3e2-40ea-96c9-fa8cb5bb0f25"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7561), false, "Enrollee", "Admin" },
            //        { new Guid("68e68d1e-e9bf-41cd-9219-84795ae5251e"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7563), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7563), false, "Client", "Admin" },
            //        { new Guid("6d8b7385-800c-4918-b237-9871f1dfb8e1"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7564), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7565), false, "Provider", "Admin" },
            //        { new Guid("c19e0863-b3cb-4d4e-b779-405452707f5c"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7558), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7558), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("4514840f-e09e-4372-8f3c-0371b9371303"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("4e226a42-869e-48ad-bc8c-0792345f4397"), "SENDGRID_KEY", "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" },
            //        { new Guid("cad8649f-9af0-473f-af9a-742036ef0ee4"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("8f7b9bf5-47cd-4668-93c0-c267acf828c4"), null, new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7372), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7387), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        
        
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempLog");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1457899d-d3e2-40ea-96c9-fa8cb5bb0f25"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("68e68d1e-e9bf-41cd-9219-84795ae5251e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6d8b7385-800c-4918-b237-9871f1dfb8e1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c19e0863-b3cb-4d4e-b779-405452707f5c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4514840f-e09e-4372-8f3c-0371b9371303"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4e226a42-869e-48ad-bc8c-0792345f4397"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("cad8649f-9af0-473f-af9a-742036ef0ee4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("8f7b9bf5-47cd-4668-93c0-c267acf828c4"));

            migrationBuilder.DropColumn(
                name: "MonthlyRefill",
                table: "DrugRefillRequests");

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
    }
}
