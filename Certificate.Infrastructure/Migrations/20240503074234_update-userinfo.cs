using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Certificate.Infrastructure.Migrations
{
    public partial class updateuserinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "pdfFile",
                table: "UserInfos",
                type: "varbinary(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "pdfFile",
                table: "UserInfos",
                type: "varbinary(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
