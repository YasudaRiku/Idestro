using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Idestro.Server.Migrations
{
    public partial class Initial_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobMst",
                columns: table => new
                {
                    ProjectDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobDesc = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FmtNo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UploadDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUsr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMst", x => new { x.ProjectDesc, x.JobDesc, x.FmtNo });
                });

            migrationBuilder.CreateTable(
                name: "ProjectMst",
                columns: table => new
                {
                    ProjectDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UploadDtm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUsr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMst", x => x.ProjectDesc);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobMst");

            migrationBuilder.DropTable(
                name: "ProjectMst");
        }
    }
}
