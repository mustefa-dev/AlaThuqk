using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaThuqk.Migrations
{
    /// <inheritdoc />
    public partial class componnent3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "TemplateId",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "TemplateId",
                table: "Sizes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");
        }
    }
}
