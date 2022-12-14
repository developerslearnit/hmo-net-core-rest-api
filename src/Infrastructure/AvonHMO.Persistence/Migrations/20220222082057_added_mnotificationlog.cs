using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class added_mnotificationlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("28a60aa2-3e82-4831-892e-ae8b945b7416"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bf5a90ea-235b-4160-9a8c-79f469f8bc1d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c3c48935-bf85-46dd-bb5d-ba7b5fe329b8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("edd75853-6aa0-4f81-bfbf-ac718f6a5926"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("668a6c16-c84b-4ed4-8b72-a7dc3e639dc2"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("85879fda-1210-400b-99db-b59fff6a1e3a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a666e372-4433-463b-8857-e4fe5a1e53fd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("884e5733-37a5-4a33-95a4-41b10b8080e3"));

            migrationBuilder.CreateTable(
                name: "NotificationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OwnerId = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("491300b0-5586-4aa5-81af-600ebd726ff5"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6022), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6022), false, "Provider", "Admin" },
                    { new Guid("4aed7226-4697-466e-83f8-b85a3c02452b"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6020), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6020), false, "Client", "Admin" },
                    { new Guid("ceadac15-9fc3-4a0c-918e-3ac0d23a5677"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6005), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6005), false, "Enrollee", "Admin" },
                    { new Guid("f7795c38-afab-43d4-b0c2-909f9a3c9ab8"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6002), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6003), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("5349450b-bb53-4f9d-959f-c72edf0e10e6"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("534f313a-6de9-40cc-9139-49dabdea4217"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f2d3401d-6346-4e5e-9f17-a9fd50e62af7"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("da054d90-696d-4775-bd01-23ff0f82394b"), null, new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(5795), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(5811), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationLogs");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("491300b0-5586-4aa5-81af-600ebd726ff5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4aed7226-4697-466e-83f8-b85a3c02452b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ceadac15-9fc3-4a0c-918e-3ac0d23a5677"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f7795c38-afab-43d4-b0c2-909f9a3c9ab8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("5349450b-bb53-4f9d-959f-c72edf0e10e6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("534f313a-6de9-40cc-9139-49dabdea4217"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f2d3401d-6346-4e5e-9f17-a9fd50e62af7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("da054d90-696d-4775-bd01-23ff0f82394b"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("28a60aa2-3e82-4831-892e-ae8b945b7416"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1071), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1071), false, "Client", "Admin" },
                    { new Guid("bf5a90ea-235b-4160-9a8c-79f469f8bc1d"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1069), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1069), false, "Enrollee", "Admin" },
                    { new Guid("c3c48935-bf85-46dd-bb5d-ba7b5fe329b8"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1073), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1073), false, "Provider", "Admin" },
                    { new Guid("edd75853-6aa0-4f81-bfbf-ac718f6a5926"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1065), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1066), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("668a6c16-c84b-4ed4-8b72-a7dc3e639dc2"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("85879fda-1210-400b-99db-b59fff6a1e3a"), "SENDGRID_KEY", "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" },
                    { new Guid("a666e372-4433-463b-8857-e4fe5a1e53fd"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("884e5733-37a5-4a33-95a4-41b10b8080e3"), null, new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(882), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(904), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
