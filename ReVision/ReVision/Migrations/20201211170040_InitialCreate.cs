using Microsoft.EntityFrameworkCore.Migrations;

namespace ReVision.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    QAModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: true),
                    AnswerPropositionId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.QAModelId);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposition",
                columns: table => new
                {
                    PropositionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropositionTitle = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true),
                    QAModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposition", x => x.PropositionId);
                    table.ForeignKey(
                        name: "FK_Proposition_QuestionAnswer_QAModelId",
                        column: x => x.QAModelId,
                        principalTable: "QuestionAnswer",
                        principalColumn: "QAModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposition_QAModelId",
                table: "Proposition",
                column: "QAModelId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_AnswerPropositionId",
                table: "QuestionAnswer",
                column: "AnswerPropositionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_SubjectId",
                table: "QuestionAnswer",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_Proposition_AnswerPropositionId",
                table: "QuestionAnswer",
                column: "AnswerPropositionId",
                principalTable: "Proposition",
                principalColumn: "PropositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposition_QuestionAnswer_QAModelId",
                table: "Proposition");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "Proposition");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
