using Microsoft.EntityFrameworkCore.Migrations;

namespace cjstores.API.Migrations
{
    public partial class addnewTableTipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id_TD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_TD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id_TD);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumentos_Abreviatura",
                table: "TipoDocumentos",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumentos_Nombre_TD",
                table: "TipoDocumentos",
                column: "Nombre_TD",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
