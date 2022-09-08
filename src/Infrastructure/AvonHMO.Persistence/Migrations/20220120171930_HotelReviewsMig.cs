using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class HotelReviewsMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2909b555-0ecc-4deb-8a86-3637fd3a6c01"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d805477a-6f62-4bea-bc5a-23336668eb7f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dd3c4fd1-ccea-4100-bdbe-5db87c6672b6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e6da9682-d5b7-4367-9902-937230325d73"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("0aebc834-4868-41bc-8ceb-45ae9c4462d5"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("676ccbdd-fc29-48b1-8910-80c458045fc6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("af329d80-4f93-477b-8d94-52d5456f854d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("cfd37306-ff1c-42ac-9bc4-11d186ba8835"));

            migrationBuilder.AlterColumn<string>(
                name: "MemberNumber",
                table: "HospitalReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "EnrolleeId",
                table: "HospitalReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "HospitalCode",
                table: "HospitalReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EnrolleeId",
                table: "HospitalReviews");

            migrationBuilder.DropColumn(
                name: "HospitalCode",
                table: "HospitalReviews");

            migrationBuilder.AlterColumn<int>(
                name: "MemberNumber",
                table: "HospitalReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2909b555-0ecc-4deb-8a86-3637fd3a6c01"), "Admin", new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8666), new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8667), false, "Enrollee", "Admin" },
                    { new Guid("d805477a-6f62-4bea-bc5a-23336668eb7f"), "Admin", new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8684), new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8684), false, "Client", "Admin" },
                    { new Guid("dd3c4fd1-ccea-4100-bdbe-5db87c6672b6"), "Admin", new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8663), new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8663), false, "Admin", "Admin" },
                    { new Guid("e6da9682-d5b7-4367-9902-937230325d73"), "Admin", new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8686), new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8687), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("0aebc834-4868-41bc-8ceb-45ae9c4462d5"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("676ccbdd-fc29-48b1-8910-80c458045fc6"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("af329d80-4f93-477b-8d94-52d5456f854d"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("cfd37306-ff1c-42ac-9bc4-11d186ba8835"), null, new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8435), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 19, 14, 45, 16, 0, DateTimeKind.Local).AddTicks(8454), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
