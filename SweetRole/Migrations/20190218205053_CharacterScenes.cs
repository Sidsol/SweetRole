using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetRole.Migrations
{
    public partial class CharacterScenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterScene_Characters_CharacterId",
                table: "CharacterScene");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterScene_Scenes_SceneId",
                table: "CharacterScene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterScene",
                table: "CharacterScene");

            migrationBuilder.RenameTable(
                name: "CharacterScene",
                newName: "CharacterScenes");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterScene_SceneId",
                table: "CharacterScenes",
                newName: "IX_CharacterScenes_SceneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterScenes",
                table: "CharacterScenes",
                columns: new[] { "CharacterId", "SceneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterScenes_Characters_CharacterId",
                table: "CharacterScenes",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterScenes_Scenes_SceneId",
                table: "CharacterScenes",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "SceneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterScenes_Characters_CharacterId",
                table: "CharacterScenes");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterScenes_Scenes_SceneId",
                table: "CharacterScenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterScenes",
                table: "CharacterScenes");

            migrationBuilder.RenameTable(
                name: "CharacterScenes",
                newName: "CharacterScene");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterScenes_SceneId",
                table: "CharacterScene",
                newName: "IX_CharacterScene_SceneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterScene",
                table: "CharacterScene",
                columns: new[] { "CharacterId", "SceneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterScene_Characters_CharacterId",
                table: "CharacterScene",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterScene_Scenes_SceneId",
                table: "CharacterScene",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "SceneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
