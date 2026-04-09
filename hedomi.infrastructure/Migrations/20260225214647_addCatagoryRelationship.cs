using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hedomi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCatagoryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleType",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryID",
                table: "Categories",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "ParentCategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ArticleType",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }
    }
}
