using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedPlaClassToPlanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("0afe783c-12ae-431b-b0e3-1e1ad04aa9a6"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("0cd4c5da-0421-4286-b0fe-4896936754c5"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("6da5fd75-97ac-4eaa-8ba1-10695d1afef3"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e294dd4e-5cb1-46a7-a25d-8546491916e9"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("027788f7-a68a-4ce5-ac4f-63b70c87a5c5"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("92b988a2-889b-4227-afc9-2482d24ade7b"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("c5f2211f-b97a-4e95-9292-3ff4de36c155"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("be8a91c4-e785-4c98-ada9-97330d3fadc3"));

            migrationBuilder.AddColumn<string>(
                name: "PlanClass",
                table: "Plans",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1f13a824-bbbe-4832-9d55-fdc6db60b9c2"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5627), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5628), false, "Enrollee", "Admin" },
            //        { new Guid("8530938b-f1d7-49fe-87a9-c3ca3f3c00e0"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5625), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5625), false, "Admin", "Admin" },
            //        { new Guid("b87a490e-d7ae-4e2e-8115-1b8a2728fe70"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5643), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5644), false, "Provider", "Admin" },
            //        { new Guid("f392faaf-c75b-4064-9518-dd9ca2861143"), "Admin", new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5642), false, "Client", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("5eb6b797-d1d0-40c0-80fa-b5949f777dc9"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("91bac9cc-aef0-42a9-a1c9-5be9ea0ac053"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("b4c370fb-f961-4c30-b9c7-15da29b25fb7"), "SENDGRID_KEY", "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" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("5ad99ed6-c841-4924-8b23-54477882d033"), null, new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5459), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 19, 10, 30, 38, 140, DateTimeKind.Local).AddTicks(5475), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1f13a824-bbbe-4832-9d55-fdc6db60b9c2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8530938b-f1d7-49fe-87a9-c3ca3f3c00e0"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("b87a490e-d7ae-4e2e-8115-1b8a2728fe70"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f392faaf-c75b-4064-9518-dd9ca2861143"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("5eb6b797-d1d0-40c0-80fa-b5949f777dc9"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("91bac9cc-aef0-42a9-a1c9-5be9ea0ac053"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b4c370fb-f961-4c30-b9c7-15da29b25fb7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("5ad99ed6-c841-4924-8b23-54477882d033"));

            migrationBuilder.DropColumn(
                name: "PlanClass",
                table: "Plans");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0afe783c-12ae-431b-b0e3-1e1ad04aa9a6"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4715), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4715), false, "Admin", "Admin" },
                    { new Guid("0cd4c5da-0421-4286-b0fe-4896936754c5"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4721), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4722), false, "Provider", "Admin" },
                    { new Guid("6da5fd75-97ac-4eaa-8ba1-10695d1afef3"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4718), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4718), false, "Enrollee", "Admin" },
                    { new Guid("e294dd4e-5cb1-46a7-a25d-8546491916e9"), "Admin", new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4720), new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4720), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("027788f7-a68a-4ce5-ac4f-63b70c87a5c5"), "SENDGRID_KEY", "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" },
                    { new Guid("92b988a2-889b-4227-afc9-2482d24ade7b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("c5f2211f-b97a-4e95-9292-3ff4de36c155"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("be8a91c4-e785-4c98-ada9-97330d3fadc3"), null, new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4516), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 17, 14, 20, 39, 847, DateTimeKind.Local).AddTicks(4532), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
