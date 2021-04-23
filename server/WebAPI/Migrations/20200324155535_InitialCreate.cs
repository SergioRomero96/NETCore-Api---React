using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationCandidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mobile = table.Column<string>(type: "varchar(16)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Age = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<string>(maxLength: 3, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCandidates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationCandidates");
        }
    }
}
