using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlaThuqk.Migrations
{
    /// <inheritdoc />
    public partial class componnent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Colors_ColorId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Products_ProductId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Users_UserId",
                table: "UserLike");

            migrationBuilder.DropColumn(
                name: "FinalImage",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Templates",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_ColorId",
                table: "Templates",
                newName: "IX_Templates_CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserLike",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "UserLike",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "UserLike",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Templates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Templates",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Templates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Templates",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Templates",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sizes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "Sizes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Components",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_TemplateId",
                table: "UserLike",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_TemplateId",
                table: "Sizes",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Categories_CategoryId",
                table: "Templates",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Products_ProductId",
                table: "UserLike",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Templates_TemplateId",
                table: "UserLike",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Users_UserId",
                table: "UserLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Templates_TemplateId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Categories_CategoryId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Products_ProductId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Templates_TemplateId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Users_UserId",
                table: "UserLike");

            migrationBuilder.DropIndex(
                name: "IX_UserLike_TemplateId",
                table: "UserLike");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_TemplateId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "UserLike");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Templates",
                newName: "ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_CategoryId",
                table: "Templates",
                newName: "IX_Templates_ColorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserLike",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "UserLike",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinalImage",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Components",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Components",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Components",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Colors_ColorId",
                table: "Templates",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Products_ProductId",
                table: "UserLike",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Users_UserId",
                table: "UserLike",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
