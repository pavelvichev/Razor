using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesLessons.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROC spAddNewEmployee 
                                @Name nvarchar(100),
                                @Email nvarchar(100),
                                @PhotoPath nvarchar(100),
                                @Dept int
                                    AS
                                BEGIN
                                    INSERT INTO Employees (Name, Email, PhotoPath, Department)
                                    VALUES (@Name, @Email, @PhotoPath, @Dept)
                                END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"Drop PROC spAddNewEmployee";
                               

			migrationBuilder.Sql(procedure);
		}
    }
}
