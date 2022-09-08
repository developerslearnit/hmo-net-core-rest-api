using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Updated_RefNumCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4777626f-019e-463e-b381-2018a8cc6b11"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("60e5d814-64c8-4434-8adb-8d3c2ecc5064"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7dd50bb9-7c6d-48ff-ac4d-26e8608253da"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d378131d-87a8-4a34-a249-354c9d0ae5ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("742be0ce-2e19-4cd3-b330-24d736e421b8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("aa03601b-7c37-4d1f-a6ba-b66d7436caf5"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("b685780c-b212-43cd-87ef-958f2645d7f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("231fb3d5-4b11-4e82-9020-8d3f644bbe8d"));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2406e346-990a-4f1d-9a70-3cd3e553ea2f"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8141), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8141), false, "Admin", "Admin" },
                    { new Guid("434e3140-aa71-49cb-a1a8-d5d9bf879be1"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8145), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8145), false, "Enrollee", "Admin" },
                    { new Guid("737089d6-ecce-4f4e-a017-e2a1073164fa"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8147), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8148), false, "Client", "Admin" },
                    { new Guid("7e39df58-c1c6-467e-bd36-8ac80a60b8ad"), "Admin", new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8149), new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(8150), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("37110d62-db97-488f-97b5-dec3db5bf27b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("39233f21-c686-4cc2-83b7-7af75af6c59b"), "SENDGRID_KEY", "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" },
                    { new Guid("d83f8327-bd43-4346-b891-8d23a26efde2"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("ce72a745-89a8-4268-bf4c-ba8e80faeac4"), null, new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(7981), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 18, 12, 32, 396, DateTimeKind.Local).AddTicks(7994), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2406e346-990a-4f1d-9a70-3cd3e553ea2f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("434e3140-aa71-49cb-a1a8-d5d9bf879be1"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("737089d6-ecce-4f4e-a017-e2a1073164fa"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7e39df58-c1c6-467e-bd36-8ac80a60b8ad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("37110d62-db97-488f-97b5-dec3db5bf27b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("39233f21-c686-4cc2-83b7-7af75af6c59b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("d83f8327-bd43-4346-b891-8d23a26efde2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("ce72a745-89a8-4268-bf4c-ba8e80faeac4"));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReference",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4777626f-019e-463e-b381-2018a8cc6b11"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6294), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6294), false, "Admin", "Admin" },
                    { new Guid("60e5d814-64c8-4434-8adb-8d3c2ecc5064"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6297), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6297), false, "Enrollee", "Admin" },
                    { new Guid("7dd50bb9-7c6d-48ff-ac4d-26e8608253da"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6302), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6302), false, "Provider", "Admin" },
                    { new Guid("d378131d-87a8-4a34-a249-354c9d0ae5ad"), "Admin", new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6299), new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6300), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("742be0ce-2e19-4cd3-b330-24d736e421b8"), "SENDGRID_KEY", "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" },
                    { new Guid("aa03601b-7c37-4d1f-a6ba-b66d7436caf5"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("b685780c-b212-43cd-87ef-958f2645d7f5"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("231fb3d5-4b11-4e82-9020-8d3f644bbe8d"), null, new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6080), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 13, 16, 0, 32, 547, DateTimeKind.Local).AddTicks(6095), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
