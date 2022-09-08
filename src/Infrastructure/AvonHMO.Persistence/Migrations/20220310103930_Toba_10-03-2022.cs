using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Toba_10032022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("2e8e9206-93d5-44fa-aba2-98f5074bc6bb"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("5d86b751-8c9e-435d-94d1-132ba073f789"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("8839d8b0-ae14-4d67-86d3-9fee63bdc769"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("d1674888-5f2c-4529-8cfa-d89be206ac94"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("4ef16fe2-8691-44d8-8b04-6a4340daffdb"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("d300a8fd-655a-4f8c-9132-0dac686a4c53"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("f1eaaf2f-1e04-43f2-84c4-565ecfa3ad46"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("7cb556cb-46b2-49f7-82fc-0d784bc22b90"));

            migrationBuilder.AddColumn<string>(
                name: "PaymentRef",
                table: "Enrollee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NHIS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1e692ecc-e441-4bca-a00a-49c2c78bd920"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9792), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9793), false, "Enrollee", "Admin" },
            //        { new Guid("6c10f122-15ec-4640-bfe3-4fb35424c103"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9795), false, "Client", "Admin" },
            //        { new Guid("d63e516e-0870-42d0-87c5-574141e3a993"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9789), false, "Admin", "Admin" },
            //        { new Guid("fc69a6b5-5e1e-49d8-a85a-23e35b182c92"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9796), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9797), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("5b1f9835-c7e1-4958-9ea1-25ebd106b10f"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("64322801-fea4-4bc4-ac4a-ff98f1440578"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("ef1a831f-3bc0-4c8c-8dfc-b1ba6999b0b7"), "SENDGRID_KEY", "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" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("b1c1efc6-d601-43ae-8424-2e7e3beba06e"), null, new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9586), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9603), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentReference",
                table: "Payments",
                column: "PaymentReference",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Payments");

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("1e692ecc-e441-4bca-a00a-49c2c78bd920"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("6c10f122-15ec-4640-bfe3-4fb35424c103"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("d63e516e-0870-42d0-87c5-574141e3a993"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("fc69a6b5-5e1e-49d8-a85a-23e35b182c92"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("5b1f9835-c7e1-4958-9ea1-25ebd106b10f"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("64322801-fea4-4bc4-ac4a-ff98f1440578"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("ef1a831f-3bc0-4c8c-8dfc-b1ba6999b0b7"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("b1c1efc6-d601-43ae-8424-2e7e3beba06e"));

            migrationBuilder.DropColumn(
                name: "PaymentRef",
                table: "Enrollee");

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("2e8e9206-93d5-44fa-aba2-98f5074bc6bb"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6242), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6243), false, "Enrollee", "Admin" },
            //        { new Guid("5d86b751-8c9e-435d-94d1-132ba073f789"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6239), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6240), false, "Admin", "Admin" },
            //        { new Guid("8839d8b0-ae14-4d67-86d3-9fee63bdc769"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6244), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6245), false, "Client", "Admin" },
            //        { new Guid("d1674888-5f2c-4529-8cfa-d89be206ac94"), "Admin", new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6246), new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6247), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("4ef16fe2-8691-44d8-8b04-6a4340daffdb"), "SENDGRID_KEY", "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" },
            //        { new Guid("d300a8fd-655a-4f8c-9132-0dac686a4c53"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("f1eaaf2f-1e04-43f2-84c4-565ecfa3ad46"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("7cb556cb-46b2-49f7-82fc-0d784bc22b90"), null, new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6104), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 8, 7, 13, 58, 483, DateTimeKind.Local).AddTicks(6123), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
