using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseSymptom_Diseases_DiseaseId",
                table: "DiseaseSymptom");

            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseSymptom_Symptoms_SymptomId",
                table: "DiseaseSymptom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiseaseSymptom",
                table: "DiseaseSymptom");

            migrationBuilder.RenameTable(
                name: "DiseaseSymptom",
                newName: "DiseaseSymptoms");

            migrationBuilder.RenameIndex(
                name: "IX_DiseaseSymptom_SymptomId",
                table: "DiseaseSymptoms",
                newName: "IX_DiseaseSymptoms_SymptomId");

            migrationBuilder.RenameIndex(
                name: "IX_DiseaseSymptom_DiseaseId",
                table: "DiseaseSymptoms",
                newName: "IX_DiseaseSymptoms_DiseaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiseaseSymptoms",
                table: "DiseaseSymptoms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseSymptoms_Diseases_DiseaseId",
                table: "DiseaseSymptoms",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseSymptoms_Symptoms_SymptomId",
                table: "DiseaseSymptoms",
                column: "SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseSymptoms_Diseases_DiseaseId",
                table: "DiseaseSymptoms");

            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseSymptoms_Symptoms_SymptomId",
                table: "DiseaseSymptoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiseaseSymptoms",
                table: "DiseaseSymptoms");

            migrationBuilder.RenameTable(
                name: "DiseaseSymptoms",
                newName: "DiseaseSymptom");

            migrationBuilder.RenameIndex(
                name: "IX_DiseaseSymptoms_SymptomId",
                table: "DiseaseSymptom",
                newName: "IX_DiseaseSymptom_SymptomId");

            migrationBuilder.RenameIndex(
                name: "IX_DiseaseSymptoms_DiseaseId",
                table: "DiseaseSymptom",
                newName: "IX_DiseaseSymptom_DiseaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiseaseSymptom",
                table: "DiseaseSymptom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseSymptom_Diseases_DiseaseId",
                table: "DiseaseSymptom",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseSymptom_Symptoms_SymptomId",
                table: "DiseaseSymptom",
                column: "SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
