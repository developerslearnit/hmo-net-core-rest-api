using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Hospital_Reviews_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("33e76875-4fd2-41fe-89eb-8dbe64b0b770"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3b7db63e-9e9e-4c5b-bd82-6a01af5aa51d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("61e95825-5ac1-46f9-a32e-561133d2224e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f93a3ef4-1618-4188-be70-3ff58981ada1"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("605dd15d-54cf-46a8-84de-914e5cede5be"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7ae7bee8-1e94-4603-91e2-a0d444d36a08"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d8600b0c-2269-4478-a80f-b329a6b42f5a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("6b707a84-037d-47ad-b0e4-26dd8234f785"));

            migrationBuilder.CreateTable(
                name: "ProviderRatings",
                columns: table => new
                {
                    HospitalRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ReviewerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EnrolleeAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Review = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderRatings", x => x.HospitalRatingId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("85e1827f-f3c7-46bc-b5c7-bb8fc6dc691a"), "Admin", new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1322), new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1322), false, "Client", "Admin" },
                    { new Guid("8e78a081-ab36-4031-bb97-f8fced91fbf9"), "Admin", new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1324), new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1324), false, "Provider", "Admin" },
                    { new Guid("e4b7c59b-0384-4cc1-95f3-c2d52501b3b1"), "Admin", new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1307), new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1307), false, "Admin", "Admin" },
                    { new Guid("fb47afd6-125e-405c-a768-77485920473a"), "Admin", new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1309), new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1310), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("3512689e-588e-426c-a4f5-17d8175d6676"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("3d99bd18-1379-41a5-96c2-2f4996eaf2c1"), "SENDGRID_KEY", "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" },
                    { new Guid("958d5a6f-e98c-45e9-904d-aeb7c079bac6"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("fe57c044-c963-4c6c-8dfc-bc103965ec9c"), null, new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1165), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 26, 16, 7, 12, 706, DateTimeKind.Local).AddTicks(1180), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderRatings");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("85e1827f-f3c7-46bc-b5c7-bb8fc6dc691a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8e78a081-ab36-4031-bb97-f8fced91fbf9"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e4b7c59b-0384-4cc1-95f3-c2d52501b3b1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fb47afd6-125e-405c-a768-77485920473a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3512689e-588e-426c-a4f5-17d8175d6676"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3d99bd18-1379-41a5-96c2-2f4996eaf2c1"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("958d5a6f-e98c-45e9-904d-aeb7c079bac6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("fe57c044-c963-4c6c-8dfc-bc103965ec9c"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("33e76875-4fd2-41fe-89eb-8dbe64b0b770"), "Admin", new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(137), new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(138), false, "Provider", "Admin" },
                    { new Guid("3b7db63e-9e9e-4c5b-bd82-6a01af5aa51d"), "Admin", new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(131), new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(132), false, "Admin", "Admin" },
                    { new Guid("61e95825-5ac1-46f9-a32e-561133d2224e"), "Admin", new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(134), new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(134), false, "Enrollee", "Admin" },
                    { new Guid("f93a3ef4-1618-4188-be70-3ff58981ada1"), "Admin", new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(136), new DateTime(2022, 1, 24, 8, 20, 19, 957, DateTimeKind.Local).AddTicks(136), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("605dd15d-54cf-46a8-84de-914e5cede5be"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("7ae7bee8-1e94-4603-91e2-a0d444d36a08"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("d8600b0c-2269-4478-a80f-b329a6b42f5a"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("6b707a84-037d-47ad-b0e4-26dd8234f785"), null, new DateTime(2022, 1, 24, 8, 20, 19, 956, DateTimeKind.Local).AddTicks(9976), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 24, 8, 20, 19, 956, DateTimeKind.Local).AddTicks(9991), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
