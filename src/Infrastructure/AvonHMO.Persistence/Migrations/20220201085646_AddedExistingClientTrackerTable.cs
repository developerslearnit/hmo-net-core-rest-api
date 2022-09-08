using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedExistingClientTrackerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("025100da-3628-4648-8634-aac853c50657"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("330fd39e-ecd0-47f3-a132-344563d9bcab"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("67490da3-fa26-4edd-94c9-759c04fd9310"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f16a9ef0-065a-4b4f-be22-5044480194b9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("37696e2e-7899-4c56-a582-f1fa0cd7e1b4"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("84aedd25-d285-40c6-9800-edd2c5a65d32"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8890257b-8bfb-4e42-ad2a-69dd221b91db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("77528bc7-0ca8-494b-9239-ed2e041b141c"));

            migrationBuilder.CreateTable(
                name: "ExistingEnrolleAccountInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingEnrolleAccountInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("729f3d25-121a-45b6-83cc-ae552dc6bd72"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(781), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(782), false, "Enrollee", "Admin" },
                    { new Guid("7c2de483-f1fd-47de-9353-c1c3cd48db0d"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(784), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(784), false, "Client", "Admin" },
                    { new Guid("c3f0dbe8-cb86-4f4a-9915-b0ecbdc2dea5"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(778), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(779), false, "Admin", "Admin" },
                    { new Guid("fbbe8857-41e6-4925-a631-218e34adc451"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(795), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(795), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("93f6c8f5-24fc-48e8-bffe-cdf9f63127bc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("9c3f821e-69da-419f-b7f5-ed6cfa69e4d6"), "SENDGRID_KEY", "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" },
                    { new Guid("c13f77b0-1831-444c-a0bc-57646ec8e653"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("9661bbb4-2d1b-41db-be0c-8cdec794c4a6"), null, new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(631), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(644), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingEnrolleAccountInfos");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("729f3d25-121a-45b6-83cc-ae552dc6bd72"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7c2de483-f1fd-47de-9353-c1c3cd48db0d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c3f0dbe8-cb86-4f4a-9915-b0ecbdc2dea5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fbbe8857-41e6-4925-a631-218e34adc451"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("93f6c8f5-24fc-48e8-bffe-cdf9f63127bc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9c3f821e-69da-419f-b7f5-ed6cfa69e4d6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c13f77b0-1831-444c-a0bc-57646ec8e653"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("9661bbb4-2d1b-41db-be0c-8cdec794c4a6"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("025100da-3628-4648-8634-aac853c50657"), "Admin", new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1225), new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1226), false, "Enrollee", "Admin" },
                    { new Guid("330fd39e-ecd0-47f3-a132-344563d9bcab"), "Admin", new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1227), new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1228), false, "Client", "Admin" },
                    { new Guid("67490da3-fa26-4edd-94c9-759c04fd9310"), "Admin", new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1223), new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1223), false, "Admin", "Admin" },
                    { new Guid("f16a9ef0-065a-4b4f-be22-5044480194b9"), "Admin", new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1229), new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1229), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("37696e2e-7899-4c56-a582-f1fa0cd7e1b4"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("84aedd25-d285-40c6-9800-edd2c5a65d32"), "SENDGRID_KEY", "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" },
                    { new Guid("8890257b-8bfb-4e42-ad2a-69dd221b91db"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("77528bc7-0ca8-494b-9239-ed2e041b141c"), null, new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1073), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 31, 15, 14, 49, 79, DateTimeKind.Local).AddTicks(1086), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
