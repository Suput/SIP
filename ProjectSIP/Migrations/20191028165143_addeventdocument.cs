using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectSIP.Migrations
{
    public partial class addeventdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    LawNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    EventStart = table.Column<DateTime>(nullable: false),
                    Targets = table.Column<string>(nullable: true),
                    SpendMoney = table.Column<int>(nullable: false),
                    MainAccountantId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false),
                    DivisionName = table.Column<string>(nullable: true),
                    NecessariesFromDivision = table.Column<string>(nullable: true),
                    OrganizatorId = table.Column<int>(nullable: false),
                    SupervisorSigniture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDocuments_AspNetUsers_MainAccountantId",
                        column: x => x.MainAccountantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDocuments_AspNetUsers_OrganizatorId",
                        column: x => x.OrganizatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDocuments_AspNetUsers_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventDocument",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    EventDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventDocument", x => new { x.EventDocumentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserEventDocument_EventDocuments_EventDocumentId",
                        column: x => x.EventDocumentId,
                        principalTable: "EventDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEventDocument_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDocuments_MainAccountantId",
                table: "EventDocuments",
                column: "MainAccountantId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDocuments_OrganizatorId",
                table: "EventDocuments",
                column: "OrganizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDocuments_SupervisorId",
                table: "EventDocuments",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventDocument_UserId",
                table: "UserEventDocument",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEventDocument");

            migrationBuilder.DropTable(
                name: "EventDocuments");
        }
    }
}
