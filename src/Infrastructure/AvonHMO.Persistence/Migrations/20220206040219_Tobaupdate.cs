using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Tobaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("729f3d25-121a-45b6-83cc-ae552dc6bd72"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7c2de483-f1fd-47de-9353-c1c3cd48db0d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c3f0dbe8-cb86-4f4a-9915-b0ecbdc2dea5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fbbe8857-41e6-4925-a631-218e34adc451"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("93f6c8f5-24fc-48e8-bffe-cdf9f63127bc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9c3f821e-69da-419f-b7f5-ed6cfa69e4d6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c13f77b0-1831-444c-a0bc-57646ec8e653"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("9661bbb4-2d1b-41db-be0c-8cdec794c4a6"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Enrollee",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsSponsored",
                table: "Enrollee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBenefact",
                table: "Enrollee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlanRate",
                table: "Enrollee",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Enrollee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkipOnlinePayment",
                table: "Enrollee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Enrollee",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4e32bdd1-4ba4-42f1-a6d3-c42c32dc3e2c"), "Admin", new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2990), new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2990), false, "Enrollee", "Admin" },
                    { new Guid("927b790e-5489-4310-bc07-bcb49aec50a9"), "Admin", new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2993), new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2994), false, "Provider", "Admin" },
                    { new Guid("9f605e8c-389a-4640-8ae9-8d3fbb5a320b"), "Admin", new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2992), new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2992), false, "Client", "Admin" },
                    { new Guid("fedee590-d6bb-490b-b1a0-0ba04e9adb5a"), "Admin", new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2986), new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2987), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("40045f69-aac4-4dca-864a-165856f7f60c"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("567fdcea-671b-4f31-a05d-20b7121e05a7"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("86539bb8-663a-44ac-8b8a-f15a55cebb4d"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("d25d1fa1-a1a3-4348-82a5-359bd613e621"), null, new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2820), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 6, 5, 2, 18, 612, DateTimeKind.Local).AddTicks(2835), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4e32bdd1-4ba4-42f1-a6d3-c42c32dc3e2c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("927b790e-5489-4310-bc07-bcb49aec50a9"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9f605e8c-389a-4640-8ae9-8d3fbb5a320b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fedee590-d6bb-490b-b1a0-0ba04e9adb5a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("40045f69-aac4-4dca-864a-165856f7f60c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("567fdcea-671b-4f31-a05d-20b7121e05a7"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("86539bb8-663a-44ac-8b8a-f15a55cebb4d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("d25d1fa1-a1a3-4348-82a5-359bd613e621"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "IsSponsored",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "NumberOfBenefact",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "PlanRate",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "SkipOnlinePayment",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Enrollee");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("729f3d25-121a-45b6-83cc-ae552dc6bd72"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(781), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(782), false, "Enrollee", "Admin" },
                    { new Guid("7c2de483-f1fd-47de-9353-c1c3cd48db0d"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(784), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(784), false, "Client", "Admin" },
                    { new Guid("c3f0dbe8-cb86-4f4a-9915-b0ecbdc2dea5"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(778), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(779), false, "Admin", "Admin" },
                    { new Guid("fbbe8857-41e6-4925-a631-218e34adc451"), "Admin", new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(795), new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(795), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("93f6c8f5-24fc-48e8-bffe-cdf9f63127bc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("9c3f821e-69da-419f-b7f5-ed6cfa69e4d6"), "SENDGRID_KEY", "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" },
                    { new Guid("c13f77b0-1831-444c-a0bc-57646ec8e653"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("9661bbb4-2d1b-41db-be0c-8cdec794c4a6"), null, new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(631), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 1, 9, 56, 45, 921, DateTimeKind.Local).AddTicks(644), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
