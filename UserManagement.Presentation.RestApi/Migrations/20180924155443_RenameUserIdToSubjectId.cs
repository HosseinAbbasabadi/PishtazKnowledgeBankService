using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Presentation.RestApi.Migrations
{
    public partial class RenameUserIdToSubjectId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Users",
                newName: "UserId");
        }
    }
}
