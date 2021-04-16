using Microsoft.EntityFrameworkCore.Migrations;

namespace Argos.Data.Migrations
{
    public partial class novosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "tipos_alerta");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "dispositivos");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "cidades");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "cameras");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "alertas");

            migrationBuilder.DropColumn(
                name: "criado_por",
                table: "alerta_providencia");

            migrationBuilder.AddColumn<bool>(
                name: "is_revoked",
                table: "usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "token_firebase",
                table: "usuarios",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "usuario_posicao",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "usuario_posicao",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "log_camera",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "cameras",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "cameras",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "alertas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "usuario_id",
                table: "alertas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_alertas_usuario_id",
                table: "alertas",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_alertas_usuarios_usuario_id",
                table: "alertas",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alertas_usuarios_usuario_id",
                table: "alertas");

            migrationBuilder.DropIndex(
                name: "IX_alertas_usuario_id",
                table: "alertas");

            migrationBuilder.DropColumn(
                name: "is_revoked",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "token_firebase",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "status",
                table: "log_camera");

            migrationBuilder.DropColumn(
                name: "status",
                table: "alertas");

            migrationBuilder.DropColumn(
                name: "usuario_id",
                table: "alertas");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "usuarios",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "longitude",
                table: "usuario_posicao",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "latitude",
                table: "usuario_posicao",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "tipos_alerta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "estados",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "dispositivos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "cidades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "longitude",
                table: "cameras",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "latitude",
                table: "cameras",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "cameras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "alertas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "criado_por",
                table: "alerta_providencia",
                nullable: false,
                defaultValue: "");
        }
    }
}
