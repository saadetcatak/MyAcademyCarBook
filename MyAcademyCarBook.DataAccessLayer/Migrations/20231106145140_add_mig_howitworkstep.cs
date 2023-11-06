﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyCarBook.DataAccessLayer.Migrations
{
    public partial class add_mig_howitworkstep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HowItWorksSteps",
                columns: table => new
                {
                    HowItWorksStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowItWorksSteps", x => x.HowItWorksStepId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HowItWorksSteps");
        }
    }
}
