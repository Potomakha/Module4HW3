using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4HW3.Migrations
{
    public partial class ForgotEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "OfficeTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office Table",
                table: "Office Table",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Office Table_OfficeId",
                table: "Employee",
                column: "OfficeId",
                principalTable: "Office Table",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Office Table_OfficeId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office Table",
                table: "Office Table");

            migrationBuilder.RenameTable(
                name: "Office Table",
                newName: "Office");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Office_OfficeId",
                table: "Employee",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
