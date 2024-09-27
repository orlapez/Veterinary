using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary.API.Migrations
{
    /// <inheritdoc />
    public partial class AllEntitiesRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    PetTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pet_PetType_PetTypeId",
                        column: x => x.PetTypeId,
                        principalTable: "PetType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true),
                    PetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_OwnerId",
                table: "Agenda",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PetId",
                table: "Agenda",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_History_PetId",
                table: "History",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_History_ServiceTypeId",
                table: "History",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerId",
                table: "Pet",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetTypeId",
                table: "Pet",
                column: "PetTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "PetType");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
