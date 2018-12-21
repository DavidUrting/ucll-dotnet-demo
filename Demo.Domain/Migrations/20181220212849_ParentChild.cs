using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Domain.Migrations
{
    public partial class ParentChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Relations");

            migrationBuilder.CreateTable(
                name: "Parent",
                schema: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                schema: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_A",
                        column: x => x.ParentID,
                        principalSchema: "Relations",
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_ParentID",
                schema: "Relations",
                table: "Child",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Child",
                schema: "Relations");

            migrationBuilder.DropTable(
                name: "Parent",
                schema: "Relations");
        }
    }
}
