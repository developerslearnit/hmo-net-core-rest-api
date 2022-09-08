using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class UpdatedRiskAssesmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1beae35c-c003-4283-adc3-244db97968bb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4e22f3a8-9297-4138-bd63-716308179c0e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c837f710-415e-494c-931f-30f659f0387a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c90a538b-3d00-459a-80a1-0adcda99de6a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("25f0fe21-de21-4c8f-85b6-db0c63f19e3d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("86ff51a6-69e2-42ee-899f-1cbafad526fd"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("cc0b08c4-4320-4f9f-bbf9-eb812bd468a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("1e478de9-6e23-45ca-bacd-d69c8a22f96e"));

            migrationBuilder.AlterColumn<string>(
                name: "DrinkingFrequency",
                table: "RiskAssessmentRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateTable(
                name: "DependantRequests",
                columns: table => new
                {
                    DependantRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolleeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipId = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(newid())"),
                    YourPlan = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependantRequests", x => x.DependantRequestId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependantRequests");

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

            migrationBuilder.AlterColumn<string>(
                name: "DrinkingFrequency",
                table: "RiskAssessmentRequests",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1beae35c-c003-4283-adc3-244db97968bb"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2241), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2241), false, "Provider", "Admin" },
                    { new Guid("4e22f3a8-9297-4138-bd63-716308179c0e"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2239), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2239), false, "Client", "Admin" },
                    { new Guid("c837f710-415e-494c-931f-30f659f0387a"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2237), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2238), false, "Enrollee", "Admin" },
                    { new Guid("c90a538b-3d00-459a-80a1-0adcda99de6a"), "Admin", new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2235), new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2235), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("25f0fe21-de21-4c8f-85b6-db0c63f19e3d"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("86ff51a6-69e2-42ee-899f-1cbafad526fd"), "SENDGRID_KEY", "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" },
                    { new Guid("cc0b08c4-4320-4f9f-bbf9-eb812bd468a3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("1e478de9-6e23-45ca-bacd-d69c8a22f96e"), null, new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2115), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 15, 10, 21, 15, 242, DateTimeKind.Local).AddTicks(2129), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
