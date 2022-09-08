using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class AddedProviderPlanMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_AuditLogs",
            //    table: "AuditLogs");

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

            //migrationBuilder.RenameTable(
            //    name: "AuditLogs",
            //    newName: "Audit");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Audit",
            //    table: "Audit",
            //    column: "Id");

            migrationBuilder.CreateTable(
                name: "ProviderPlanMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProviderClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderPlanMap", x => x.Id);
                });

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("1cad8626-fec6-4088-8dfb-b69b2051cb3a"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2080), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2080), false, "Admin", "Admin" },
            //        { new Guid("347bad39-afd8-4ecc-b24a-0e468facfc2f"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2082), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2083), false, "Enrollee", "Admin" },
            //        { new Guid("55aa5cec-38ea-427d-aa30-159ba7f19dbf"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2084), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2085), false, "Client", "Admin" },
            //        { new Guid("df0f7184-2e70-44c2-a3ff-ab031721131d"), "Admin", new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2086), new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(2087), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("8a516de1-9d7b-4d1a-846c-3024ce73f5dc"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("ce8a65d8-9d76-4e1e-8f25-076eb82ec8eb"), "SENDGRID_KEY", "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" },
            //        { new Guid("fc15f91c-6d3c-4221-bca2-fb91163fa9f3"), "FROM_DISPLAY_NAME", "Avon HMO" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("542ee22e-9ac2-4244-8ffb-73f530fa4fe2"), null, new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(1879), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 11, 12, 43, 26, 571, DateTimeKind.Local).AddTicks(1895), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderPlanMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audit",
                table: "Audit");

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1cad8626-fec6-4088-8dfb-b69b2051cb3a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("347bad39-afd8-4ecc-b24a-0e468facfc2f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("55aa5cec-38ea-427d-aa30-159ba7f19dbf"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("df0f7184-2e70-44c2-a3ff-ab031721131d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8a516de1-9d7b-4d1a-846c-3024ce73f5dc"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ce8a65d8-9d76-4e1e-8f25-076eb82ec8eb"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("fc15f91c-6d3c-4221-bca2-fb91163fa9f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("542ee22e-9ac2-4244-8ffb-73f530fa4fe2"));

            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "AuditLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1e692ecc-e441-4bca-a00a-49c2c78bd920"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9792), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9793), false, "Enrollee", "Admin" },
                    { new Guid("6c10f122-15ec-4640-bfe3-4fb35424c103"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9795), false, "Client", "Admin" },
                    { new Guid("d63e516e-0870-42d0-87c5-574141e3a993"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9789), false, "Admin", "Admin" },
                    { new Guid("fc69a6b5-5e1e-49d8-a85a-23e35b182c92"), "Admin", new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9796), new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9797), false, "Provider", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("5b1f9835-c7e1-4958-9ea1-25ebd106b10f"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("64322801-fea4-4bc4-ac4a-ff98f1440578"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("ef1a831f-3bc0-4c8c-8dfc-b1ba6999b0b7"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("b1c1efc6-d601-43ae-8424-2e7e3beba06e"), null, new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9586), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 10, 11, 39, 28, 194, DateTimeKind.Local).AddTicks(9603), "HMO", null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
