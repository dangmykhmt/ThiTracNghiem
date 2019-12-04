using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseStudy.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id_student = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    birthday = table.Column<DateTime>(nullable: false),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id_student);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id_subject = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subject_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id_subject);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id_question = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_subject = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    answer_a = table.Column<string>(nullable: true),
                    answer_b = table.Column<string>(nullable: true),
                    answer_c = table.Column<string>(nullable: true),
                    answer_d = table.Column<string>(nullable: true),
                    correct_answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id_question);
                    table.ForeignKey(
                        name: "FK_questions_subjects_id_subject",
                        column: x => x.id_subject,
                        principalTable: "subjects",
                        principalColumn: "id_subject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    test_code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    test_name = table.Column<string>(nullable: true),
                    id_subject = table.Column<int>(nullable: false),
                    total_questions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.test_code);
                    table.ForeignKey(
                        name: "FK_tests_subjects_id_subject",
                        column: x => x.id_subject,
                        principalTable: "subjects",
                        principalColumn: "id_subject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_test_detail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_student = table.Column<int>(nullable: false),
                    id_question = table.Column<int>(nullable: false),
                    answer_a = table.Column<string>(nullable: true),
                    answer_b = table.Column<string>(nullable: true),
                    answer_c = table.Column<string>(nullable: true),
                    answer_d = table.Column<string>(nullable: true),
                    student_answer = table.Column<string>(nullable: true),
                    test_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_test_detail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_student_test_detail_questions_id_question",
                        column: x => x.id_question,
                        principalTable: "questions",
                        principalColumn: "id_question",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_test_detail_students_id_student",
                        column: x => x.id_student,
                        principalTable: "students",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quests_of_test",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    test_code = table.Column<int>(nullable: false),
                    id_question = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests_of_test", x => x.ID);
                    table.ForeignKey(
                        name: "FK_quests_of_test_questions_id_question",
                        column: x => x.id_question,
                        principalTable: "questions",
                        principalColumn: "id_question",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quests_of_test_tests_test_code",
                        column: x => x.test_code,
                        principalTable: "tests",
                        principalColumn: "test_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    id_score = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    score_number = table.Column<double>(nullable: false),
                    detail = table.Column<string>(nullable: true),
                    id_student = table.Column<int>(nullable: false),
                    test_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.id_score);
                    table.ForeignKey(
                        name: "FK_scores_students_id_student",
                        column: x => x.id_student,
                        principalTable: "students",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scores_tests_test_code",
                        column: x => x.test_code,
                        principalTable: "tests",
                        principalColumn: "test_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_id_subject",
                table: "questions",
                column: "id_subject");

            migrationBuilder.CreateIndex(
                name: "IX_quests_of_test_id_question",
                table: "quests_of_test",
                column: "id_question");

            migrationBuilder.CreateIndex(
                name: "IX_quests_of_test_test_code",
                table: "quests_of_test",
                column: "test_code");

            migrationBuilder.CreateIndex(
                name: "IX_scores_id_student",
                table: "scores",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_scores_test_code",
                table: "scores",
                column: "test_code");

            migrationBuilder.CreateIndex(
                name: "IX_student_test_detail_id_question",
                table: "student_test_detail",
                column: "id_question");

            migrationBuilder.CreateIndex(
                name: "IX_student_test_detail_id_student",
                table: "student_test_detail",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_tests_id_subject",
                table: "tests",
                column: "id_subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quests_of_test");

            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "student_test_detail");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}
