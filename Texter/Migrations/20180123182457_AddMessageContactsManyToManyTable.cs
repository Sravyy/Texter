using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Texter.Migrations
{
    public partial class AddMessageContactsManyToManyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Messages_MessageId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "MessageContact",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageContact", x => new { x.MessageId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_MessageContact_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageContact_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string))
                .OldAnnotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageContact_ContactId",
                table: "MessageContact",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "MessageContact");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true)
                .Annotation("MySql:ValueGeneratedOnAdd", true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MessageId",
                table: "Contacts",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Messages_MessageId",
                table: "Contacts",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
