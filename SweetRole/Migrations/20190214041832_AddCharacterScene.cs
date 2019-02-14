using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetRole.Migrations
{
    public partial class AddCharacterScene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterScene",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    SceneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterScene", x => new { x.CharacterId, x.SceneId });
                    table.ForeignKey(
                        name: "FK_CharacterScene_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterScene_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "SceneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterScene_SceneId",
                table: "CharacterScene",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterScene");
        }
    }
}
