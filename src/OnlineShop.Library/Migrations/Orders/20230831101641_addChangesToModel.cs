using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Library.Migrations.Orders
{
    public partial class addChangesToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Goods_GoodsId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "PriceLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoodsId",
                table: "PriceLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Goods_GoodsId",
                table: "PriceLists",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Goods_GoodsId",
                table: "PriceLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoodsId",
                table: "PriceLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "PriceLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Goods_GoodsId",
                table: "PriceLists",
                column: "GoodsId",
                principalTable: "Goods",
                principalColumn: "Id");
        }
    }
}
