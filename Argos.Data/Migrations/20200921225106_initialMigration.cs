using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Argos.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cameras",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    criado_em = table.Column<DateTime>(nullable: false),
                    latitude = table.Column<decimal>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    longitude = table.Column<decimal>(nullable: false),
                    nome = table.Column<string>(maxLength: 150, nullable: false),
                    criado_por = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cameras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(maxLength: 50, nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    criado_por = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_usuario",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    criado_em = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_alerta",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    descricao = table.Column<string>(maxLength: 80, nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    criado_por = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_alerta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    criado_em = table.Column<DateTime>(nullable: false),
                    nome = table.Column<string>(maxLength: 50, nullable: false),
                    estado_id = table.Column<long>(nullable: false),
                    criado_por = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.id);
                    table.ForeignKey(
                        name: "FK_cidades_estados_estado_id",
                        column: x => x.estado_id,
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    criado_em = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    cpf = table.Column<string>(maxLength: 15, nullable: false),
                    tipo_id = table.Column<long>(nullable: false),
                    criado_por = table.Column<string>(nullable: false),
                    matricula = table.Column<string>(maxLength: 50, nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    senha = table.Column<string>(maxLength: 200, nullable: false),
                    password_hash = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_tipo_usuario_tipo_id",
                        column: x => x.tipo_id,
                        principalTable: "tipo_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alertas",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cidade_id = table.Column<long>(nullable: false),
                    criado_por = table.Column<string>(nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    tipo = table.Column<long>(nullable: false),
                    titulo = table.Column<string>(maxLength: 150, nullable: false),
                    placa = table.Column<string>(maxLength: 10, nullable: false),
                    area = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alertas", x => x.id);
                    table.ForeignKey(
                        name: "FK_alertas_cidades_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alertas_tipos_alerta_tipo",
                        column: x => x.tipo,
                        principalTable: "tipos_alerta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dispositivos",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    versao = table.Column<string>(maxLength: 10, nullable: false),
                    usuario_id = table.Column<long>(nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    criado_por = table.Column<string>(nullable: false),
                    codigo_identificacao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivos", x => x.id);
                    table.ForeignKey(
                        name: "FK_dispositivos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_posicao",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    usuario_id = table.Column<long>(nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    longitude = table.Column<decimal>(nullable: false),
                    latitude = table.Column<decimal>(nullable: false),
                    UsuarioId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_posicao", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_posicao_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_posicao_usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alerta_providencia",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    descricao = table.Column<string>(maxLength: 500, nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false),
                    criado_por = table.Column<string>(nullable: false),
                    alerta_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alerta_providencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_alerta_providencia_alertas_alerta_id",
                        column: x => x.alerta_id,
                        principalTable: "alertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "log_camera",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    alerta_id = table.Column<long>(nullable: false),
                    camera_id = table.Column<long>(nullable: false),
                    data_deteccao = table.Column<DateTime>(nullable: false),
                    criado_em = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_camera", x => x.id);
                    table.ForeignKey(
                        name: "FK_log_camera_alertas_alerta_id",
                        column: x => x.alerta_id,
                        principalTable: "alertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_log_camera_cameras_camera_id",
                        column: x => x.camera_id,
                        principalTable: "cameras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alerta_providencia_alerta_id",
                table: "alerta_providencia",
                column: "alerta_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_alertas_cidade_id",
                table: "alertas",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_alertas_tipo",
                table: "alertas",
                column: "tipo");

            migrationBuilder.CreateIndex(
                name: "IX_cidades_estado_id",
                table: "cidades",
                column: "estado_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispositivos_usuario_id",
                table: "dispositivos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_camera_alerta_id",
                table: "log_camera",
                column: "alerta_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_camera_camera_id",
                table: "log_camera",
                column: "camera_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_posicao_usuario_id",
                table: "usuario_posicao",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_posicao_UsuarioId1",
                table: "usuario_posicao",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tipo_id",
                table: "usuarios",
                column: "tipo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerta_providencia");

            migrationBuilder.DropTable(
                name: "dispositivos");

            migrationBuilder.DropTable(
                name: "log_camera");

            migrationBuilder.DropTable(
                name: "usuario_posicao");

            migrationBuilder.DropTable(
                name: "alertas");

            migrationBuilder.DropTable(
                name: "cameras");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "cidades");

            migrationBuilder.DropTable(
                name: "tipos_alerta");

            migrationBuilder.DropTable(
                name: "tipo_usuario");

            migrationBuilder.DropTable(
                name: "estados");
        }
    }
}
