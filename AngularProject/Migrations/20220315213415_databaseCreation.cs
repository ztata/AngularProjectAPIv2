using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularProject.Migrations
{
    public partial class databaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookmarkedTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(maxLength: 40, nullable: false),
                    ticketName = table.Column<string>(maxLength: 40, nullable: false),
                    createdBy = table.Column<string>(maxLength: 40, nullable: false),
                    ticketDescription = table.Column<string>(maxLength: 400, nullable: false),
                    isResolved = table.Column<bool>(nullable: false),
                    completedBy = table.Column<string>(maxLength: 40, nullable: true),
                    resolutionNotes = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmarkedTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketName = table.Column<string>(maxLength: 40, nullable: false),
                    createdBy = table.Column<string>(maxLength: 40, nullable: false),
                    ticketDescription = table.Column<string>(maxLength: 400, nullable: false),
                    isResolved = table.Column<bool>(nullable: false),
                    completedBy = table.Column<string>(maxLength: 40, nullable: true),
                    resolutionNotes = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookmarkedTickets");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
