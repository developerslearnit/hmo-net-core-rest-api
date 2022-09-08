using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class CartImpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("3829f706-8cab-4dd4-a48e-c0c7c3d74889"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("529c1d28-3b68-4293-a0b1-03a15497e027"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("aef159ee-cf0e-4697-83c9-ace7e5d3e8db"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("da3ec04d-9e86-425d-8f44-2c57a766ba6f"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("003b0f7c-c043-47bc-a3e2-5dc2c4101c1a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1311bafc-833c-40cb-85ee-17cf2cdc698c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f97fe7a9-0d8c-43ab-9c4f-4fc02377bf6f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("05d6c516-3125-499e-a14c-e7d8f36a44d8"));

            migrationBuilder.AddColumn<int>(
                name: "IsSponsored",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sponsoredEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertificateUrl",
                table: "Enrollee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BulkPaymentLogId",
                table: "Enrollee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "nhis",
                table: "Enrollee",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sponsoredEmail",
                table: "Enrollee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BulkPaymentLog",
                columns: table => new
                {
                    BulkPaymentLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NoOfPlans = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkPaymentLog", x => x.BulkPaymentLogId);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UniqueReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6cb3a6a9-937e-41bc-a763-b51f1614d850"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3215), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3215), false, "Client", "Admin" },
                    { new Guid("832c7fb0-302b-4634-98c6-8548d8aea2d5"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3217), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3217), false, "Provider", "Admin" },
                    { new Guid("931348b5-e784-4c21-b871-226699022bbd"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3203), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3203), false, "Enrollee", "Admin" },
                    { new Guid("aee6e917-31d9-4ffc-9227-1d1a431553eb"), "Admin", new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3200), new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3200), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("87c298c8-ce19-44ef-9f79-fa041d203658"), "SENDGRID_KEY", "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" },
                    { new Guid("96e8c161-0c26-45cc-ae56-6cafbf69ec7b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ad3ab5e0-3bf7-4e43-8ead-a49bae82bb8b"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a5413fff-237b-42aa-b739-1d9bb178c8a3"), null, new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3047), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 22, 11, 21, 5, 665, DateTimeKind.Local).AddTicks(3063), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BulkPaymentLog");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("6cb3a6a9-937e-41bc-a763-b51f1614d850"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("832c7fb0-302b-4634-98c6-8548d8aea2d5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("931348b5-e784-4c21-b871-226699022bbd"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("aee6e917-31d9-4ffc-9227-1d1a431553eb"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("87c298c8-ce19-44ef-9f79-fa041d203658"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("96e8c161-0c26-45cc-ae56-6cafbf69ec7b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ad3ab5e0-3bf7-4e43-8ead-a49bae82bb8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("a5413fff-237b-42aa-b739-1d9bb178c8a3"));

            migrationBuilder.DropColumn(
                name: "IsSponsored",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "sponsoredEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BirthCertificateUrl",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "BulkPaymentLogId",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "nhis",
                table: "Enrollee");

            migrationBuilder.DropColumn(
                name: "sponsoredEmail",
                table: "Enrollee");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3829f706-8cab-4dd4-a48e-c0c7c3d74889"), "Admin", new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8341), new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8341), false, "Admin", "Admin" },
                    { new Guid("529c1d28-3b68-4293-a0b1-03a15497e027"), "Admin", new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8343), new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8344), false, "Enrollee", "Admin" },
                    { new Guid("aef159ee-cf0e-4697-83c9-ace7e5d3e8db"), "Admin", new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8347), new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8347), false, "Provider", "Admin" },
                    { new Guid("da3ec04d-9e86-425d-8f44-2c57a766ba6f"), "Admin", new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8345), new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8346), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("003b0f7c-c043-47bc-a3e2-5dc2c4101c1a"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("1311bafc-833c-40cb-85ee-17cf2cdc698c"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f97fe7a9-0d8c-43ab-9c4f-4fc02377bf6f"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("05d6c516-3125-499e-a14c-e7d8f36a44d8"), null, new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8195), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 22, 10, 29, 9, 865, DateTimeKind.Local).AddTicks(8210), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
