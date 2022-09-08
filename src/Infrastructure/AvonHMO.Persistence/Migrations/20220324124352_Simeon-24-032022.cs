using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Simeon24032022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("541069a3-31f6-4d2b-b252-97b12ebf9129"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("d022944c-6b86-4dc2-b2ce-6c3d7fb031be"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e0566ddb-c0e6-429b-8d9a-862b43391d60"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("e8da87c1-4c8a-4467-88a8-64132140d3fb"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("1f5c9c0f-aacb-41bf-8456-42175637ec5d"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6bcf9e88-328e-4505-9e80-019a940ddbd0"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("f75cb936-6e8b-426d-9cc1-c20d6d1877ae"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("204ac40d-ef82-4c87-976a-b864cec56503"));

            migrationBuilder.AddColumn<string>(
                name: "PACode",
                table: "RequestAuthorizations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("2cbc216e-1c94-44b2-87d1-75471ed8b995"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7938), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7939), false, "Provider", "Admin" },
            //        { new Guid("4f04c3d6-13c8-471f-b3e3-8f909f1668ac"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7924), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7924), false, "Admin", "Admin" },
            //        { new Guid("aca5cd67-fbdc-40f6-a0e4-26b0c90016fe"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7937), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7937), false, "Client", "Admin" },
            //        { new Guid("b7ce94e5-94ec-477d-b3da-a8970dfaf22c"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7926), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7927), false, "Enrollee", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("6a14c279-701a-47bc-9a7f-930043d60c8b"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("6dedc037-820d-4d30-b86f-4ba4caebf572"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("8fa3ae5f-4363-4cee-959e-11d2ad447187"), "SENDGRID_KEY", "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" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("7c6d8f3e-d3f0-48c1-99a9-e1886809f593"), null, new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7658), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7675), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2cbc216e-1c94-44b2-87d1-75471ed8b995"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("4f04c3d6-13c8-471f-b3e3-8f909f1668ac"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("aca5cd67-fbdc-40f6-a0e4-26b0c90016fe"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("b7ce94e5-94ec-477d-b3da-a8970dfaf22c"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6a14c279-701a-47bc-9a7f-930043d60c8b"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6dedc037-820d-4d30-b86f-4ba4caebf572"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("8fa3ae5f-4363-4cee-959e-11d2ad447187"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("7c6d8f3e-d3f0-48c1-99a9-e1886809f593"));

            migrationBuilder.DropColumn(
                name: "PACode",
                table: "RequestAuthorizations");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("541069a3-31f6-4d2b-b252-97b12ebf9129"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6225), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6226), false, "Provider", "Admin" },
                    { new Guid("d022944c-6b86-4dc2-b2ce-6c3d7fb031be"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6223), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6224), false, "Client", "Admin" },
                    { new Guid("e0566ddb-c0e6-429b-8d9a-862b43391d60"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6221), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6221), false, "Enrollee", "Admin" },
                    { new Guid("e8da87c1-4c8a-4467-88a8-64132140d3fb"), "Admin", new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6217), new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(6217), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("1f5c9c0f-aacb-41bf-8456-42175637ec5d"), "SENDGRID_KEY", "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" },
                    { new Guid("6bcf9e88-328e-4505-9e80-019a940ddbd0"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("f75cb936-6e8b-426d-9cc1-c20d6d1877ae"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("204ac40d-ef82-4c87-976a-b864cec56503"), null, new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(5916), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 20, 8, 23, 8, 169, DateTimeKind.Local).AddTicks(5932), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
