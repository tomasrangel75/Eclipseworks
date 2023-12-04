using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eclipseworks.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Alteracaodepropriedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modificacao",
                table: "TarefaHistoricos",
                newName: "ValorAtual");

            migrationBuilder.AddColumn<string>(
                name: "ValorAnterior",
                table: "TarefaHistoricos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(69), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 22, 27, 14, 489, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, -3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorAnterior",
                table: "TarefaHistoricos");

            migrationBuilder.RenameColumn(
                name: "ValorAtual",
                table: "TarefaHistoricos",
                newName: "Modificacao");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 16, 50, 52, 312, DateTimeKind.Unspecified).AddTicks(2437), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 16, 50, 52, 312, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2023, 12, 3, 16, 50, 52, 312, DateTimeKind.Unspecified).AddTicks(2495), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
