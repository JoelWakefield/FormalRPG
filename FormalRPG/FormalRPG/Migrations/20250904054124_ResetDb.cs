using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormalRPG.Migrations
{
    /// <inheritdoc />
    public partial class ResetDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpgCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Xp = table.Column<int>(type: "integer", nullable: false),
                    Money = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RpgCharacters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RpgQuests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgQuests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpgSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpgUpgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgUpgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpgOwnedItems",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgOwnedItems", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_RpgOwnedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RpgOwnedItems_RpgCharacters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "RpgCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RpgActiveQuests",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgActiveQuests", x => new { x.CharacterId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_RpgActiveQuests_RpgCharacters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "RpgCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RpgActiveQuests_RpgQuests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "RpgQuests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RpgCharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgCharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_RpgCharacterSkills_RpgCharacters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "RpgCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RpgCharacterSkills_RpgSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "RpgSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RpgQuestSkills",
                columns: table => new
                {
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgQuestSkills", x => new { x.QuestId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_RpgQuestSkills_RpgQuests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "RpgQuests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RpgQuestSkills_RpgSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "RpgSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RpgAppliedUpgrades",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    UpgradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgAppliedUpgrades", x => new { x.CharacterId, x.UpgradeId });
                    table.ForeignKey(
                        name: "FK_RpgAppliedUpgrades_RpgCharacters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "RpgCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RpgAppliedUpgrades_RpgUpgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "RpgUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RpgActiveQuests_QuestId",
                table: "RpgActiveQuests",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgAppliedUpgrades_UpgradeId",
                table: "RpgAppliedUpgrades",
                column: "UpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgCharacters_UserId",
                table: "RpgCharacters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgCharacterSkills_SkillId",
                table: "RpgCharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgOwnedItems_ItemId",
                table: "RpgOwnedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RpgQuestSkills_SkillId",
                table: "RpgQuestSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RpgActiveQuests");

            migrationBuilder.DropTable(
                name: "RpgAppliedUpgrades");

            migrationBuilder.DropTable(
                name: "RpgCharacterSkills");

            migrationBuilder.DropTable(
                name: "RpgOwnedItems");

            migrationBuilder.DropTable(
                name: "RpgQuestSkills");

            migrationBuilder.DropTable(
                name: "RpgUpgrades");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "RpgCharacters");

            migrationBuilder.DropTable(
                name: "RpgQuests");

            migrationBuilder.DropTable(
                name: "RpgSkills");
        }
    }
}
