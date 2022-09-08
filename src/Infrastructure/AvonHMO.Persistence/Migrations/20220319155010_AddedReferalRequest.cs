using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedReferalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("1f13a824-bbbe-4832-9d55-fdc6db60b9c2"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8530938b-f1d7-49fe-87a9-c3ca3f3c00e0"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("b87a490e-d7ae-4e2e-8115-1b8a2728fe70"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("f392faaf-c75b-4064-9518-dd9ca2861143"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("5eb6b797-d1d0-40c0-80fa-b5949f777dc9"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("91bac9cc-aef0-42a9-a1c9-5be9ea0ac053"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("b4c370fb-f961-4c30-b9c7-15da29b25fb7"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("5ad99ed6-c841-4924-8b23-54477882d033"));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "RequestAuthorizations",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReferralRequests",
                columns: table => new
                {
                    ReferralRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrolleeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferralTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalSummary = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    MedicalDocPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemberNo = table.Column<int>(type: "int", maxLength: 15, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralRequests", x => x.ReferralRequestId);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1ee23e8d-1a1d-45dc-8ed0-77ed1cdeea59"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2901), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2901), false, "Enrollee", "Admin" },
            //        { new Guid("8ccab78c-9aa9-419d-ae6c-3b02c72c24fe"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2898), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2898), false, "Admin", "Admin" },
            //        { new Guid("8fcd61d2-6d40-4373-8d30-605081dd2137"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2904), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2905), false, "Provider", "Admin" },
            //        { new Guid("c366ac30-86c0-4d01-991d-da2bddb0d10f"), "Admin", new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2903), new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2903), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("067e32a7-f30d-4c40-a798-63285480bc9d"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("8aba0210-1a5b-4d20-ad60-fed825c42087"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("dbbf4dc7-e72f-49f0-9517-c0b612163b46"), "SENDGRID_KEY", "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" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("fa40c922-3c7d-459d-b0ba-f5c230d85d34"), null, new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2709), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 19, 16, 50, 8, 488, DateTimeKind.Local).AddTicks(2725), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferralRequests");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1ee23e8d-1a1d-45dc-8ed0-77ed1cdeea59"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8ccab78c-9aa9-419d-ae6c-3b02c72c24fe"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8fcd61d2-6d40-4373-8d30-605081dd2137"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("c366ac30-86c0-4d01-991d-da2bddb0d10f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("067e32a7-f30d-4c40-a798-63285480bc9d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8aba0210-1a5b-4d20-ad60-fed825c42087"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("dbbf4dc7-e72f-49f0-9517-c0b612163b46"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("fa40c922-3c7d-459d-b0ba-f5c230d85d34"));

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "RequestAuthorizations");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1f13a824-bbbe-4832-9d55-fdc6db60b9c2"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5627), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5628), false, "Enrollee", "Admin" },
                    { new Guid("8530938b-f1d7-49fe-87a9-c3ca3f3c00e0"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5625), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5625), false, "Admin", "Admin" },
                    { new Guid("b87a490e-d7ae-4e2e-8115-1b8a2728fe70"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5643), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5644), false, "Provider", "Admin" },
                    { new Guid("f392faaf-c75b-4064-9518-dd9ca2861143"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5642), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("5eb6b797-d1d0-40c0-80fa-b5949f777dc9"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("91bac9cc-aef0-42a9-a1c9-5be9ea0ac053"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("b4c370fb-f961-4c30-b9c7-15da29b25fb7"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("5ad99ed6-c841-4924-8b23-54477882d033"), null, new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5459), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5475), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
