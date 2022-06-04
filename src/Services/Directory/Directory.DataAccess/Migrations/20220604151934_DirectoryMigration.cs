using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Directory.DataAccess.Migrations
{
    public partial class DirectoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactInformationsEntities",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    informationType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    informationContent = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    personuuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactInformationsEntities", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "personsEntities",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    firstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    lastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personsEntities", x => x.uuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactInformationsEntities");

            migrationBuilder.DropTable(
                name: "personsEntities");
        }
    }
}
