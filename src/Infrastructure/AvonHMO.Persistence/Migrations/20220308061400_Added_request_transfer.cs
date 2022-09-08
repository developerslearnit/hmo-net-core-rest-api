using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Added_request_transfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8b3d203b-4add-425c-ad0c-9470f547a183"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("96441b07-9ab4-4c19-a041-cbec00fe8c5c"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("f4f43f76-81b9-437a-9ffa-7cbe867a2ce6"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("ff2d33be-e6ba-43d4-9c6b-c30e6d839c94"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("258d2ef6-333f-42fa-a734-5590b7ca02b8"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("8690a6ab-e592-4e6b-bf3a-c7b1f02831b0"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("bf94593e-1a5b-406b-9e74-50f8f5bce66a"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("298946b8-150a-4e47-81a2-4b9ca9431d47"));

            migrationBuilder.AddColumn<bool>(
                name: "CloseClaim",
                table: "Claims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CloseReason",
                table: "Claims",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("2e8e9206-93d5-44fa-aba2-98f5074bc6bb"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6242), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6243), false, "Enrollee", "Admin" },
            //        { new Guid("5d86b751-8c9e-435d-94d1-132ba073f789"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6239), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6240), false, "Admin", "Admin" },
            //        { new Guid("8839d8b0-ae14-4d67-86d3-9fee63bdc769"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6244), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6245), false, "Client", "Admin" },
            //        { new Guid("d1674888-5f2c-4529-8cfa-d89be206ac94"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6246), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6247), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("4ef16fe2-8691-44d8-8b04-6a4340daffdb"), "SENDGRID_KEY", "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" },
            //        { new Guid("d300a8fd-655a-4f8c-9132-0dac686a4c53"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("f1eaaf2f-1e04-43f2-84c4-565ecfa3ad46"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("7cb556cb-46b2-49f7-82fc-0d784bc22b90"), null, new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6104), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6123), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("2e8e9206-93d5-44fa-aba2-98f5074bc6bb"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("5d86b751-8c9e-435d-94d1-132ba073f789"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8839d8b0-ae14-4d67-86d3-9fee63bdc769"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("d1674888-5f2c-4529-8cfa-d89be206ac94"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("4ef16fe2-8691-44d8-8b04-6a4340daffdb"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("d300a8fd-655a-4f8c-9132-0dac686a4c53"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("f1eaaf2f-1e04-43f2-84c4-565ecfa3ad46"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("7cb556cb-46b2-49f7-82fc-0d784bc22b90"));

            migrationBuilder.DropColumn(
                name: "CloseClaim",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "CloseReason",
                table: "Claims");

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("8b3d203b-4add-425c-ad0c-9470f547a183"), "Admin", new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5462), new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5463), false, "Provider", "Admin" },
            //        { new Guid("96441b07-9ab4-4c19-a041-cbec00fe8c5c"), "Admin", new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5436), new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5436), false, "Admin", "Admin" },
            //        { new Guid("f4f43f76-81b9-437a-9ffa-7cbe867a2ce6"), "Admin", new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5438), new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5438), false, "Enrollee", "Admin" },
            //        { new Guid("ff2d33be-e6ba-43d4-9c6b-c30e6d839c94"), "Admin", new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5440), new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5440), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("258d2ef6-333f-42fa-a734-5590b7ca02b8"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("8690a6ab-e592-4e6b-bf3a-c7b1f02831b0"), "SENDGRID_KEY", "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" },
            //        { new Guid("bf94593e-1a5b-406b-9e74-50f8f5bce66a"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("298946b8-150a-4e47-81a2-4b9ca9431d47"), null, new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5310), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 6, 14, 12, 42, 857, DateTimeKind.Local).AddTicks(5324), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
