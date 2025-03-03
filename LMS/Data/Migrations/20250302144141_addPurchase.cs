using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_StudentId",
                table: "Purchase");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Purchase_Courses_CourseId",
            //    table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_StudentId",
                table: "Purchases",
                newName: "IX_Purchases_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CourseId",
                table: "Purchases",
                newName: "IX_Purchases_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AspNetUsers_StudentId",
                table: "Purchases",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Courses_CourseId",
                table: "Purchases",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AspNetUsers_StudentId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Courses_CourseId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_StudentId",
                table: "Purchase",
                newName: "IX_Purchase_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CourseId",
                table: "Purchase",
                newName: "IX_Purchase_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_StudentId",
                table: "Purchase",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Courses_CourseId",
                table: "Purchase",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
