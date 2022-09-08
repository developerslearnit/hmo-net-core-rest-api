using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class CyclePlannerDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4f42136e-78ab-4c1c-83d5-7eab78498c7b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("532bc8a2-59cc-4c89-8488-2b646152f805"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6faade26-fdf4-416c-bfc1-3e1e82d93b84"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e76d51af-3a73-45d5-b61e-9d0db1b679c8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4ddfc850-18ff-4124-b515-7aac6b65ac79"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d58c4268-d06f-4969-8b1c-a1ac3443d5af"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d7301a77-8c1b-4b3b-990a-c6363130e1fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("7bfb1d00-ea82-47f1-8e08-7d78758eedb0"));

            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "CycleInfo");

            migrationBuilder.RenameColumn(
                name: "EnrolleeId",
                table: "CycleInfo",
                newName: "AppuserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "AppuserId",
                table: "CycleInfo",
                newName: "EnrolleeId");

            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "CycleInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4f42136e-78ab-4c1c-83d5-7eab78498c7b"), "Admin", new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9853), new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9854), false, "Enrollee", "Admin" },
                    { new Guid("532bc8a2-59cc-4c89-8488-2b646152f805"), "Admin", new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9871), new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9871), false, "Provider", "Admin" },
                    { new Guid("6faade26-fdf4-416c-bfc1-3e1e82d93b84"), "Admin", new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9850), new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9851), false, "Admin", "Admin" },
                    { new Guid("e76d51af-3a73-45d5-b61e-9d0db1b679c8"), "Admin", new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9856), new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9856), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("4ddfc850-18ff-4124-b515-7aac6b65ac79"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("d58c4268-d06f-4969-8b1c-a1ac3443d5af"), "SENDGRID_KEY", "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" },
                    { new Guid("d7301a77-8c1b-4b3b-990a-c6363130e1fb"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("7bfb1d00-ea82-47f1-8e08-7d78758eedb0"), null, new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9592), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 22, 17, 51, 2, 456, DateTimeKind.Local).AddTicks(9607), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
