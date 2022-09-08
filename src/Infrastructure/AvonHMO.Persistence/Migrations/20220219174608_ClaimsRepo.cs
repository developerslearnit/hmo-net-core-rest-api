using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class ClaimsRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("39e6513b-3dbb-4a90-acd0-c6b8da8f466a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5c2cc56b-0e43-492a-8052-d7c229171e36"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("72775a15-8260-4d56-9d7b-b4de799e1378"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c0d2a640-c620-4b5e-8142-7d36cbe26538"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("945c2ff9-e3dd-4de6-bbf8-2545d6ed01de"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("97f78bf3-fd53-45b3-a633-b7e1af6d84ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f589c003-efc3-42db-9b9c-ceaf421d83f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("4f4e78f3-2b12-46a2-9bd3-928c09fcf4b2"));

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PreAuthorizationCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlanID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Services = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EncounterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 5, nullable: false),
                    DrugQuantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "RequestQuotes",
                columns: table => new
                {
                    RequestQuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ContactRole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoToEnrollee = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    CompanyAndLargeAssociation = table.Column<bool>(type: "bit", nullable: false),
                    InternationalHealthPlan = table.Column<bool>(type: "bit", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestQuotes", x => x.RequestQuoteId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6f90e5b9-cf21-4474-9a74-8e1e225293f6"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3126), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3127), false, "Enrollee", "Admin" },
                    { new Guid("78c9ab33-2c4e-48cb-9bcd-cacfb9de31d8"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3131), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3131), false, "Provider", "Admin" },
                    { new Guid("a887bc49-0ac0-46b6-8d61-b5213a480c63"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3129), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3129), false, "Client", "Admin" },
                    { new Guid("e2869f78-99d2-4baf-ba0b-bc98117b6d1e"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3122), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3123), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("17ed906d-b5fc-4520-b9be-3a2f6145524e"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8af6b573-c5f2-42cd-a365-5b7ddd640a9c"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("da4cfdde-ccda-4be7-9200-c417e0e13458"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("080c8c96-9c6e-49ac-9737-ce4f12c13314"), null, new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(2971), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(2987), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "RequestQuotes");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6f90e5b9-cf21-4474-9a74-8e1e225293f6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("78c9ab33-2c4e-48cb-9bcd-cacfb9de31d8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a887bc49-0ac0-46b6-8d61-b5213a480c63"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e2869f78-99d2-4baf-ba0b-bc98117b6d1e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("17ed906d-b5fc-4520-b9be-3a2f6145524e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8af6b573-c5f2-42cd-a365-5b7ddd640a9c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("da4cfdde-ccda-4be7-9200-c417e0e13458"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("080c8c96-9c6e-49ac-9737-ce4f12c13314"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("39e6513b-3dbb-4a90-acd0-c6b8da8f466a"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3977), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3978), false, "Admin", "Admin" },
                    { new Guid("5c2cc56b-0e43-492a-8052-d7c229171e36"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3980), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3980), false, "Enrollee", "Admin" },
                    { new Guid("72775a15-8260-4d56-9d7b-b4de799e1378"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3992), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3993), false, "Provider", "Admin" },
                    { new Guid("c0d2a640-c620-4b5e-8142-7d36cbe26538"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3990), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3991), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("945c2ff9-e3dd-4de6-bbf8-2545d6ed01de"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("97f78bf3-fd53-45b3-a633-b7e1af6d84ad"), "SENDGRID_KEY", "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" },
                    { new Guid("f589c003-efc3-42db-9b9c-ceaf421d83f2"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("4f4e78f3-2b12-46a2-9bd3-928c09fcf4b2"), null, new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3822), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3836), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
