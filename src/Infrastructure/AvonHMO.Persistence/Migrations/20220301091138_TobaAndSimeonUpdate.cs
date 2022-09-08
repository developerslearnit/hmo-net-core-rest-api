using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class TobaAndSimeonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("7125b6cb-0e14-4226-abd1-cb897ebae4e1"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3370), false, "Provider", "Admin" },
                    { new Guid("889d9ba4-e436-428d-9bc5-2398cc082620"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3356), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3356), false, "Enrollee", "Admin" },
                    { new Guid("9eb77eb5-255d-4291-93e2-013cb0b929b6"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3353), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3353), false, "Admin", "Admin" },
                    { new Guid("ac1a8fce-fe13-4346-8248-6900e99e0e9b"), "Admin", new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3358), new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3358), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("b688417c-e387-4e0e-a0f8-7a8038779eea"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b8e5e581-502a-4945-beca-8dba6c18a08b"), "SENDGRID_KEY", "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" },
                    { new Guid("c8069ad9-898a-4a00-bf6c-8f0a4aa43411"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("f6725edc-8bf3-49b6-8051-c32fb2e04589"), null, new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3174), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 1, 10, 11, 37, 158, DateTimeKind.Local).AddTicks(3191), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7125b6cb-0e14-4226-abd1-cb897ebae4e1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("889d9ba4-e436-428d-9bc5-2398cc082620"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9eb77eb5-255d-4291-93e2-013cb0b929b6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ac1a8fce-fe13-4346-8248-6900e99e0e9b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b688417c-e387-4e0e-a0f8-7a8038779eea"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b8e5e581-502a-4945-beca-8dba6c18a08b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c8069ad9-898a-4a00-bf6c-8f0a4aa43411"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("f6725edc-8bf3-49b6-8051-c32fb2e04589"));

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
    }
}
