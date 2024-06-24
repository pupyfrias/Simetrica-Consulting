using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimetricaConsulting.Persistence.Migrations.AuditDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Action = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TableName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OldValues = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NewValues = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");
        }
    }
}
