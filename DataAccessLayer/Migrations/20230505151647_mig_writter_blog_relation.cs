using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_writter_blog_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WritterID",
                table: "Blogs",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WritterID",
                table: "Blogs",
                column: "WritterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writters_WritterID",
                table: "Blogs",
                column: "WritterID",
                principalTable: "Writters",
                principalColumn: "WritterID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writters_WritterID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_WritterID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "WritterID",
                table: "Blogs");
        }
    }
}
