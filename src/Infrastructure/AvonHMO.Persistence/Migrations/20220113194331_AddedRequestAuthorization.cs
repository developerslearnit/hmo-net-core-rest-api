using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedRequestAuthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2406e346-990a-4f1d-9a70-3cd3e553ea2f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("434e3140-aa71-49cb-a1a8-d5d9bf879be1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("737089d6-ecce-4f4e-a017-e2a1073164fa"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7e39df58-c1c6-467e-bd36-8ac80a60b8ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("37110d62-db97-488f-97b5-dec3db5bf27b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("39233f21-c686-4cc2-83b7-7af75af6c59b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d83f8327-bd43-4346-b891-8d23a26efde2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("ce72a745-89a8-4268-bf4c-ba8e80faeac4"));

            migrationBuilder.CreateTable(
                name: "RequestAuthorizations",
                columns: table => new
                {
                    RequestAuthorizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrolleeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAuthorizations", x => x.RequestAuthorizationId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAuthorizations");

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

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2406e346-990a-4f1d-9a70-3cd3e553ea2f"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8141), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8141), false, "Admin", "Admin" },
                    { new Guid("434e3140-aa71-49cb-a1a8-d5d9bf879be1"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8145), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8145), false, "Enrollee", "Admin" },
                    { new Guid("737089d6-ecce-4f4e-a017-e2a1073164fa"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8147), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8148), false, "Client", "Admin" },
                    { new Guid("7e39df58-c1c6-467e-bd36-8ac80a60b8ad"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8149), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8150), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("37110d62-db97-488f-97b5-dec3db5bf27b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("39233f21-c686-4cc2-83b7-7af75af6c59b"), "SENDGRID_KEY", "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" },
                    { new Guid("d83f8327-bd43-4346-b891-8d23a26efde2"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("ce72a745-89a8-4268-bf4c-ba8e80faeac4"), null, new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(7981), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(7994), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
