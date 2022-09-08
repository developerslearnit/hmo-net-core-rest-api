using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class ModifiedPlanToHavePlanCatCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("2cbc216e-1c94-44b2-87d1-75471ed8b995"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("4f04c3d6-13c8-471f-b3e3-8f909f1668ac"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("aca5cd67-fbdc-40f6-a0e4-26b0c90016fe"));

            //migrationBuilder.DeleteData(
            //    table: "AppRole",
            //    keyColumn: "RoleId",
            //    keyValue: new Guid("b7ce94e5-94ec-477d-b3da-a8970dfaf22c"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6a14c279-701a-47bc-9a7f-930043d60c8b"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("6dedc037-820d-4d30-b86f-4ba4caebf572"));

            //migrationBuilder.DeleteData(
            //    table: "AppSettings",
            //    keyColumn: "AppSettingId",
            //    keyValue: new Guid("8fa3ae5f-4363-4cee-959e-11d2ad447187"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "AppuserId",
            //    keyValue: new Guid("7c6d8f3e-d3f0-48c1-99a9-e1886809f593"));

            migrationBuilder.AddColumn<int>(
                name: "PlanCategoryCode",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.InsertData(
            //    table: "AppRole",
            //    columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
            //    values: new object[,]
            //    {
            //        { new Guid("2c007067-3d6f-490b-bd8f-3c486593f796"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1079), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1079), false, "Client", "Admin" },
            //        { new Guid("733c3831-c0e0-4c59-a18a-cbc4475ec620"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1074), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1075), false, "Admin", "Admin" },
            //        { new Guid("74553af6-db7e-4892-93e5-8bcb4455dc4f"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1077), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1077), false, "Enrollee", "Admin" },
            //        { new Guid("8a2718af-6fca-499c-a4aa-1ccb72b1f5d1"), "Admin", new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1095), new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(1095), false, "Provider", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AppSettings",
            //    columns: new[] { "AppSettingId", "Key", "Value" },
            //    values: new object[,]
            //    {
            //        { new Guid("6af1c353-412e-4903-ba4f-c67a023a4de3"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
            //        { new Guid("9cb5549e-3520-4370-8074-c81b3d321a8d"), "FROM_DISPLAY_NAME", "Avon HMO" },
            //        { new Guid("ecba183c-cd9e-47b6-b9a0-cd37211de7c5"), "SENDGRID_KEY", "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" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
            //    values: new object[] { new Guid("89b2a130-90c6-4b62-b48e-6ab00712d42c"), null, new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(888), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 4, 6, 13, 10, 26, 774, DateTimeKind.Local).AddTicks(908), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("2c007067-3d6f-490b-bd8f-3c486593f796"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("733c3831-c0e0-4c59-a18a-cbc4475ec620"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("74553af6-db7e-4892-93e5-8bcb4455dc4f"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("8a2718af-6fca-499c-a4aa-1ccb72b1f5d1"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6af1c353-412e-4903-ba4f-c67a023a4de3"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("9cb5549e-3520-4370-8074-c81b3d321a8d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ecba183c-cd9e-47b6-b9a0-cd37211de7c5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("89b2a130-90c6-4b62-b48e-6ab00712d42c"));

            migrationBuilder.DropColumn(
                name: "PlanCategoryCode",
                table: "Plans");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2cbc216e-1c94-44b2-87d1-75471ed8b995"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7938), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7939), false, "Provider", "Admin" },
                    { new Guid("4f04c3d6-13c8-471f-b3e3-8f909f1668ac"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7924), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7924), false, "Admin", "Admin" },
                    { new Guid("aca5cd67-fbdc-40f6-a0e4-26b0c90016fe"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7937), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7937), false, "Client", "Admin" },
                    { new Guid("b7ce94e5-94ec-477d-b3da-a8970dfaf22c"), "Admin", new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7926), new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7927), false, "Enrollee", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6a14c279-701a-47bc-9a7f-930043d60c8b"), "FROM_DISPLAY_NAME", "Avon HMO" },
                    { new Guid("6dedc037-820d-4d30-b86f-4ba4caebf572"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("8fa3ae5f-4363-4cee-959e-11d2ad447187"), "SENDGRID_KEY", "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" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordChangeDate", "LastPasswordResetDate", "LoginMemberNo", "MemberNo", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("7c6d8f3e-d3f0-48c1-99a9-e1886809f593"), null, new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7658), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 3, 24, 13, 43, 50, 901, DateTimeKind.Local).AddTicks(7675), "HMO", null, null, null, null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }
    }
}
