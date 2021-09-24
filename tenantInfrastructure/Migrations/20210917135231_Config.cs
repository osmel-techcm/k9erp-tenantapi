using Microsoft.EntityFrameworkCore.Migrations;

namespace tenantInfrastructure.Migrations
{
    public partial class Config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    propValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propPublic = table.Column<bool>(type: "bit", nullable: false),
                    propProtected = table.Column<bool>(type: "bit", nullable: false),
                    propDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "propName", "propValue", "propPublic", "propProtected" },
                values: new object[,] {
                                { "TimeZone", "Eastern Standard Time", true, false },
                                { "CompanyName", "", true, false },
                                { "CompanyAddress", "", true, false },
                                { "CompanyCity", "", true, false },
                                { "CompanyState", "", true, false },
                                { "CompanyZip", "", true, false },
                                { "CompanyCountry", "", true, false },
                                { "CompanyPhone", "", true, false },
                                { "CompanyImage", "", true, false }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
