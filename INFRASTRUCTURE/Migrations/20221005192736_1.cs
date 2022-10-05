using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tbl_ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    nameTicket = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    numberTicket = table.Column<long>(type: "bigint", nullable: false),
                    asunto = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    persona_solicitante = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    descripcion_de_licencia = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    feca_de_ingreso = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    fecha_modificado = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ticket", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_bin");

            migrationBuilder.CreateTable(
                name: "tbl_historial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    usuario_soporte = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    comentario_trabajo_realizado = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_bin")
                        .Annotation("MySql:CharSet", "utf8"),
                    id_Ticket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    feca_de_ingreso = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    fecha_modificado = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_historial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_histrial",
                        column: x => x.id_Ticket,
                        principalTable: "tbl_ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_bin");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_historial_id_Ticket",
                table: "tbl_historial",
                column: "id_Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_historial");

            migrationBuilder.DropTable(
                name: "tbl_ticket");
        }
    }
}
