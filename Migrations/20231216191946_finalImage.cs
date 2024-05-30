using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaThuqk.Migrations
{
    /// <inheritdoc />
    public partial class finalImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinalImage",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinalImage",
                table: "OrderItem",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "OrderItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_TemplateId",
                table: "OrderItem",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Templates_TemplateId",
                table: "OrderItem",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Templates_TemplateId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_TemplateId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "FinalImage",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "FinalImage",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "OrderItem");
        }
    }
}
