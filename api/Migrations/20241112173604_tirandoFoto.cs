using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ma2_banco_de_dados.Migrations
{
    /// <inheritdoc />
    public partial class tirandoFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "aspnetusers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Byte[]>(
                name: "ProfilePicture",
                table: "aspnetusers");
        }
    }
}
