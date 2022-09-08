using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Referral_requests_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrolleeDependant",
                table: "EnrolleeDependant");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2781dc62-75ec-440d-978c-940e58980b68"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("60ef7081-74db-4b21-9937-9867b1bb0152"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("91181286-5218-447c-b048-10530b62622f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d8c71ce3-5ca7-40e6-9659-6b8e73ab62dd"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("2dd480aa-b811-46a7-827c-a73fe8617ccc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7a6da277-035b-41ce-a3df-cd37a37b26e4"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("860565ad-d276-4285-a900-8a7c669086ec"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("3cc85f52-5dd5-4d59-859a-3044b86efbc9"));

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "EnrolleeDependant");

            migrationBuilder.RenameTable(
                name: "EnrolleeDependant",
                newName: "EnrolleeDependants");

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipId",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AlterColumn<string>(
                name: "EnrolleeId",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "DependantRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "DependantRequestId",
                table: "DependantRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "MemberNo",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "DependantRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "EnrolleeDependants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipId",
                table: "EnrolleeDependants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "EnrolleeDependants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "EnrolleeDependants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EnrolleeDependants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadMemberEmail",
                table: "EnrolleeDependants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HeadmemberNo",
                table: "EnrolleeDependants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberNo",
                table: "EnrolleeDependants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Relationship",
                table: "EnrolleeDependants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrolleeDependants",
                table: "EnrolleeDependants",
                column: "EnrolleeDependantId");

            migrationBuilder.CreateTable(
                name: "DrugRefillRequests",
                columns: table => new
                {
                    DrugRefillRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EnrolleeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliverAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugRefillRequests", x => x.DrugRefillRequestId);
                });

            migrationBuilder.CreateTable(
                name: "EnrolleeReferalCodes",
                columns: table => new
                {
                    EnrolleeReferalCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ReferalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeReferalCodes", x => x.EnrolleeReferalCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Referalhistories",
                columns: table => new
                {
                    ReferalhistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNo = table.Column<int>(type: "int", nullable: true),
                    ReferalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InviteePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferalLink = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReferDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referalhistories", x => x.ReferalhistoryId);
                });

            migrationBuilder.CreateTable(
                name: "ReferalTransactions",
                columns: table => new
                {
                    ReferalTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ReferalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    MemberNo = table.Column<int>(type: "int", nullable: true),
                    EnrolleeReferalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolleeIviteeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    PlanCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferalTransactions", x => x.ReferalTransactionId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("76efc9bb-9c32-4807-be2a-be6b90e7530c"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1462), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1462), false, "Enrollee", "Admin" },
                    { new Guid("9a5ed4cd-0a1d-4d63-8db0-3eb860494e7b"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1458), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1459), false, "Admin", "Admin" },
                    { new Guid("b33bae85-f688-4954-b258-2b726bf9505b"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1466), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1467), false, "Provider", "Admin" },
                    { new Guid("fde7faa2-c39b-4335-8951-d87427e4fddc"), "Admin", new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1464), new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1465), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("203c0873-1dde-493f-b580-d251a9ef4ca3"), "SENDGRID_KEY", "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" },
                    { new Guid("686c8b9a-1bf2-47c7-8a7b-d4fa5f604939"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("9b297d6a-0e70-4369-afcc-779ed6476ecd"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("4764ce57-72bd-469f-94f4-5001c42b1917"), null, new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1269), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 16, 14, 43, 30, 980, DateTimeKind.Local).AddTicks(1281), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugRefillRequests");

            migrationBuilder.DropTable(
                name: "EnrolleeReferalCodes");

            migrationBuilder.DropTable(
                name: "Referalhistories");

            migrationBuilder.DropTable(
                name: "ReferalTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrolleeDependants",
                table: "EnrolleeDependants");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("76efc9bb-9c32-4807-be2a-be6b90e7530c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9a5ed4cd-0a1d-4d63-8db0-3eb860494e7b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("b33bae85-f688-4954-b258-2b726bf9505b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fde7faa2-c39b-4335-8951-d87427e4fddc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("203c0873-1dde-493f-b580-d251a9ef4ca3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("686c8b9a-1bf2-47c7-8a7b-d4fa5f604939"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9b297d6a-0e70-4369-afcc-779ed6476ecd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("4764ce57-72bd-469f-94f4-5001c42b1917"));

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "DependantRequests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "DependantRequests");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "DependantRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EnrolleeDependants");

            migrationBuilder.DropColumn(
                name: "HeadMemberEmail",
                table: "EnrolleeDependants");

            migrationBuilder.DropColumn(
                name: "HeadmemberNo",
                table: "EnrolleeDependants");

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "EnrolleeDependants");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "EnrolleeDependants");

            migrationBuilder.RenameTable(
                name: "EnrolleeDependants",
                newName: "EnrolleeDependant");

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipId",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnrolleeId",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "DependantRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DependantRequestId",
                table: "DependantRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "EnrolleeDependant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelationshipId",
                table: "EnrolleeDependant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "EnrolleeDependant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "EnrolleeDependant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "EnrolleeDependant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrolleeDependant",
                table: "EnrolleeDependant",
                column: "EnrolleeDependantId");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2781dc62-75ec-440d-978c-940e58980b68"), "Admin", new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2828), new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2829), false, "Client", "Admin" },
                    { new Guid("60ef7081-74db-4b21-9937-9867b1bb0152"), "Admin", new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2812), new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2813), false, "Enrollee", "Admin" },
                    { new Guid("91181286-5218-447c-b048-10530b62622f"), "Admin", new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2831), new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2831), false, "Provider", "Admin" },
                    { new Guid("d8c71ce3-5ca7-40e6-9659-6b8e73ab62dd"), "Admin", new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2809), new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2809), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("2dd480aa-b811-46a7-827c-a73fe8617ccc"), "SENDGRID_KEY", "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" },
                    { new Guid("7a6da277-035b-41ce-a3df-cd37a37b26e4"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("860565ad-d276-4285-a900-8a7c669086ec"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("3cc85f52-5dd5-4d59-859a-3044b86efbc9"), null, new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2601), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 15, 10, 38, 37, 499, DateTimeKind.Local).AddTicks(2624), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
