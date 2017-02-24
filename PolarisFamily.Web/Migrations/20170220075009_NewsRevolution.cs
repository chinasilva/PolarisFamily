using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolarisFamily.Web.Migrations
{
    public partial class NewsRevolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Videos_NewsID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Images_NewsID",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_NewsID",
                table: "Videos",
                column: "NewsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_ThemeID",
                table: "News",
                column: "ThemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsID",
                table: "Images",
                column: "NewsID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Theme_ThemeID",
                table: "News",
                column: "ThemeID",
                principalTable: "Theme",
                principalColumn: "ThemeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Theme_ThemeID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Videos_NewsID",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_News_ThemeID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Images_NewsID",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_NewsID",
                table: "Videos",
                column: "NewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsID",
                table: "Images",
                column: "NewsID");
        }
    }
}
