using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SilencershopTest.Migrations
{
    public partial class AddedAuditTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditorName = table.Column<string>(nullable: true),
                    AuditorEmailAddress = table.Column<string>(nullable: true),
                    AuditorMobileNumber = table.Column<string>(nullable: true),
                    TotalDocumentFlagged = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    AuditStatusId = table.Column<int>(nullable: true),
                    FFLAdminId = table.Column<int>(nullable: true),
                    IOIAdminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_AuditStatuses_AuditStatusId",
                        column: x => x.AuditStatusId,
                        principalTable: "AuditStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_Users_FFLAdminId",
                        column: x => x.FFLAdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_Users_IOIAdminId",
                        column: x => x.IOIAdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auditors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditId = table.Column<int>(nullable: true),
                    IOIUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditors_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auditors_Users_IOIUserId",
                        column: x => x.IOIUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AuditStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Not Started" });

            migrationBuilder.InsertData(
                table: "AuditStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "AuditStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 3, "Completed" });

            migrationBuilder.CreateIndex(
                name: "IX_Auditors_AuditId",
                table: "Auditors",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditors_IOIUserId",
                table: "Auditors",
                column: "IOIUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditStatusId",
                table: "Audits",
                column: "AuditStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_FFLAdminId",
                table: "Audits",
                column: "FFLAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_IOIAdminId",
                table: "Audits",
                column: "IOIAdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditors");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "AuditStatuses");
        }
    }
}
