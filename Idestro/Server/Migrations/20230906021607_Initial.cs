using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Idestro.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "ConvertFiles",
                columns: table => new
                {
                    ProjectDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobDesc = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FmtNo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FileDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UploadDtm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadUsr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertFiles", x => new { x.ProjectDesc, x.JobDesc, x.FmtNo, x.FileDesc });
                });

            migrationBuilder.CreateTable(
                name: "FieldMst",
                columns: table => new
                {
                    ProjectDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobDesc = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FmtNo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FldNo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StartCol = table.Column<int>(type: "int", nullable: false),
                    LastCol = table.Column<int>(type: "int", nullable: false),
                    FldLen = table.Column<int>(type: "int", nullable: false),
                    FldUse = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IdesFldDesc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UploadDtm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadUsr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldMst", x => new { x.ProjectDesc, x.JobDesc, x.FmtNo, x.FldNo });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ConvertFiles");

            migrationBuilder.DropTable(
                name: "FieldMst");
        }
    }
}
