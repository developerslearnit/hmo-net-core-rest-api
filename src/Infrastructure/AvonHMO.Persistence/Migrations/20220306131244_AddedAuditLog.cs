using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedAuditLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("1457899d-d3e2-40ea-96c9-fa8cb5bb0f25"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("68e68d1e-e9bf-41cd-9219-84795ae5251e"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("6d8b7385-800c-4918-b237-9871f1dfb8e1"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("c19e0863-b3cb-4d4e-b779-405452707f5c"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("4514840f-e09e-4372-8f3c-0371b9371303"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("4e226a42-869e-48ad-bc8c-0792345f4397"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("cad8649f-9af0-473f-af9a-742036ef0ee4"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("8f7b9bf5-47cd-4668-93c0-c267acf828c4"));

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

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

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1457899d-d3e2-40ea-96c9-fa8cb5bb0f25"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7561), false, "Enrollee", "Admin" },
            //        { new Guid("68e68d1e-e9bf-41cd-9219-84795ae5251e"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7563), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7563), false, "Client", "Admin" },
            //        { new Guid("6d8b7385-800c-4918-b237-9871f1dfb8e1"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7564), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7565), false, "Provider", "Admin" },
            //        { new Guid("c19e0863-b3cb-4d4e-b779-405452707f5c"), "Admin", new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7558), new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7558), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("4514840f-e09e-4372-8f3c-0371b9371303"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("4e226a42-869e-48ad-bc8c-0792345f4397"), "SENDGRID_KEY", "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" },
            //        { new Guid("cad8649f-9af0-473f-af9a-742036ef0ee4"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("8f7b9bf5-47cd-4668-93c0-c267acf828c4"), null, new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7372), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 4, 18, 10, 4, 630, DateTimeKind.Local).AddTicks(7387), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
