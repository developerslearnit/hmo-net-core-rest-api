using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedrefundTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("0f38eb4b-bf12-42f5-9d6d-6813e5d66e26"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("83fa1fc9-1411-43ab-aa34-cf2f0346f3c4"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("ac960b54-8888-4e72-8e2c-9b27f512a777"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("d046a357-7463-42f1-a9e8-3c8c127bb2ee"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("304d4f9f-4094-43f6-807a-319bcffc2465"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("afb4f2e2-bd3e-40fa-9a6f-7a93f24eec2d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("de0c2d37-b106-42c9-9aa6-f7197974ab02"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("410baa55-7cf3-44ce-a4e2-25770d93d285"));

            migrationBuilder.CreateTable(
                name: "EnrolleeRecommendations",
                columns: table => new
                {
                    EnrolleeRecommendationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BeneficairyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeRecommendations", x => x.EnrolleeRecommendationId);
                });

            migrationBuilder.CreateTable(
                name: "RequestRefunds",
                columns: table => new
                {
                    RequestRefundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToshfaAvonRef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestRefunds", x => x.RequestRefundId);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("04f9d41b-fed7-4ca8-bea1-11916668ff47"), "Admin", new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8937), new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8937), false, "Provider", "Admin" },
                    { new Guid("516153d1-9cce-4e72-8e2c-ce11ef70dcb5"), "Admin", new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8932), new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8932), false, "Enrollee", "Admin" },
                    { new Guid("7a1c36c7-abe7-4fab-8c9f-875dd5d82fbf"), "Admin", new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8928), new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8929), false, "Admin", "Admin" },
                    { new Guid("911b6087-f743-4151-b8e9-e9cdc4ed8fad"), "Admin", new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8935), new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8935), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1df34cb3-5e1a-4a49-999e-0b2a322d2a4a"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("887584a4-01cb-4250-b464-39f8457ed8c6"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("e5c0e2db-12fa-455d-a619-a0d2247b412a"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c5bd3e90-52c3-4ec6-9fa8-81301d40d0e0"), null, new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8734), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 17, 13, 20, 57, 191, DateTimeKind.Local).AddTicks(8745), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolleeRecommendations");

            migrationBuilder.DropTable(
                name: "RequestRefunds");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("04f9d41b-fed7-4ca8-bea1-11916668ff47"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("516153d1-9cce-4e72-8e2c-ce11ef70dcb5"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("7a1c36c7-abe7-4fab-8c9f-875dd5d82fbf"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("911b6087-f743-4151-b8e9-e9cdc4ed8fad"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("1df34cb3-5e1a-4a49-999e-0b2a322d2a4a"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("887584a4-01cb-4250-b464-39f8457ed8c6"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("e5c0e2db-12fa-455d-a619-a0d2247b412a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("c5bd3e90-52c3-4ec6-9fa8-81301d40d0e0"));

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0f38eb4b-bf12-42f5-9d6d-6813e5d66e26"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2416), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2417), false, "Provider", "Admin" },
                    { new Guid("83fa1fc9-1411-43ab-aa34-cf2f0346f3c4"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2411), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2411), false, "Enrollee", "Admin" },
                    { new Guid("ac960b54-8888-4e72-8e2c-9b27f512a777"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2393), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2393), false, "Admin", "Admin" },
                    { new Guid("d046a357-7463-42f1-a9e8-3c8c127bb2ee"), "Admin", new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2414), new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2414), false, "Client", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("304d4f9f-4094-43f6-807a-319bcffc2465"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("afb4f2e2-bd3e-40fa-9a6f-7a93f24eec2d"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("de0c2d37-b106-42c9-9aa6-f7197974ab02"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("410baa55-7cf3-44ce-a4e2-25770d93d285"), null, new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2126), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 17, 5, 12, 54, 547, DateTimeKind.Local).AddTicks(2141), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
