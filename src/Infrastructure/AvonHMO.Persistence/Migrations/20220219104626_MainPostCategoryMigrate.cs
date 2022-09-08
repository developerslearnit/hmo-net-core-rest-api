using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class MainPostCategoryMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("01652fd4-abb4-4048-805c-9bb9671b9950"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8b6f1169-d2a8-45af-b486-d8ae1f06ddf6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9a2b7ded-8f4d-4784-984b-e5f6658696c2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dca790ad-1ae2-478f-972a-97e7c6a3506d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8e7efa68-2476-47fc-b0e7-5f624a48ef94"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b4b9a366-5cbb-4aaf-aae0-647fe13cf912"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d6caaf46-19cf-498c-a43b-9d24bb64de09"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("63192e21-15bc-44c9-bd32-e2dcb6219079"));

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("39e6513b-3dbb-4a90-acd0-c6b8da8f466a"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3977), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3978), false, "Admin", "Admin" },
                    { new Guid("5c2cc56b-0e43-492a-8052-d7c229171e36"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3980), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3980), false, "Enrollee", "Admin" },
                    { new Guid("72775a15-8260-4d56-9d7b-b4de799e1378"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3992), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3993), false, "Provider", "Admin" },
                    { new Guid("c0d2a640-c620-4b5e-8142-7d36cbe26538"), "Admin", new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3990), new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3991), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("945c2ff9-e3dd-4de6-bbf8-2545d6ed01de"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("97f78bf3-fd53-45b3-a633-b7e1af6d84ad"), "SENDGRID_KEY", "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" },
                    { new Guid("f589c003-efc3-42db-9b9c-ceaf421d83f2"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("4f4e78f3-2b12-46a2-9bd3-928c09fcf4b2"), null, new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3822), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 11, 46, 25, 172, DateTimeKind.Local).AddTicks(3836), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainCategories");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("39e6513b-3dbb-4a90-acd0-c6b8da8f466a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5c2cc56b-0e43-492a-8052-d7c229171e36"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("72775a15-8260-4d56-9d7b-b4de799e1378"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c0d2a640-c620-4b5e-8142-7d36cbe26538"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("945c2ff9-e3dd-4de6-bbf8-2545d6ed01de"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("97f78bf3-fd53-45b3-a633-b7e1af6d84ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f589c003-efc3-42db-9b9c-ceaf421d83f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("4f4e78f3-2b12-46a2-9bd3-928c09fcf4b2"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("01652fd4-abb4-4048-805c-9bb9671b9950"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8053), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8053), false, "Provider", "Admin" },
                    { new Guid("8b6f1169-d2a8-45af-b486-d8ae1f06ddf6"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8046), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8047), false, "Admin", "Admin" },
                    { new Guid("9a2b7ded-8f4d-4784-984b-e5f6658696c2"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8051), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8051), false, "Client", "Admin" },
                    { new Guid("dca790ad-1ae2-478f-972a-97e7c6a3506d"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8049), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8049), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("8e7efa68-2476-47fc-b0e7-5f624a48ef94"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b4b9a366-5cbb-4aaf-aae0-647fe13cf912"), "SENDGRID_KEY", "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" },
                    { new Guid("d6caaf46-19cf-498c-a43b-9d24bb64de09"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("63192e21-15bc-44c9-bd32-e2dcb6219079"), null, new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(7874), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(7887), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
