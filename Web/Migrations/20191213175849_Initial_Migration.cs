using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace split_timer_api.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunDefinitions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Game = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunDefinitions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunDate = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<long>(nullable: false),
                    RunDefinitionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runs_RunDefinitions_RunDefinitionId",
                        column: x => x.RunDefinitionId,
                        principalTable: "RunDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SplitDefinitions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    RunDefinitionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SplitDefinitions_RunDefinitions_RunDefinitionId",
                        column: x => x.RunDefinitionId,
                        principalTable: "RunDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<long>(nullable: false),
                    SplitDefinitionId = table.Column<long>(nullable: false),
                    RunId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Splits_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Splits_SplitDefinitions_SplitDefinitionId",
                        column: x => x.SplitDefinitionId,
                        principalTable: "SplitDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunDefinitions_UserId",
                table: "RunDefinitions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_RunDefinitionId",
                table: "Runs",
                column: "RunDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitDefinitions_RunDefinitionId",
                table: "SplitDefinitions",
                column: "RunDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Splits_RunId",
                table: "Splits",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Splits_SplitDefinitionId",
                table: "Splits",
                column: "SplitDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropTable(
                name: "Runs");

            migrationBuilder.DropTable(
                name: "SplitDefinitions");

            migrationBuilder.DropTable(
                name: "RunDefinitions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
