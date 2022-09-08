using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class TobaAndSimeon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("010ea7c9-d554-4a4f-a64c-a4ec670da17d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2d7249c3-27b8-4723-95db-02774a3d5d8e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a4e5a6de-35d7-4b7b-b984-65bdbdc68ae2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ce715dc0-d3b7-4eb8-82c6-c8cbd190d173"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("0006d263-9165-4579-b2e1-0ac61be60246"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("18ab063d-b7fc-4a19-96bd-28237e90b087"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("edf4675b-82e9-4439-af3b-908212ac3370"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("2bc950b1-fde8-463b-8a8c-50762636a340"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3428b331-6288-46bb-a6f1-4606afb1e6d9"), "Admin", new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7990), new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7990), false, "Enrollee", "Admin" },
                    { new Guid("571d0c13-3cc2-4286-9bbb-acb21c78fe31"), "Admin", new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7993), new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7994), false, "Provider", "Admin" },
                    { new Guid("8f0897ee-5edf-44c3-935f-ef5316b1b7da"), "Admin", new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7987), new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7987), false, "Admin", "Admin" },
                    { new Guid("958b0744-3064-4126-b7cd-468339b1521d"), "Admin", new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7992), new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7992), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("45c82230-d129-4f82-9ebf-08fa9c72c185"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("840fe704-de26-4a8f-aba9-63d38017a5b2"), "SENDGRID_KEY", "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" },
                    { new Guid("ef09eca0-1915-411e-b793-56ce89de44ca"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("34de5654-b7d6-4d4c-829a-29de20d69f41"), null, new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7819), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 28, 9, 59, 11, 790, DateTimeKind.Local).AddTicks(7833), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3428b331-6288-46bb-a6f1-4606afb1e6d9"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("571d0c13-3cc2-4286-9bbb-acb21c78fe31"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8f0897ee-5edf-44c3-935f-ef5316b1b7da"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("958b0744-3064-4126-b7cd-468339b1521d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("45c82230-d129-4f82-9ebf-08fa9c72c185"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("840fe704-de26-4a8f-aba9-63d38017a5b2"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ef09eca0-1915-411e-b793-56ce89de44ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("34de5654-b7d6-4d4c-829a-29de20d69f41"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("010ea7c9-d554-4a4f-a64c-a4ec670da17d"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3971), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3972), false, "Provider", "Admin" },
                    { new Guid("2d7249c3-27b8-4723-95db-02774a3d5d8e"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3964), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3965), false, "Admin", "Admin" },
                    { new Guid("a4e5a6de-35d7-4b7b-b984-65bdbdc68ae2"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3967), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3968), false, "Enrollee", "Admin" },
                    { new Guid("ce715dc0-d3b7-4eb8-82c6-c8cbd190d173"), "Admin", new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3970), new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3970), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("0006d263-9165-4579-b2e1-0ac61be60246"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("18ab063d-b7fc-4a19-96bd-28237e90b087"), "SENDGRID_KEY", "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" },
                    { new Guid("edf4675b-82e9-4439-af3b-908212ac3370"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2bc950b1-fde8-463b-8a8c-50762636a340"), null, new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3826), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 25, 5, 0, 59, 800, DateTimeKind.Local).AddTicks(3839), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
