using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaThuqk.Migrations
{
    /// <inheritdoc />
    public partial class gov : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "GovernorateId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GovernorateId",
                table: "Addresses",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Governorate_GovernorateId",
                table: "Addresses",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Governorate_GovernorateId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_GovernorateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                table: "Addresses",
                type: "text",
                nullable: true);
        }
    }
}
