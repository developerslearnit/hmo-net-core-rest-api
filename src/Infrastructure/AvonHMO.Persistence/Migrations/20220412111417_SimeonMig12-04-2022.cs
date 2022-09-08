using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SimeonMig12042022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("4357dfa8-ce79-4ca3-b8af-3897321bfa4d"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("6ca401b2-9928-4468-9d48-b3b9b293fed7"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("ec399131-e73f-4a66-b0cc-1e6981fadf90"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("fb19151b-5f7a-480b-a46e-3cd5e0c69693"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("606d8422-6f64-4f2f-b635-7b47046e6f95"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("94761f60-a127-4e33-a0f5-1f6454697b46"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("b3019d79-f86e-4003-838f-f9f6344aab9c"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("720a4f26-7251-46b5-a221-20490d8b1bb0"));

            //migrationBuilder.DropColumn(
            //    name: "Phoneno",
            //    table: "Providers");

            migrationBuilder.AddColumn<decimal>(
                name: "EasyAccessingCare",
                table: "ProviderRatings",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SatisfactoryLevel",
                table: "ProviderRatings",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BeneficairyName",
                table: "EnrolleeRecommendations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecommendationCategory",
                table: "EnrolleeRecommendations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DependantRequests",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "DependantRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnrolleeComplaintAdminResponses",
                columns: table => new
                {
                    EnrolleeComplaintAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EnrolleeComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminResponse = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeComplaintAdminResponses", x => x.EnrolleeComplaintAdminId);
                });

            migrationBuilder.CreateTable(
                name: "EnrolleeComplaints",
                columns: table => new
                {
                    EnrolleeComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    ComplaintStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MemberNo = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeComplaints", x => x.EnrolleeComplaintId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolleeComplaintAdminResponses");

            migrationBuilder.DropTable(
                name: "EnrolleeComplaints");

            migrationBuilder.DropColumn(
                name: "EasyAccessingCare",
                table: "ProviderRatings");

            migrationBuilder.DropColumn(
                name: "SatisfactoryLevel",
                table: "ProviderRatings");

            migrationBuilder.DropColumn(
                name: "BeneficairyName",
                table: "EnrolleeRecommendations");

            migrationBuilder.DropColumn(
                name: "RecommendationCategory",
                table: "EnrolleeRecommendations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DependantRequests");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DependantRequests");

            migrationBuilder.AddColumn<string>(
                name: "Phoneno",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4357dfa8-ce79-4ca3-b8af-3897321bfa4d"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8772), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8772), false, "Client", "Admin" },
                    { new Guid("6ca401b2-9928-4468-9d48-b3b9b293fed7"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8774), false, "Provider", "Admin" },
                    { new Guid("ec399131-e73f-4a66-b0cc-1e6981fadf90"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8770), false, "Enrollee", "Admin" },
                    { new Guid("fb19151b-5f7a-480b-a46e-3cd5e0c69693"), "Admin", new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8766), new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8767), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("606d8422-6f64-4f2f-b635-7b47046e6f95"), "SENDGRID_KEY", "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" },
                    { new Guid("94761f60-a127-4e33-a0f5-1f6454697b46"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("b3019d79-f86e-4003-838f-f9f6344aab9c"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("720a4f26-7251-46b5-a221-20490d8b1bb0"), null, new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8509), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 14, 20, 42, 622, DateTimeKind.Local).AddTicks(8531), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
