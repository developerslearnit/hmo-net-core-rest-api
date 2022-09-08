using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AppUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("1cad8626-fec6-4088-8dfb-b69b2051cb3a"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("347bad39-afd8-4ecc-b24a-0e468facfc2f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("55aa5cec-38ea-427d-aa30-159ba7f19dbf"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("df0f7184-2e70-44c2-a3ff-ab031721131d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("8a516de1-9d7b-4d1a-846c-3024ce73f5dc"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("ce8a65d8-9d76-4e1e-8f25-076eb82ec8eb"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("fc15f91c-6d3c-4221-bca2-fb91163fa9f3"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("542ee22e-9ac2-4244-8ffb-73f530fa4fe2"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordChangeDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginMemberNo",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("17d57920-3917-4935-8451-7eff52689cfe"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4729), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4730), false, "Provider", "Admin" },
            //        { new Guid("199df182-8751-4cf5-9518-cc02f2882c01"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4520), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4520), false, "Enrollee", "Admin" },
            //        { new Guid("19b70078-d775-474f-b55e-13dff1fb5cbe"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4517), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4517), false, "Admin", "Admin" },
            //        { new Guid("2f42db38-82b7-4a42-9a57-8d48b297b496"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4727), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4728), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("424bf998-cc48-410b-aec4-eae55bf680d8"), "SENDGRID_KEY", "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" },
            //        { new Guid("91093443-6cad-4ec0-bf65-2056dddc246b"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("a124cbbe-1b8f-4e4e-90cc-2dcd6b812b78"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("c7211a33-c196-49e7-bb6b-af0a57899021"), null, new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4337), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4358), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("17d57920-3917-4935-8451-7eff52689cfe"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("199df182-8751-4cf5-9518-cc02f2882c01"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("19b70078-d775-474f-b55e-13dff1fb5cbe"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2f42db38-82b7-4a42-9a57-8d48b297b496"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("424bf998-cc48-410b-aec4-eae55bf680d8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("91093443-6cad-4ec0-bf65-2056dddc246b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("a124cbbe-1b8f-4e4e-90cc-2dcd6b812b78"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("c7211a33-c196-49e7-bb6b-af0a57899021"));

            migrationBuilder.DropColumn(
                name: "LastPasswordChangeDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoginMemberNo",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1cad8626-fec6-4088-8dfb-b69b2051cb3a"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2080), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2080), false, "Admin", "Admin" },
                    { new Guid("347bad39-afd8-4ecc-b24a-0e468facfc2f"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2082), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2083), false, "Enrollee", "Admin" },
                    { new Guid("55aa5cec-38ea-427d-aa30-159ba7f19dbf"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2084), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2085), false, "Client", "Admin" },
                    { new Guid("df0f7184-2e70-44c2-a3ff-ab031721131d"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2086), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2087), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("8a516de1-9d7b-4d1a-846c-3024ce73f5dc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("ce8a65d8-9d76-4e1e-8f25-076eb82ec8eb"), "SENDGRID_KEY", "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" },
                    { new Guid("fc15f91c-6d3c-4221-bca2-fb91163fa9f3"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("542ee22e-9ac2-4244-8ffb-73f530fa4fe2"), null, new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(1879), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(1895), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
