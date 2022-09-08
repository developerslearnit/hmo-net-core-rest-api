using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class NewProviderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("4d4db0ff-1488-435b-87ab-5d15a6980176"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("80e0e983-2101-4db8-a763-f7f09e690837"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("bd628966-8189-4fbd-9738-a144326414c4"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e5f6295a-2a30-47b8-aeaa-f0acd15fda73"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("1022b648-4bf1-4d1a-906b-1614fe275604"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("205ba000-4dc0-4e0f-a08f-e66670299a7c"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("3c41f531-cfc7-4e4b-99c0-c07f8d9c1d4a"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("edc01bc8-3e81-44f4-9fad-1e87f745ffa9"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "HMOOfficerEmail",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Providers");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationHour",
                table: "Providers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderOperationDay",
                table: "Providers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorCoverageHour",
                table: "Providers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "HMOOfficerGSM",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderCode",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("3e93b8a4-0b80-4a95-9595-14c30a7b0b3c"), "Admin", new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4814), new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4815), false, "Client", "Admin" },
            //        { new Guid("5718021d-6186-48ee-9ade-0a4bfeff8e41"), "Admin", new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4812), new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4812), false, "Enrollee", "Admin" },
            //        { new Guid("6f7a9c3c-d660-4cdb-88c6-637d3c65336b"), "Admin", new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4836), new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4836), false, "Provider", "Admin" },
            //        { new Guid("a1832e21-a74d-4320-b696-eadc2f2d99e1"), "Admin", new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4810), new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4810), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("0a29397a-6adc-4b6f-8510-bd553a93c87f"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("1ab54cae-312d-422a-a0cb-d34cc0a04bf5"), "SENDGRID_KEY", "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" },
            //        { new Guid("9a7753fb-60f3-43ca-987b-8e31f2fa2b8d"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("f8e89226-ed86-43a4-851a-9a585788bb9a"), null, new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4599), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 11, 13, 55, 5, 539, DateTimeKind.Local).AddTicks(4618), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3e93b8a4-0b80-4a95-9595-14c30a7b0b3c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("5718021d-6186-48ee-9ade-0a4bfeff8e41"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6f7a9c3c-d660-4cdb-88c6-637d3c65336b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a1832e21-a74d-4320-b696-eadc2f2d99e1"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("0a29397a-6adc-4b6f-8510-bd553a93c87f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1ab54cae-312d-422a-a0cb-d34cc0a04bf5"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9a7753fb-60f3-43ca-987b-8e31f2fa2b8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("f8e89226-ed86-43a4-851a-9a585788bb9a"));

            migrationBuilder.DropColumn(
                name: "HMOOfficerGSM",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderCode",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Providers");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderOperationHour",
                table: "Providers",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderOperationDay",
                table: "Providers",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorCoverageHour",
                table: "Providers",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Providers",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HMOOfficerEmail",
                table: "Providers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Providers",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Providers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Providers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4d4db0ff-1488-435b-87ab-5d15a6980176"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5710), false, "Provider", "Admin" },
                    { new Guid("80e0e983-2101-4db8-a763-f7f09e690837"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5707), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5707), false, "Client", "Admin" },
                    { new Guid("bd628966-8189-4fbd-9738-a144326414c4"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5705), false, "Enrollee", "Admin" },
                    { new Guid("e5f6295a-2a30-47b8-aeaa-f0acd15fda73"), "Admin", new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5702), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1022b648-4bf1-4d1a-906b-1614fe275604"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("205ba000-4dc0-4e0f-a08f-e66670299a7c"), "SENDGRID_KEY", "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" },
                    { new Guid("3c41f531-cfc7-4e4b-99c0-c07f8d9c1d4a"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("edc01bc8-3e81-44f4-9fad-1e87f745ffa9"), null, new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5532), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 7, 13, 19, 0, 241, DateTimeKind.Local).AddTicks(5551), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
