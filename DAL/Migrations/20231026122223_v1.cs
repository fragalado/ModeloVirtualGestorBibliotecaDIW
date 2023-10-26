using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acceso",
                columns: table => new
                {
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: true),
                    descripcion_acceso = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acceso", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "autor",
                columns: table => new
                {
                    id_autor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_autor = table.Column<string>(type: "text", nullable: true),
                    apellidos_autor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autor", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "coleccion",
                columns: table => new
                {
                    id_coleccion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_coleccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coleccion", x => x.id_coleccion);
                });

            migrationBuilder.CreateTable(
                name: "editorial",
                columns: table => new
                {
                    id_editorial = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_editorial = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editorial", x => x.id_editorial);
                });

            migrationBuilder.CreateTable(
                name: "estadoPrestamo",
                columns: table => new
                {
                    id_estado_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codigo_estado_prestamo = table.Column<string>(type: "text", nullable: true),
                    descripcion_estado_prestamo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoPrestamo", x => x.id_estado_prestamo);
                });

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    id_genero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_genero = table.Column<string>(type: "text", nullable: true),
                    descripcion_genero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.id_genero);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dni_usuario = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: true),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: true),
                    tlf_usuario = table.Column<string>(type: "text", nullable: true),
                    email_usuario = table.Column<string>(type: "text", nullable: true),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: true),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuario_acceso_id_acceso",
                        column: x => x.id_acceso,
                        principalTable: "acceso",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libro",
                columns: table => new
                {
                    id_libro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    isbn_libro = table.Column<string>(type: "text", nullable: true),
                    titulo_libro = table.Column<string>(type: "text", nullable: true),
                    edicion_libro = table.Column<string>(type: "text", nullable: true),
                    id_editorial = table.Column<long>(type: "bigint", nullable: false),
                    id_genero = table.Column<long>(type: "bigint", nullable: false),
                    id_coleccion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libro", x => x.id_libro);
                    table.ForeignKey(
                        name: "FK_libro_coleccion_id_coleccion",
                        column: x => x.id_coleccion,
                        principalTable: "coleccion",
                        principalColumn: "id_coleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libro_editorial_id_editorial",
                        column: x => x.id_editorial,
                        principalTable: "editorial",
                        principalColumn: "id_editorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libro_genero_id_genero",
                        column: x => x.id_genero,
                        principalTable: "genero",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prestamo",
                columns: table => new
                {
                    id_prestamo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fch_inicio_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_fin_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_entrega_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    id_estado_prestamo = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamo", x => x.id_prestamo);
                    table.ForeignKey(
                        name: "FK_prestamo_estadoPrestamo_id_estado_prestamo",
                        column: x => x.id_estado_prestamo,
                        principalTable: "estadoPrestamo",
                        principalColumn: "id_estado_prestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prestamo_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rel_autor_libro",
                columns: table => new
                {
                    id_rel_autores_libros = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_autor = table.Column<long>(type: "bigint", nullable: false),
                    id_libro = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_autor_libro", x => x.id_rel_autores_libros);
                    table.ForeignKey(
                        name: "FK_rel_autor_libro_autor_id_autor",
                        column: x => x.id_autor,
                        principalTable: "autor",
                        principalColumn: "id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rel_autor_libro_libro_id_libro",
                        column: x => x.id_libro,
                        principalTable: "libro",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rel_prestamo_libro",
                columns: table => new
                {
                    id_rel_prestamos_libros = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_prestamo = table.Column<long>(type: "bigint", nullable: false),
                    id_libro = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rel_prestamo_libro", x => x.id_rel_prestamos_libros);
                    table.ForeignKey(
                        name: "FK_rel_prestamo_libro_libro_id_libro",
                        column: x => x.id_libro,
                        principalTable: "libro",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rel_prestamo_libro_prestamo_id_prestamo",
                        column: x => x.id_prestamo,
                        principalTable: "prestamo",
                        principalColumn: "id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_libro_id_coleccion",
                table: "libro",
                column: "id_coleccion");

            migrationBuilder.CreateIndex(
                name: "IX_libro_id_editorial",
                table: "libro",
                column: "id_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_libro_id_genero",
                table: "libro",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_id_estado_prestamo",
                table: "prestamo",
                column: "id_estado_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_id_usuario",
                table: "prestamo",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_rel_autor_libro_id_autor",
                table: "rel_autor_libro",
                column: "id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_rel_autor_libro_id_libro",
                table: "rel_autor_libro",
                column: "id_libro");

            migrationBuilder.CreateIndex(
                name: "IX_rel_prestamo_libro_id_libro",
                table: "rel_prestamo_libro",
                column: "id_libro");

            migrationBuilder.CreateIndex(
                name: "IX_rel_prestamo_libro_id_prestamo",
                table: "rel_prestamo_libro",
                column: "id_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_acceso",
                table: "usuario",
                column: "id_acceso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rel_autor_libro");

            migrationBuilder.DropTable(
                name: "rel_prestamo_libro");

            migrationBuilder.DropTable(
                name: "autor");

            migrationBuilder.DropTable(
                name: "libro");

            migrationBuilder.DropTable(
                name: "prestamo");

            migrationBuilder.DropTable(
                name: "coleccion");

            migrationBuilder.DropTable(
                name: "editorial");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "estadoPrestamo");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "acceso");
        }
    }
}
