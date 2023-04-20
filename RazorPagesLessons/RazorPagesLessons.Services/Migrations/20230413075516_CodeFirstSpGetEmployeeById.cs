using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesLessons.Services.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstSpGetEmployeeById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROC CodeFirstSpGetEmployeeById
                                    @Id int
                                    as 
                                    Begin
                                        SELECT * FROM EMPLOYEES
                                         where Id = @Id
                                    END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string procedure = @"DROP PROC CodeFirstSpGetEmployeeById";

			migrationBuilder.Sql(procedure);
		}
    }
}
