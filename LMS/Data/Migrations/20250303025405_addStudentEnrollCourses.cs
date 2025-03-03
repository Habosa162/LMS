using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStudentEnrollCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollCourse_AspNetUsers_StudentId",
                table: "StudentEnrollCourse");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_StudentEnrollCourse_Courses_CourseId",
            //    table: "StudentEnrollCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrollCourse",
                table: "StudentEnrollCourse");

            migrationBuilder.RenameTable(
                name: "StudentEnrollCourse",
                newName: "studentEnrollCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollCourse_StudentId",
                table: "studentEnrollCourses",
                newName: "IX_studentEnrollCourses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollCourse_CourseId",
                table: "studentEnrollCourses",
                newName: "IX_studentEnrollCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentEnrollCourses",
                table: "studentEnrollCourses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LessonId",
                table: "Notes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentId",
                table: "Notes",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentEnrollCourses_AspNetUsers_StudentId",
                table: "studentEnrollCourses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_studentEnrollCourses_Courses_CourseId",
                table: "studentEnrollCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentEnrollCourses_AspNetUsers_StudentId",
                table: "studentEnrollCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_studentEnrollCourses_Courses_CourseId",
                table: "studentEnrollCourses");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentEnrollCourses",
                table: "studentEnrollCourses");

            migrationBuilder.RenameTable(
                name: "studentEnrollCourses",
                newName: "StudentEnrollCourse");

            migrationBuilder.RenameIndex(
                name: "IX_studentEnrollCourses_StudentId",
                table: "StudentEnrollCourse",
                newName: "IX_StudentEnrollCourse_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_studentEnrollCourses_CourseId",
                table: "StudentEnrollCourse",
                newName: "IX_StudentEnrollCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrollCourse",
                table: "StudentEnrollCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourse_AspNetUsers_StudentId",
                table: "StudentEnrollCourse",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollCourse_Courses_CourseId",
                table: "StudentEnrollCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
