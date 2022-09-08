using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("54de3c2f-9cf3-4a93-8363-c037983fcb7e"), "Admin", new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7518), new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7518), false, "Enrollee", "Admin" },
                    { new Guid("d78b3066-5e1e-42fe-b939-8ae99f254dd1"), "Admin", new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7521), new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7522), false, "Provider", "Admin" },
                    { new Guid("efb74861-270f-4f70-b629-0570fe04109d"), "Admin", new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7520), new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7520), false, "Client", "Admin" },
                    { new Guid("fafb15a0-4dee-420f-9c66-8b9c5d9dbc12"), "Admin", new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7515), new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7515), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("3b7a7acb-3a21-496c-accb-59b008d8315c"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("4cc99823-5343-4cd6-9f8c-64a329d61605"), "SENDGRID_KEY", "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" },
                    { new Guid("c32e196b-edb4-4746-9c71-8e78d016c224"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("e42a27c7-2162-43e4-b387-0f717e534af7"), null, new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7343), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 11, 14, 26, 876, DateTimeKind.Local).AddTicks(7360), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("54de3c2f-9cf3-4a93-8363-c037983fcb7e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d78b3066-5e1e-42fe-b939-8ae99f254dd1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("efb74861-270f-4f70-b629-0570fe04109d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("fafb15a0-4dee-420f-9c66-8b9c5d9dbc12"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("3b7a7acb-3a21-496c-accb-59b008d8315c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("4cc99823-5343-4cd6-9f8c-64a329d61605"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("c32e196b-edb4-4746-9c71-8e78d016c224"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("e42a27c7-2162-43e4-b387-0f717e534af7"));

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
    }
}
