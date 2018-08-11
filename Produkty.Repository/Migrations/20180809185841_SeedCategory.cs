using Microsoft.EntityFrameworkCore.Migrations;

namespace Produkty.Repository.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a12','Pieczywo')");
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a11','Chemia')");
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a13','Nabiał')");
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1722a13','Napoje')");
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-1283a1732a13','Mięso')");
            migrationBuilder.Sql("INSERT INTO Categories (Id,Name) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1712a16','Alkohole')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Categories");
        }
    }
}
