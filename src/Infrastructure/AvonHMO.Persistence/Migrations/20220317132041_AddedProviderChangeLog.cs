using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedProviderChangeLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("24e99a62-86f8-48ad-8b95-0e9b0f26169f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("383f9f95-c0b1-47a8-a7db-92ea3322ea2a"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("7d8be949-8076-4dce-b7fb-9a0eff82986f"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("cc09bcbd-0afc-4030-954b-ad8ec6200435"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("0c66d504-7f9f-46a3-8fbb-45b85e66f9f3"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("bc137cff-e873-45b5-a2f1-5b62b795be87"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("e4134b10-8022-4a4e-a927-f8f81145fa7d"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("2f8c1c85-54b9-4ac9-9e7f-85377fa55345"));

            migrationBuilder.CreateTable(
                name: "ProviderChangeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPossibleChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderChangeLogs", x => x.Id);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("0afe783c-12ae-431b-b0e3-1e1ad04aa9a6"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4715), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4715), false, "Admin", "Admin" },
            //        { new Guid("0cd4c5da-0421-4286-b0fe-4896936754c5"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4721), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4722), false, "Provider", "Admin" },
            //        { new Guid("6da5fd75-97ac-4eaa-8ba1-10695d1afef3"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4718), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4718), false, "Enrollee", "Admin" },
            //        { new Guid("e294dd4e-5cb1-46a7-a25d-8546491916e9"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4720), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4720), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("027788f7-a68a-4ce5-ac4f-63b70c87a5c5"), "SENDGRID_KEY", "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" },
            //        { new Guid("92b988a2-889b-4227-afc9-2482d24ade7b"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("c5f2211f-b97a-4e95-9292-3ff4de36c155"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("be8a91c4-e785-4c98-ada9-97330d3fadc3"), null, new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4516), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4532), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderChangeLogs");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0afe783c-12ae-431b-b0e3-1e1ad04aa9a6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0cd4c5da-0421-4286-b0fe-4896936754c5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6da5fd75-97ac-4eaa-8ba1-10695d1afef3"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("e294dd4e-5cb1-46a7-a25d-8546491916e9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("027788f7-a68a-4ce5-ac4f-63b70c87a5c5"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("92b988a2-889b-4227-afc9-2482d24ade7b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c5f2211f-b97a-4e95-9292-3ff4de36c155"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("be8a91c4-e785-4c98-ada9-97330d3fadc3"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("24e99a62-86f8-48ad-8b95-0e9b0f26169f"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9931), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9931), false, "Enrollee", "Admin" },
                    { new Guid("383f9f95-c0b1-47a8-a7db-92ea3322ea2a"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9944), false, "Client", "Admin" },
                    { new Guid("7d8be949-8076-4dce-b7fb-9a0eff82986f"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9928), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9929), false, "Admin", "Admin" },
                    { new Guid("cc09bcbd-0afc-4030-954b-ad8ec6200435"), "Admin", new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9946), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("0c66d504-7f9f-46a3-8fbb-45b85e66f9f3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("bc137cff-e873-45b5-a2f1-5b62b795be87"), "SENDGRID_KEY", "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" },
                    { new Guid("e4134b10-8022-4a4e-a927-f8f81145fa7d"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("2f8c1c85-54b9-4ac9-9e7f-85377fa55345"), null, new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9759), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 11, 26, 37, 521, DateTimeKind.Local).AddTicks(9775), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
