using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class updated_plan_and_settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6f90e5b9-cf21-4474-9a74-8e1e225293f6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("78c9ab33-2c4e-48cb-9bcd-cacfb9de31d8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a887bc49-0ac0-46b6-8d61-b5213a480c63"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e2869f78-99d2-4baf-ba0b-bc98117b6d1e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("17ed906d-b5fc-4520-b9be-3a2f6145524e"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8af6b573-c5f2-42cd-a365-5b7ddd640a9c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("da4cfdde-ccda-4be7-9200-c417e0e13458"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("080c8c96-9c6e-49ac-9737-ce4f12c13314"));

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    PrefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrefKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrefValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.PrefId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("28a60aa2-3e82-4831-892e-ae8b945b7416"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1071), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1071), false, "Client", "Admin" },
                    { new Guid("bf5a90ea-235b-4160-9a8c-79f469f8bc1d"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1069), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1069), false, "Enrollee", "Admin" },
                    { new Guid("c3c48935-bf85-46dd-bb5d-ba7b5fe329b8"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1073), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1073), false, "Provider", "Admin" },
                    { new Guid("edd75853-6aa0-4f81-bfbf-ac718f6a5926"), "Admin", new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1065), new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(1066), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("668a6c16-c84b-4ed4-8b72-a7dc3e639dc2"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("85879fda-1210-400b-99db-b59fff6a1e3a"), "SENDGRID_KEY", "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" },
                    { new Guid("a666e372-4433-463b-8857-e4fe5a1e53fd"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("884e5733-37a5-4a33-95a4-41b10b8080e3"), null, new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(882), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 21, 10, 15, 8, 110, DateTimeKind.Local).AddTicks(904), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("28a60aa2-3e82-4831-892e-ae8b945b7416"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("bf5a90ea-235b-4160-9a8c-79f469f8bc1d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c3c48935-bf85-46dd-bb5d-ba7b5fe329b8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("edd75853-6aa0-4f81-bfbf-ac718f6a5926"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("668a6c16-c84b-4ed4-8b72-a7dc3e639dc2"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("85879fda-1210-400b-99db-b59fff6a1e3a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a666e372-4433-463b-8857-e4fe5a1e53fd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("884e5733-37a5-4a33-95a4-41b10b8080e3"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6f90e5b9-cf21-4474-9a74-8e1e225293f6"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3126), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3127), false, "Enrollee", "Admin" },
                    { new Guid("78c9ab33-2c4e-48cb-9bcd-cacfb9de31d8"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3131), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3131), false, "Provider", "Admin" },
                    { new Guid("a887bc49-0ac0-46b6-8d61-b5213a480c63"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3129), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3129), false, "Client", "Admin" },
                    { new Guid("e2869f78-99d2-4baf-ba0b-bc98117b6d1e"), "Admin", new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3122), new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(3123), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("17ed906d-b5fc-4520-b9be-3a2f6145524e"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8af6b573-c5f2-42cd-a365-5b7ddd640a9c"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("da4cfdde-ccda-4be7-9200-c417e0e13458"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("080c8c96-9c6e-49ac-9737-ce4f12c13314"), null, new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(2971), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 18, 46, 7, 565, DateTimeKind.Local).AddTicks(2987), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
