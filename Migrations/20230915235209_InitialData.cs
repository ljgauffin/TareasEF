using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("b3a3096e-4274-4799-a843-380868d4831c"), null, "Actividades pendientes", 20 },
                    { new Guid("b3a3096e-4274-4799-a843-380868d4832c"), null, "Actividades personales", 50 },
                    { new Guid("b3a3096e-4274-4799-a843-380868d4833c"), null, "Actividades del Hogar", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("b3a3096e-4274-4799-a843-380868d4834c"), new Guid("b3a3096e-4274-4799-a843-380868d4831c"), null, new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6498), 1, "Hacer tarea" },
                    { new Guid("b3a3096e-4274-4799-a843-380868d4835c"), new Guid("b3a3096e-4274-4799-a843-380868d4832c"), null, new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6516), 0, "Ir al gym" },
                    { new Guid("b3a3096e-4274-4799-a843-380868d4836c"), new Guid("b3a3096e-4274-4799-a843-380868d4833c"), null, new DateTime(2023, 9, 15, 20, 52, 9, 438, DateTimeKind.Local).AddTicks(6519), 2, "Limpiar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4834c"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4835c"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4836c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4831c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4832c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b3a3096e-4274-4799-a843-380868d4833c"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
