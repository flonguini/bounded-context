using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class AdicionaSegmentosAgencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segmentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgenciaSegmento",
                columns: table => new
                {
                    AgenciasId = table.Column<int>(type: "int", nullable: false),
                    SegmentosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciaSegmento", x => new { x.AgenciasId, x.SegmentosId });
                    table.ForeignKey(
                        name: "FK_AgenciaSegmento_agencias_AgenciasId",
                        column: x => x.AgenciasId,
                        principalTable: "agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgenciaSegmento_Segmentos_SegmentosId",
                        column: x => x.SegmentosId,
                        principalTable: "Segmentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgenciaSegmento_SegmentosId",
                table: "AgenciaSegmento",
                column: "SegmentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgenciaSegmento");

            migrationBuilder.DropTable(
                name: "Segmentos");
        }
    }
}
