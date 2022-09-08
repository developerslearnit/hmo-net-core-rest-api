using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class ExistingEnrolleInfoTblAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Audit",
            //    table: "Audit");

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("2c007067-3d6f-490b-bd8f-3c486593f796"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("733c3831-c0e0-4c59-a18a-cbc4475ec620"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("74553af6-db7e-4892-93e5-8bcb4455dc4f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8a2718af-6fca-499c-a4aa-1ccb72b1f5d1"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6af1c353-412e-4903-ba4f-c67a023a4de3"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("9cb5549e-3520-4370-8074-c81b3d321a8d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("ecba183c-cd9e-47b6-b9a0-cd37211de7c5"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("89b2a130-90c6-4b62-b48e-6ab00712d42c"));

            //migrationBuilder.RenameTable(
            //    name: "Audit",
            //    newName: "AuditLogs");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvonStaff",
                table: "ExistingEnrolleAccountInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MemberNo",
                table: "ExistingEnrolleAccountInfos",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_AuditLogs",
            //    table: "AuditLogs",
            //    column: "Id");

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("4d4db0ff-1488-435b-87ab-5d15a6980176"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5710), false, "Provider", "Admin" },
            //        { new Guid("80e0e983-2101-4db8-a763-f7f09e690837"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5707), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5707), false, "Client", "Admin" },
            //        { new Guid("bd628966-8189-4fbd-9738-a144326414c4"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5705), false, "Enrollee", "Admin" },
            //        { new Guid("e5f6295a-2a30-47b8-aeaa-f0acd15fda73"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5702), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("1022b648-4bf1-4d1a-906b-1614fe275604"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("205ba000-4dc0-4e0f-a08f-e66670299a7c"), "SENDGRID_KEY", "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" },
            //        { new Guid("3c41f531-cfc7-4e4b-99c0-c07f8d9c1d4a"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("edc01bc8-3e81-44f4-9fad-1e87f745ffa9"), null, new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5532), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5551), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4d4db0ff-1488-435b-87ab-5d15a6980176"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("80e0e983-2101-4db8-a763-f7f09e690837"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bd628966-8189-4fbd-9738-a144326414c4"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e5f6295a-2a30-47b8-aeaa-f0acd15fda73"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1022b648-4bf1-4d1a-906b-1614fe275604"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("205ba000-4dc0-4e0f-a08f-e66670299a7c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3c41f531-cfc7-4e4b-99c0-c07f8d9c1d4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("edc01bc8-3e81-44f4-9fad-1e87f745ffa9"));

            migrationBuilder.DropColumn(
                name: "IsAvonStaff",
                table: "ExistingEnrolleAccountInfos");

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "ExistingEnrolleAccountInfos");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "Audit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audit",
                table: "Audit",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2c007067-3d6f-490b-bd8f-3c486593f796"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1079), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1079), false, "Client", "Admin" },
                    { new Guid("733c3831-c0e0-4c59-a18a-cbc4475ec620"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1074), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1075), false, "Admin", "Admin" },
                    { new Guid("74553af6-db7e-4892-93e5-8bcb4455dc4f"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1077), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1077), false, "Enrollee", "Admin" },
                    { new Guid("8a2718af-6fca-499c-a4aa-1ccb72b1f5d1"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1095), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1095), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6af1c353-412e-4903-ba4f-c67a023a4de3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("9cb5549e-3520-4370-8074-c81b3d321a8d"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ecba183c-cd9e-47b6-b9a0-cd37211de7c5"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("89b2a130-90c6-4b62-b48e-6ab00712d42c"), null, new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(888), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(908), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
