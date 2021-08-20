using Microsoft.EntityFrameworkCore.Migrations;

namespace projetoGamaAcademy.Migrations
{
    public partial class VagaAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_vaga = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    empresa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    segmento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    site = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "candidatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    nascimento = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    vaga_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_candidatos_vagas_vaga_id",
                        column: x => x.vaga_id,
                        principalTable: "vagas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidatos_vaga_id",
                table: "candidatos",
                column: "vaga_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidatos");

            migrationBuilder.DropTable(
                name: "vagas");
        }
    }
}
