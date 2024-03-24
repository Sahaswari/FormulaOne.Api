using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateedDate",
                table: "Drivers",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateedDate",
                table: "Achievements",
                newName: "UpdatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Drivers",
                newName: "UpdateedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Achievements",
                newName: "UpdateedDate");
        }
    }
}
