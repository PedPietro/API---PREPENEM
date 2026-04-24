using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PREPENEMAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PREPENEM");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "PREPENEM",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    Senha = table.Column<string>(type: "char(6)", nullable: false),
                    FotoPerfil = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "PREPENEM");
        }
    }
}
