using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonHMO.Persistence.Migrations
{
    public partial class Tobamig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailLogs",
                columns: table => new
                {
                    EmailLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestReference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecipientEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    SendStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsProcessing = table.Column<bool>(type: "bit", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLogs", x => x.EmailLogId);
                });

            migrationBuilder.CreateTable(
                name: "HCPInspectionGuildAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HCPId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCPInspectionGuildAnswers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "HCPInspectionGuildOptions",
                columns: table => new
                {
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCPInspectionGuildOptions", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "HCPInspectionGuildQuestionMasters",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    orderNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCPInspectionGuildQuestionMasters", x => x.QuestionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailLogs_RequestReference",
                table: "EmailLogs",
                column: "RequestReference",
                unique: true,
                filter: "[RequestReference] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailLogs");

            migrationBuilder.DropTable(
                name: "HCPInspectionGuildAnswers");

            migrationBuilder.DropTable(
                name: "HCPInspectionGuildOptions");

            migrationBuilder.DropTable(
                name: "HCPInspectionGuildQuestionMasters");
        }
    }
}
