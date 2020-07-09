using Microsoft.EntityFrameworkCore.Migrations;

namespace sconug.org.mssql.integration.Migrations
{
    public partial class SecondTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTags_Events_EventID",
                table: "EventTags");

            migrationBuilder.DropIndex(
                name: "IX_EventTags_EventID",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "EventTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventID",
                table: "EventTags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_EventID",
                table: "EventTags",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTags_Events_EventID",
                table: "EventTags",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
