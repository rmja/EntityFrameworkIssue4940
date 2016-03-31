using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EntityFrameworkIssue4940.Migrations
{
    public partial class ValueFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE FUNCTION issue4940.ValueFunction
(
	@OnlyIntegers bit,
	@Sometime datetime
)
RETURNS TABLE WITH SCHEMABINDING AS
RETURN
	SELECT
		Integer_Value, String_Value, Id, Discriminator, Created
	FROM
		issue4940.Value
	WHERE
		@OnlyIntegers = 0 OR Discriminator = 1
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION issue4940.ValueFunction");
        }
    }
}
