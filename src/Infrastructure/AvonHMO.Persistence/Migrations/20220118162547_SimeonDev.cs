using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class SimeonDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "EnrolleeId",
                table: "RequestRefunds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "RequestAuthorizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RequestAuthorizations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EnrolleeId",
                table: "RequestAuthorizations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RequestAuthorizations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnrolleeId",
                table: "EnrolleeRecommendations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "MemberNo",
                table: "EnrolleeRecommendations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MemberNo",
                table: "DrugRefillRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnrolleeId",
                table: "DrugRefillRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MemberNo",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnrolleeId",
                table: "DependantRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "RoleId", "CreatedBy", "DateCreated", "DateUpdated", "Deleted", "RoleName", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("06a5a625-aa15-4ffe-be87-2b61f740dff8"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4009), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4010), false, "Enrollee", "Admin" },
                    { new Guid("1d772b53-1650-4d49-ac3c-f937152583cb"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4014), false, "Provider", "Admin" },
                    { new Guid("9043d2a8-776e-4d2d-aa68-b2a49c031804"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4012), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4012), false, "Client", "Admin" },
                    { new Guid("a8c67338-d8b9-4e1b-bb19-df7ff0b47a25"), "Admin", new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(4006), false, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("6a83f533-eee4-44f8-9d1c-6c67e55c2635"), "FROM_EMAIL", "no-reply@avonhmo.com.ng" },
                    { new Guid("ed80ef2e-5d0a-4f0e-8e30-bfc4821ab25d"), "SENDGRID_KEY", "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" },
                    { new Guid("f9ec6a4f-4dc6-4442-959d-c08b9588177f"), "FROM_DISPLAY_NAME", "Avon HMO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AppuserId", "CompanyId", "DateCreated", "Email", "FailedPasswordTries", "FirstName", "IsActive", "IsLockedOut", "LastDeactivatedDate", "LastLoginDate", "LastName", "LastPasswordResetDate", "MobilePhone", "NextPasswordChangeDate", "Password", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("a2ddc022-7316-48c5-aa15-5d3e679e384f"), null, new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(3856), "admin@avonhmo.com", 0, "Avon", true, false, null, new DateTime(2022, 1, 18, 17, 25, 46, 468, DateTimeKind.Local).AddTicks(3870), "HMO", null, "234", null, "88E89B55CC00BAE0A4C97DF7367AC4C67B3CC517132D18861EC6E2926EC6AB060CC9340CA363CCC201891B6F709F3DECFF0A25848432EA5EF0CC274FC363EC60", "dux7DIR80XedaPZgh69F4xkf15fSj5W9vMF5kTXyMHUKEalBuY9guFiQksgH", "avon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("06a5a625-aa15-4ffe-be87-2b61f740dff8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("1d772b53-1650-4d49-ac3c-f937152583cb"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("9043d2a8-776e-4d2d-aa68-b2a49c031804"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "RoleId",
                keyValue: new Guid("a8c67338-d8b9-4e1b-bb19-df7ff0b47a25"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("6a83f533-eee4-44f8-9d1c-6c67e55c2635"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("ed80ef2e-5d0a-4f0e-8e30-bfc4821ab25d"));

            migrationBuilder.DeleteData(
                table: "AppSettings",
                keyColumn: "AppSettingId",
                keyValue: new Guid("f9ec6a4f-4dc6-4442-959d-c08b9588177f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AppuserId",
                keyValue: new Guid("a2ddc022-7316-48c5-aa15-5d3e679e384f"));

            migrationBuilder.DropColumn(
                name: "EnrolleeId",
                table: "RequestRefunds");

            migrationBuilder.DropColumn(
                name: "EnrolleeId",
                table: "EnrolleeRecommendations");

            migrationBuilder.DropColumn(
                name: "MemberNo",
                table: "EnrolleeRecommendations");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "RequestAuthorizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RequestAuthorizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnrolleeId",
                table: "RequestAuthorizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RequestAuthorizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MemberNo",
                table: "DrugRefillRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnrolleeId",
                table: "DrugRefillRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "MemberNo",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnrolleeId",
                table: "DependantRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
