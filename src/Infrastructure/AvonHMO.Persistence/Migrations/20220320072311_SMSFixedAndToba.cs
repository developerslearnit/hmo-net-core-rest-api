using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SMSFixedAndToba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("1ee23e8d-1a1d-45dc-8ed0-77ed1cdeea59"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8ccab78c-9aa9-419d-ae6c-3b02c72c24fe"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8fcd61d2-6d40-4373-8d30-605081dd2137"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("c366ac30-86c0-4d01-991d-da2bddb0d10f"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("067e32a7-f30d-4c40-a798-63285480bc9d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("8aba0210-1a5b-4d20-ad60-fed825c42087"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("dbbf4dc7-e72f-49f0-9517-c0b612163b46"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("fa40c922-3c7d-459d-b0ba-f5c230d85d34"));

            migrationBuilder.CreateTable(
                name: "Temp_Enrollee",
                columns: table => new
                {
                    Temp_EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EnrolleeAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberNumber = table.Column<int>(type: "int", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrolleeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BirthCertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MailingLGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    ProviderLGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSponsored = table.Column<int>(type: "int", nullable: true),
                    sponsoredEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PlanRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    nhis = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OrderPaymentRefrence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_Enrollee", x => x.Temp_EnrolleeId);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("541069a3-31f6-4d2b-b252-97b12ebf9129"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6225), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6226), false, "Provider", "Admin" },
            //        { new Guid("d022944c-6b86-4dc2-b2ce-6c3d7fb031be"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6223), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6224), false, "Client", "Admin" },
            //        { new Guid("e0566ddb-c0e6-429b-8d9a-862b43391d60"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6221), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6221), false, "Enrollee", "Admin" },
            //        { new Guid("e8da87c1-4c8a-4467-88a8-64132140d3fb"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6217), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6217), false, "Admin", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("1f5c9c0f-aacb-41bf-8456-42175637ec5d"), "SENDGRID_KEY", "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" },
            //        { new Guid("6bcf9e88-328e-4505-9e80-019a940ddbd0"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("f75cb936-6e8b-426d-9cc1-c20d6d1877ae"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("204ac40d-ef82-4c87-976a-b864cec56503"), null, new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(5916), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(5932), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temp_Enrollee");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("541069a3-31f6-4d2b-b252-97b12ebf9129"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d022944c-6b86-4dc2-b2ce-6c3d7fb031be"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e0566ddb-c0e6-429b-8d9a-862b43391d60"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e8da87c1-4c8a-4467-88a8-64132140d3fb"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1f5c9c0f-aacb-41bf-8456-42175637ec5d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6bcf9e88-328e-4505-9e80-019a940ddbd0"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f75cb936-6e8b-426d-9cc1-c20d6d1877ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("204ac40d-ef82-4c87-976a-b864cec56503"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1ee23e8d-1a1d-45dc-8ed0-77ed1cdeea59"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2901), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2901), false, "Enrollee", "Admin" },
                    { new Guid("8ccab78c-9aa9-419d-ae6c-3b02c72c24fe"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2898), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2898), false, "Admin", "Admin" },
                    { new Guid("8fcd61d2-6d40-4373-8d30-605081dd2137"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2904), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2905), false, "Provider", "Admin" },
                    { new Guid("c366ac30-86c0-4d01-991d-da2bddb0d10f"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2903), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2903), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("067e32a7-f30d-4c40-a798-63285480bc9d"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("8aba0210-1a5b-4d20-ad60-fed825c42087"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("dbbf4dc7-e72f-49f0-9517-c0b612163b46"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("fa40c922-3c7d-459d-b0ba-f5c230d85d34"), null, new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2709), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2725), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
