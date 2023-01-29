using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAcademyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Fullname", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "Adminbek Adminov", "8cb2237d0679ca88db6464eac60da96345513964", 1, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
