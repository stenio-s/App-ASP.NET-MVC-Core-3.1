using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Remove_Restrict_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
