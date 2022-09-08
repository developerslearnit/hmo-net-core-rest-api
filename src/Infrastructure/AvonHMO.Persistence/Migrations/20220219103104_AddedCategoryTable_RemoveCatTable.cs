using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedCategoryTable_RemoveCatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("01652fd4-abb4-4048-805c-9bb9671b9950"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8053), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8053), false, "Provider", "Admin" },
                    { new Guid("8b6f1169-d2a8-45af-b486-d8ae1f06ddf6"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8046), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8047), false, "Admin", "Admin" },
                    { new Guid("9a2b7ded-8f4d-4784-984b-e5f6658696c2"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8051), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8051), false, "Client", "Admin" },
                    { new Guid("dca790ad-1ae2-478f-972a-97e7c6a3506d"), "Admin", new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8049), new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(8049), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("8e7efa68-2476-47fc-b0e7-5f624a48ef94"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b4b9a366-5cbb-4aaf-aae0-647fe13cf912"), "SENDGRID_KEY", "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" },
                    { new Guid("d6caaf46-19cf-498c-a43b-9d24bb64de09"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("63192e21-15bc-44c9-bd32-e2dcb6219079"), null, new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(7874), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 19, 11, 31, 4, 190, DateTimeKind.Local).AddTicks(7887), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("01652fd4-abb4-4048-805c-9bb9671b9950"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8b6f1169-d2a8-45af-b486-d8ae1f06ddf6"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9a2b7ded-8f4d-4784-984b-e5f6658696c2"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("dca790ad-1ae2-478f-972a-97e7c6a3506d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8e7efa68-2476-47fc-b0e7-5f624a48ef94"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b4b9a366-5cbb-4aaf-aae0-647fe13cf912"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d6caaf46-19cf-498c-a43b-9d24bb64de09"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("63192e21-15bc-44c9-bd32-e2dcb6219079"));

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
    }
}
