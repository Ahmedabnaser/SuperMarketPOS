using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketPOS.persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingAuditlogsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_AspNetUsers_UserId",
                table: "AuditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "Auditlogs");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLogs_UserId",
                table: "Auditlogs",
                newName: "IX_Auditlogs_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Auditlogs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Auditlogs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditlogs",
                table: "Auditlogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditlogs_AspNetUsers_UserId",
                table: "Auditlogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditlogs_AspNetUsers_UserId",
                table: "Auditlogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditlogs",
                table: "Auditlogs");

            migrationBuilder.RenameTable(
                name: "Auditlogs",
                newName: "AuditLogs");

            migrationBuilder.RenameIndex(
                name: "IX_Auditlogs_UserId",
                table: "AuditLogs",
                newName: "IX_AuditLogs_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_AspNetUsers_UserId",
                table: "AuditLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
