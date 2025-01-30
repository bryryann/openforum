using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenForumAPI.Legacy.Migrations
{
    /// <inheritdoc />
    public partial class CommunityModerators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_AspNetUsers_UserId",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Communities_UserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Communities");

            migrationBuilder.CreateTable(
                name: "CommunityUser",
                columns: table => new
                {
                    CommunitiesId = table.Column<int>(type: "integer", nullable: false),
                    ModeratorsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityUser", x => new { x.CommunitiesId, x.ModeratorsId });
                    table.ForeignKey(
                        name: "FK_CommunityUser_AspNetUsers_ModeratorsId",
                        column: x => x.ModeratorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityUser_Communities_CommunitiesId",
                        column: x => x.CommunitiesId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUser_ModeratorsId",
                table: "CommunityUser",
                column: "ModeratorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityUser");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Communities",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Communities_UserId",
                table: "Communities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_AspNetUsers_UserId",
                table: "Communities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
