using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class UpdatedPostCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("39ade2e3-be11-4439-910f-6e3634194548"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("811ef985-4b16-4a80-bd92-51c848b24df8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("84f57e3e-add9-4c75-a3ca-0b3f5742c1a0"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a4b319d0-cd42-4965-a7a1-17c9f117b66f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("753569b7-85eb-488d-bf46-daf76296e4bf"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b1c79294-013a-4c69-aa39-f3a16813d745"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b308276a-9011-4161-8938-0b0b269c8b6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2fa64809-5361-41e6-9460-355d7ae09814"));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "PostCategories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Url",
                table: "PostCategories");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("39ade2e3-be11-4439-910f-6e3634194548"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8264), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8265), false, "Admin", "Admin" },
                    { new Guid("811ef985-4b16-4a80-bd92-51c848b24df8"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8269), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8270), false, "Client", "Admin" },
                    { new Guid("84f57e3e-add9-4c75-a3ca-0b3f5742c1a0"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8271), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8272), false, "Provider", "Admin" },
                    { new Guid("a4b319d0-cd42-4965-a7a1-17c9f117b66f"), "Admin", new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8267), new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8268), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("753569b7-85eb-488d-bf46-daf76296e4bf"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("b1c79294-013a-4c69-aa39-f3a16813d745"), "SENDGRID_KEY", "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" },
                    { new Guid("b308276a-9011-4161-8938-0b0b269c8b6d"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2fa64809-5361-41e6-9460-355d7ae09814"), null, new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8128), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 23, 14, 33, 20, 501, DateTimeKind.Local).AddTicks(8144), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
