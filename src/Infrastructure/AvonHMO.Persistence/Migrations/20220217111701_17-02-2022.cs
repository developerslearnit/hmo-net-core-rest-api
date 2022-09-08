using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class _17022022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "PartnerProviders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderRef",
                table: "Enrollee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProviderContacts",
                columns: table => new
                {
                    ProviderContactID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactDesignation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContacts", x => x.ProviderContactID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Code = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    LGA = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    State = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MDName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MDPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MDEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MDDirectLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phoneno = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HMOOfficerName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HMODeskPhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HMOOfficerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProviderServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProviderOperationHour = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    ProviderOperationDay = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    DoctorCoverageHour = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Bankname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderID);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3eac7b57-3cc9-4198-b0cd-cf2ffcfcfb27"), "Admin", new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9078), new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9079), false, "Provider", "Admin" },
                    { new Guid("7b186b9e-841a-474c-a9a9-00faf7236386"), "Admin", new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9077), new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9077), false, "Client", "Admin" },
                    { new Guid("dd6a5d56-160a-4836-99fd-6aaeff4fa24e"), "Admin", new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9075), new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9075), false, "Enrollee", "Admin" },
                    { new Guid("fb629031-480c-4e10-ab68-30c1693c33a9"), "Admin", new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9072), new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(9072), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("297f9e67-cf66-42d7-97c1-1eebe190322b"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("499b9aac-d4aa-4353-99c1-b0bfbc304e07"), "SENDGRID_KEY", "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" },
                    { new Guid("86df62d5-085a-4e00-8f29-069d3d3709e8"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a132f122-931e-453b-a328-cd186abaec4d"), null, new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(8774), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 17, 12, 17, 0, 433, DateTimeKind.Local).AddTicks(8800), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderContacts");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3eac7b57-3cc9-4198-b0cd-cf2ffcfcfb27"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7b186b9e-841a-474c-a9a9-00faf7236386"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dd6a5d56-160a-4836-99fd-6aaeff4fa24e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fb629031-480c-4e10-ab68-30c1693c33a9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("297f9e67-cf66-42d7-97c1-1eebe190322b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("499b9aac-d4aa-4353-99c1-b0bfbc304e07"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("86df62d5-085a-4e00-8f29-069d3d3709e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("a132f122-931e-453b-a328-cd186abaec4d"));

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "PartnerProviders");

            migrationBuilder.DropColumn(
                name: "OrderRef",
                table: "Enrollee");

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
    }
}
