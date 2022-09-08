using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class PlanAndSimeons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3f24dbdc-9bbe-4435-bd2a-6f2301281b75"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4800990f-be2d-43c8-8db9-00dcdc20ead2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a1e8e5df-4c7e-45d0-ab43-84439a66e307"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ef04ec8a-330a-42e7-a015-ae81e6026ac4"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("461d287d-8715-463f-a700-3d521acf5178"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("7d797270-98b5-4614-9339-c1305ba456e3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ac99f398-33db-475b-96ca-970c7806249a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("5cc033ae-cb3b-48b4-9572-756ef5a14e45"));

            migrationBuilder.AddColumn<string>(
                name: "PlanBgImage",
                table: "PlanTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HealthRiskAssessmentQuestions",
                columns: table => new
                {
                    HealthRiskAssessmentQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    QuestionText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Never = table.Column<int>(type: "int", nullable: false),
                    Ocassionally = table.Column<int>(type: "int", nullable: false),
                    Always = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRiskAssessmentQuestions", x => x.HealthRiskAssessmentQuestionId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("010ea7c9-d554-4a4f-a64c-a4ec670da17d"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3971), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3972), false, "Provider", "Admin" },
                    { new Guid("2d7249c3-27b8-4723-95db-02774a3d5d8e"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3964), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3965), false, "Admin", "Admin" },
                    { new Guid("a4e5a6de-35d7-4b7b-b984-65bdbdc68ae2"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3967), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3968), false, "Enrollee", "Admin" },
                    { new Guid("ce715dc0-d3b7-4eb8-82c6-c8cbd190d173"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3970), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3970), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("0006d263-9165-4579-b2e1-0ac61be60246"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("18ab063d-b7fc-4a19-96bd-28237e90b087"), "SENDGRID_KEY", "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" },
                    { new Guid("edf4675b-82e9-4439-af3b-908212ac3370"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2bc950b1-fde8-463b-8a8c-50762636a340"), null, new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3826), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3839), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRiskAssessmentQuestions");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("010ea7c9-d554-4a4f-a64c-a4ec670da17d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2d7249c3-27b8-4723-95db-02774a3d5d8e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a4e5a6de-35d7-4b7b-b984-65bdbdc68ae2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ce715dc0-d3b7-4eb8-82c6-c8cbd190d173"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("0006d263-9165-4579-b2e1-0ac61be60246"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("18ab063d-b7fc-4a19-96bd-28237e90b087"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("edf4675b-82e9-4439-af3b-908212ac3370"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2bc950b1-fde8-463b-8a8c-50762636a340"));

            migrationBuilder.DropColumn(
                name: "PlanBgImage",
                table: "PlanTypes");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3f24dbdc-9bbe-4435-bd2a-6f2301281b75"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2098), false, "Enrollee", "Admin" },
                    { new Guid("4800990f-be2d-43c8-8db9-00dcdc20ead2"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2100), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2100), false, "Client", "Admin" },
                    { new Guid("a1e8e5df-4c7e-45d0-ab43-84439a66e307"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2094), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2095), false, "Admin", "Admin" },
                    { new Guid("ef04ec8a-330a-42e7-a015-ae81e6026ac4"), "Admin", new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(2103), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("461d287d-8715-463f-a700-3d521acf5178"), "SENDGRID_KEY", "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" },
                    { new Guid("7d797270-98b5-4614-9339-c1305ba456e3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("ac99f398-33db-475b-96ca-970c7806249a"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("5cc033ae-cb3b-48b4-9572-756ef5a14e45"), null, new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(1830), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 16, 52, 26, 744, DateTimeKind.Local).AddTicks(1850), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
