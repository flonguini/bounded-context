using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations.Materiais
{
    public partial class AdicionaFkSegmento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "SegmentoId",
                table: "Materiais",
                column: "SegmentoId",
                principalTable: "Segmentos");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_SegmentoId",
                table: "Materiais",
                column: "SegmentoId", 
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SegmentoId", 
                table: "Materiais");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_SegmentoId", 
                table: "Materiais");

        }
    }
}
