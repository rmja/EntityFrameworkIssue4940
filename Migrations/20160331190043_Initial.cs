using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EntityFrameworkIssue4940.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("issue4940");
            migrationBuilder.CreateTable(
                name: "Value",
                schema: "issue4940",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<int>(nullable: false),
                    Integer_Value = table.Column<int>(nullable: true),
                    String_Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Value", schema: "issue4940");
        }
    }
}
