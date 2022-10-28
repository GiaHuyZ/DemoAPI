using Microsoft.EntityFrameworkCore.Migrations;

namespace OAnQuanWebAPI.Migrations
{
    public partial class UpdateRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__UserAccou__roleI__38996AB5",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_roleId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "UserAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roleId",
                table: "UserAccount",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_roleId",
                table: "UserAccount",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK__UserAccou__roleI__38996AB5",
                table: "UserAccount",
                column: "roleId",
                principalTable: "UserRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
