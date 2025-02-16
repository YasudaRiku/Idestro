using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Idestro.Server.Migrations
{
    public partial class Initial_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobMst",
                table: "JobMst");

            migrationBuilder.DropColumn(
                name: "FmtNo",
                table: "JobMst");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobMst",
                table: "JobMst",
                columns: new[] { "ProjectDesc", "JobDesc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobMst",
                table: "JobMst");

            migrationBuilder.AddColumn<string>(
                name: "FmtNo",
                table: "JobMst",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobMst",
                table: "JobMst",
                columns: new[] { "ProjectDesc", "JobDesc", "FmtNo" });
        }
    }
}
