using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class QuoterequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1f5b67ab-5a8d-42f3-a166-9c4fc0297744"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("42dca732-0720-4e13-a9cd-e1199ad914ab"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ac803d7a-bbc4-4d02-bdd9-13cb26e32f54"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e3dc5bf4-f296-4dd9-ac9e-b5ee6e081b0d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6c19b62b-808c-4c3e-b172-9dc0772db407"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a0536426-c284-40bd-b9fd-73048a7407f1"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("cc01c3b4-9153-4a06-9822-584d862693b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("0e2ff7d3-76d0-4159-9b38-8d07a8c11592"));

            migrationBuilder.AddColumn<string>(
                name: "PlanName",
                table: "RequestQuotes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("a25ecd60-5e30-42d8-9aa9-f849b822a4bc"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9555), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9555), false, "Client", "Admin" },
                    { new Guid("ae75d0e4-44eb-4acb-a552-a5a3a451ce78"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9553), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9553), false, "Enrollee", "Admin" },
                    { new Guid("d7dd38cf-ab07-4942-a817-b251c55306d3"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9550), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9550), false, "Admin", "Admin" },
                    { new Guid("f3d88a04-6719-49a4-aace-492cda5f0092"), "Admin", new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9557), new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9558), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("3db0eba9-9441-448f-a8ef-ef89f16ea913"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8c7d3edb-c1ab-47ce-a152-f8c6c0981dad"), "SENDGRID_KEY", "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" },
                    { new Guid("9db5fb6a-f437-4d3d-a062-547df4139b18"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("72beb0b1-0ee7-48c0-b23f-d49d553f6558"), null, new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9377), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 11, 13, 47, 54, DateTimeKind.Local).AddTicks(9393), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a25ecd60-5e30-42d8-9aa9-f849b822a4bc"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ae75d0e4-44eb-4acb-a552-a5a3a451ce78"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d7dd38cf-ab07-4942-a817-b251c55306d3"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f3d88a04-6719-49a4-aace-492cda5f0092"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3db0eba9-9441-448f-a8ef-ef89f16ea913"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8c7d3edb-c1ab-47ce-a152-f8c6c0981dad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9db5fb6a-f437-4d3d-a062-547df4139b18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("72beb0b1-0ee7-48c0-b23f-d49d553f6558"));

            migrationBuilder.DropColumn(
                name: "PlanName",
                table: "RequestQuotes");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1f5b67ab-5a8d-42f3-a166-9c4fc0297744"), "Admin", new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9539), new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9539), false, "Admin", "Admin" },
                    { new Guid("42dca732-0720-4e13-a9cd-e1199ad914ab"), "Admin", new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9544), new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9544), false, "Client", "Admin" },
                    { new Guid("ac803d7a-bbc4-4d02-bdd9-13cb26e32f54"), "Admin", new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9541), new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9542), false, "Enrollee", "Admin" },
                    { new Guid("e3dc5bf4-f296-4dd9-ac9e-b5ee6e081b0d"), "Admin", new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9546), new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9546), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6c19b62b-808c-4c3e-b172-9dc0772db407"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("a0536426-c284-40bd-b9fd-73048a7407f1"), "SENDGRID_KEY", "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" },
                    { new Guid("cc01c3b4-9153-4a06-9822-584d862693b2"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("0e2ff7d3-76d0-4159-9b38-8d07a8c11592"), null, new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9359), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 24, 9, 33, 13, 292, DateTimeKind.Local).AddTicks(9377), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
