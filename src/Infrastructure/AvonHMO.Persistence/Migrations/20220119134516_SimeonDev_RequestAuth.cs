using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SimeonDev_RequestAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("06a5a625-aa15-4ffe-be87-2b61f740dff8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1d772b53-1650-4d49-ac3c-f937152583cb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9043d2a8-776e-4d2d-aa68-b2a49c031804"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a8c67338-d8b9-4e1b-bb19-df7ff0b47a25"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6a83f533-eee4-44f8-9d1c-6c67e55c2635"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ed80ef2e-5d0a-4f0e-8e30-bfc4821ab25d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f9ec6a4f-4dc6-4442-959d-c08b9588177f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("a2ddc022-7316-48c5-aa15-5d3e679e384f"));

            migrationBuilder.AddColumn<bool>(
                name: "RequestState",
                table: "DrugRefillRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RequestState",
                table: "DrugRefillRequests");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("06a5a625-aa15-4ffe-be87-2b61f740dff8"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4009), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4010), false, "Enrollee", "Admin" },
                    { new Guid("1d772b53-1650-4d49-ac3c-f937152583cb"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4014), false, "Provider", "Admin" },
                    { new Guid("9043d2a8-776e-4d2d-aa68-b2a49c031804"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4012), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4012), false, "Client", "Admin" },
                    { new Guid("a8c67338-d8b9-4e1b-bb19-df7ff0b47a25"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4006), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6a83f533-eee4-44f8-9d1c-6c67e55c2635"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("ed80ef2e-5d0a-4f0e-8e30-bfc4821ab25d"), "SENDGRID_KEY", "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" },
                    { new Guid("f9ec6a4f-4dc6-4442-959d-c08b9588177f"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a2ddc022-7316-48c5-aa15-5d3e679e384f"), null, new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(3856), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(3870), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
