using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Library.Migrations
{
    public partial class AlterAddressTable_addLine2_to_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Addresses",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Addresses",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);
        }
    }
}
