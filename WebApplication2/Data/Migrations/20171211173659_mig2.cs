using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication2.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_ApplicationUserId",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Announcement_AnnouncementId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AnnouncementId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Announcement_ApplicationUserId",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Announcement");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserForeignKey",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Member",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserForeignKey",
                table: "Announcement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AnnouncementForeignKey",
                table: "Comment",
                column: "AnnouncementForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserForeignKey",
                table: "Comment",
                column: "ApplicationUserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_ApplicationUserForeignKey",
                table: "Announcement",
                column: "ApplicationUserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_ApplicationUserForeignKey",
                table: "Announcement",
                column: "ApplicationUserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Announcement_AnnouncementForeignKey",
                table: "Comment",
                column: "AnnouncementForeignKey",
                principalTable: "Announcement",
                principalColumn: "AnnouncementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserForeignKey",
                table: "Comment",
                column: "ApplicationUserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AspNetUsers_ApplicationUserForeignKey",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Announcement_AnnouncementForeignKey",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserForeignKey",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AnnouncementForeignKey",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserForeignKey",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Announcement_ApplicationUserForeignKey",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserForeignKey",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserForeignKey",
                table: "Announcement",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Announcement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AnnouncementId",
                table: "Comment",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_ApplicationUserId",
                table: "Announcement",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AspNetUsers_ApplicationUserId",
                table: "Announcement",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Announcement_AnnouncementId",
                table: "Comment",
                column: "AnnouncementId",
                principalTable: "Announcement",
                principalColumn: "AnnouncementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
