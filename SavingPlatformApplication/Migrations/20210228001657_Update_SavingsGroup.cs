using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingPlatformApplication.Migrations
{
    public partial class Update_SavingsGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Client_MemberId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_MemberId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "MemberSavingsGroup",
                columns: table => new
                {
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavingsGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSavingsGroup", x => new { x.MembersId, x.SavingsGroupsId });
                    table.ForeignKey(
                        name: "FK_MemberSavingsGroup_Client_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberSavingsGroup_Client_SavingsGroupsId",
                        column: x => x.SavingsGroupsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberSavingsGroup_SavingsGroupsId",
                table: "MemberSavingsGroup",
                column: "SavingsGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberSavingsGroup");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Client",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_MemberId",
                table: "Client",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Client_MemberId",
                table: "Client",
                column: "MemberId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
