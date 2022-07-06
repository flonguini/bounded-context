using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations.Faturamento
{
    public partial class RelacaoAgenciaFaturamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgenciaId",
                table: "Faturamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faturamento_AgenciaId",
                table: "Faturamento",
                column: "AgenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faturamento_AgenciaId",
                table: "Faturamento");

            migrationBuilder.DropColumn(
                name: "AgenciaId",
                table: "Faturamento");
        }
    }
}
