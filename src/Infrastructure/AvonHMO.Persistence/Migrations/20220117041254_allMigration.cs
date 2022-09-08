using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class allMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("198464ed-14b4-48ba-baff-f7cd6a4a0289"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("67885dab-c0fc-444d-b8f6-31e74d559adb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("692177db-a075-4d63-9654-4195168bde10"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a5007cd4-9c03-4f95-8023-c7436a79df7f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1a1aa2ce-39ea-4f99-9f54-ff09e303172f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4800fae2-3cfe-4719-995d-8fa06f8bb58a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac574f7c-6bab-44df-83b3-41bd01794c7f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("0d64b762-6588-4887-bdc5-4169b6b5783e"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Enrollee",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionePath",
                table: "DrugRefillRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ChangePrimaryProviderRequest",
                columns: table => new
                {
                    ChangeProviderRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentProviderCode = table.Column<int>(type: "int", nullable: false),
                    CurrentProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewProviderCode = table.Column<int>(type: "int", nullable: false),
                    NewProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePrimaryProviderRequest", x => x.ChangeProviderRequestId);
                });

            migrationBuilder.CreateTable(
                name: "CycleInfo",
                columns: table => new
                {
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodDuration = table.Column<int>(type: "int", nullable: false),
                    PeriodCycle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleInfo", x => x.CycleId);
                });

            migrationBuilder.CreateTable(
                name: "CyclePlannerCategory",
                columns: table => new
                {
                    CyclePlannerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyclePlannerCategory", x => x.CyclePlannerCategoryId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0f38eb4b-bf12-42f5-9d6d-6813e5d66e26"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2416), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2417), false, "Provider", "Admin" },
                    { new Guid("83fa1fc9-1411-43ab-aa34-cf2f0346f3c4"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2411), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2411), false, "Enrollee", "Admin" },
                    { new Guid("ac960b54-8888-4e72-8e2c-9b27f512a777"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2393), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2393), false, "Admin", "Admin" },
                    { new Guid("d046a357-7463-42f1-a9e8-3c8c127bb2ee"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2414), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2414), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("304d4f9f-4094-43f6-807a-319bcffc2465"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("afb4f2e2-bd3e-40fa-9a6f-7a93f24eec2d"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("de0c2d37-b106-42c9-9aa6-f7197974ab02"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("410baa55-7cf3-44ce-a4e2-25770d93d285"), null, new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2126), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2141), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangePrimaryProviderRequest");

            migrationBuilder.DropTable(
                name: "CycleInfo");

            migrationBuilder.DropTable(
                name: "CyclePlannerCategory");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0f38eb4b-bf12-42f5-9d6d-6813e5d66e26"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("83fa1fc9-1411-43ab-aa34-cf2f0346f3c4"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ac960b54-8888-4e72-8e2c-9b27f512a777"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d046a357-7463-42f1-a9e8-3c8c127bb2ee"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("304d4f9f-4094-43f6-807a-319bcffc2465"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("afb4f2e2-bd3e-40fa-9a6f-7a93f24eec2d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("de0c2d37-b106-42c9-9aa6-f7197974ab02"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("410baa55-7cf3-44ce-a4e2-25770d93d285"));

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Enrollee",
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
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Enrollee",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrescriptionePath",
                table: "DrugRefillRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("198464ed-14b4-48ba-baff-f7cd6a4a0289"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1323), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1324), false, "Admin", "Admin" },
                    { new Guid("67885dab-c0fc-444d-b8f6-31e74d559adb"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1335), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1336), false, "Provider", "Admin" },
                    { new Guid("692177db-a075-4d63-9654-4195168bde10"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1328), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1329), false, "Enrollee", "Admin" },
                    { new Guid("a5007cd4-9c03-4f95-8023-c7436a79df7f"), "Admin", new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1332), new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1332), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1a1aa2ce-39ea-4f99-9f54-ff09e303172f"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("4800fae2-3cfe-4719-995d-8fa06f8bb58a"), "SENDGRID_KEY", "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" },
                    { new Guid("ac574f7c-6bab-44df-83b3-41bd01794c7f"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("0d64b762-6588-4887-bdc5-4169b6b5783e"), null, new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1080), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 16, 15, 45, 37, 155, DateTimeKind.Local).AddTicks(1094), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
