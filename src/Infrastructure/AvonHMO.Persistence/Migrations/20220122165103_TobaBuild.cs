using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class TobaBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5896afd0-7aa4-4bfb-ab93-f92bd8753c96"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5ce69e06-1939-465b-ad28-2dab98d4e62c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("631485e1-2a60-4414-9dd8-e5211a283588"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fdf8699e-12d7-4b1c-9c58-11c7782ceed9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("58b9d881-2db2-4ba4-a7ec-3703caf4af50"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("95a79c56-f993-4202-8447-27542a82e714"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b07dc440-92cb-4063-aa7a-a645548779a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("1630825d-6113-4ba2-b9af-961b1f32d467"));

            migrationBuilder.AddColumn<Guid>(
                name: "CyclePlannerCategoryId",
                table: "CycleInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CyclePlannerCategoryId",
                table: "CycleInfo");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5896afd0-7aa4-4bfb-ab93-f92bd8753c96"), "Admin", new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3784), new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3785), false, "Provider", "Admin" },
                    { new Guid("5ce69e06-1939-465b-ad28-2dab98d4e62c"), "Admin", new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3767), new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3768), false, "Enrollee", "Admin" },
                    { new Guid("631485e1-2a60-4414-9dd8-e5211a283588"), "Admin", new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3782), new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3782), false, "Client", "Admin" },
                    { new Guid("fdf8699e-12d7-4b1c-9c58-11c7782ceed9"), "Admin", new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3764), new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3764), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("58b9d881-2db2-4ba4-a7ec-3703caf4af50"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("95a79c56-f993-4202-8447-27542a82e714"), "SENDGRID_KEY", "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" },
                    { new Guid("b07dc440-92cb-4063-aa7a-a645548779a2"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("1630825d-6113-4ba2-b9af-961b1f32d467"), null, new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3508), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 20, 18, 19, 30, 35, DateTimeKind.Local).AddTicks(3520), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
