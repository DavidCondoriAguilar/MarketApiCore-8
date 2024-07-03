using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPeruCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "ORDEN",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDEN", x => x.IdOrden);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Representante = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "GUIA",
                columns: table => new
                {
                    IdGuia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Transportista = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIA", x => x.IdGuia);
                    table.ForeignKey(
                        name: "FK_GUIA_LOCAL_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "LOCAL",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrecioProveedor = table.Column<decimal>(type: "money", nullable: true),
                    StockActual = table.Column<short>(type: "smallint", nullable: false),
                    StockMinimo = table.Column<short>(type: "smallint", nullable: false),
                    Descontinuado = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_CATEGORIA_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CATEGORIA",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_PROVEEDOR_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "PROVEEDOR",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_Nombre",
                table: "CATEGORIA",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GUIA_IdLocal",
                table: "GUIA",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_IdCategoria",
                table: "PRODUCTO",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_IdProveedor",
                table: "PRODUCTO",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_Nombre",
                table: "PRODUCTO",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROVEEDOR_Nombre",
                table: "PROVEEDOR",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GUIA");

            migrationBuilder.DropTable(
                name: "ORDEN");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "LOCAL");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "PROVEEDOR");
        }
    }
}
