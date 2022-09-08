using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Toba_Simoen_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("17d57920-3917-4935-8451-7eff52689cfe"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("199df182-8751-4cf5-9518-cc02f2882c01"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("19b70078-d775-474f-b55e-13dff1fb5cbe"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("2f42db38-82b7-4a42-9a57-8d48b297b496"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("424bf998-cc48-410b-aec4-eae55bf680d8"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("91093443-6cad-4ec0-bf65-2056dddc246b"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("a124cbbe-1b8f-4e4e-90cc-2dcd6b812b78"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("c7211a33-c196-49e7-bb6b-af0a57899021"));

            migrationBuilder.RenameColumn(
                name: "PlanID",
                table: "Claims",
                newName: "PlanName");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EncounteredDate",
                table: "RequestRefunds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HospitalLocation",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalName",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDoc",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalReportDoc",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PACode",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptsDoc",
                table: "RequestRefunds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Enrollee",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Enrollee",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CloseReason",
                table: "Claims",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("205983a4-cb21-4cfa-bef0-e1f5deaea60f"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2374), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2374), false, "Provider", "Admin" },
            //        { new Guid("726c9371-1ae5-4e19-93f1-25ebd3a47612"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2371), false, "Enrollee", "Admin" },
            //        { new Guid("e2c4e75f-649d-41f7-8c09-edf32f3aea21"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2367), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2368), false, "Admin", "Admin" },
            //        { new Guid("fdd8e3c2-d423-4070-9d6e-45e71a87dee6"), "Admin", new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2372), new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2373), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("13b4ca28-20a7-4e40-b294-c88b3e080a9a"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("e230952d-7a04-482e-8895-685fec15142c"), "SENDGRID_KEY", "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" },
            //        { new Guid("fcea6800-fe01-49b2-9cba-3f67601cbc92"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("adaafc26-4af9-4ccc-9f4f-538d0086ee7c"), null, new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2126), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 16, 8, 43, 3, 638, DateTimeKind.Local).AddTicks(2143), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("205983a4-cb21-4cfa-bef0-e1f5deaea60f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("726c9371-1ae5-4e19-93f1-25ebd3a47612"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e2c4e75f-649d-41f7-8c09-edf32f3aea21"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fdd8e3c2-d423-4070-9d6e-45e71a87dee6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("13b4ca28-20a7-4e40-b294-c88b3e080a9a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("e230952d-7a04-482e-8895-685fec15142c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("fcea6800-fe01-49b2-9cba-3f67601cbc92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("adaafc26-4af9-4ccc-9f4f-538d0086ee7c"));

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "EncounteredDate",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "HospitalLocation",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "HospitalName",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "InvoiceDoc",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "MedicalReportDoc",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "PACode",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "ReceiptsDoc",
                table: "RequestRefunds");

            migrationBuilder.RenameColumn(
                name: "PlanName",
                table: "Claims",
                newName: "PlanID");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Enrollee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CloseReason",
                table: "Claims",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("17d57920-3917-4935-8451-7eff52689cfe"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4729), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4730), false, "Provider", "Admin" },
                    { new Guid("199df182-8751-4cf5-9518-cc02f2882c01"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4520), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4520), false, "Enrollee", "Admin" },
                    { new Guid("19b70078-d775-474f-b55e-13dff1fb5cbe"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4517), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4517), false, "Admin", "Admin" },
                    { new Guid("2f42db38-82b7-4a42-9a57-8d48b297b496"), "Admin", new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4727), new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4728), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("424bf998-cc48-410b-aec4-eae55bf680d8"), "SENDGRID_KEY", "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" },
                    { new Guid("91093443-6cad-4ec0-bf65-2056dddc246b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("a124cbbe-1b8f-4e4e-90cc-2dcd6b812b78"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c7211a33-c196-49e7-bb6b-af0a57899021"), null, new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4337), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 13, 11, 34, 26, 598, DateTimeKind.Local).AddTicks(4358), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
