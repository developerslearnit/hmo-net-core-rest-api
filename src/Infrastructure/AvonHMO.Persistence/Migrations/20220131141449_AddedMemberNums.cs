using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedMemberNums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "MemberNo",
                table: "Users",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "Users");

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
    }
}
