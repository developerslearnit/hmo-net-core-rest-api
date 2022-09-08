using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class added_faq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("491300b0-5586-4aa5-81af-600ebd726ff5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4aed7226-4697-466e-83f8-b85a3c02452b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ceadac15-9fc3-4a0c-918e-3ac0d23a5677"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("f7795c38-afab-43d4-b0c2-909f9a3c9ab8"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("5349450b-bb53-4f9d-959f-c72edf0e10e6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("534f313a-6de9-40cc-9139-49dabdea4217"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f2d3401d-6346-4e5e-9f17-a9fd50e62af7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("da054d90-696d-4775-bd01-23ff0f82394b"));

            migrationBuilder.CreateTable(
                name: "FAQCategorys",
                columns: table => new
                {
                    FAQCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCategorys", x => x.FAQCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    FAQId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FAQCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.FAQId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQCategorys");

            migrationBuilder.DropTable(
                name: "FAQs");

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

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("491300b0-5586-4aa5-81af-600ebd726ff5"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6022), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6022), false, "Provider", "Admin" },
                    { new Guid("4aed7226-4697-466e-83f8-b85a3c02452b"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6020), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6020), false, "Client", "Admin" },
                    { new Guid("ceadac15-9fc3-4a0c-918e-3ac0d23a5677"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6005), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6005), false, "Enrollee", "Admin" },
                    { new Guid("f7795c38-afab-43d4-b0c2-909f9a3c9ab8"), "Admin", new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6002), new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(6003), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("5349450b-bb53-4f9d-959f-c72edf0e10e6"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("534f313a-6de9-40cc-9139-49dabdea4217"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f2d3401d-6346-4e5e-9f17-a9fd50e62af7"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("da054d90-696d-4775-bd01-23ff0f82394b"), null, new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(5795), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 2, 22, 9, 20, 56, 737, DateTimeKind.Local).AddTicks(5811), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
