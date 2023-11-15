using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "Customers");
        }
    }
}
