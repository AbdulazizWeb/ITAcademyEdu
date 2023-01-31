using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAcademyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactoringStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Students",
                newName: "CreatedDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "CA5B9811BE39C13BA3F8265C006761214B85F36FFE177C482AA548A30FC2C8994F5AE33790A4AE6A302B65A05A906AAED4912F02C0E69FC6CE14A9C90AD998A0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Students",
                newName: "CreateDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "8cb2237d0679ca88db6464eac60da96345513964");
        }
    }
}
