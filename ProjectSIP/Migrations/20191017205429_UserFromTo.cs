using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSIP.Migrations
{
    public partial class UserFromTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_From_FromId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_To_ToId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_From_AspNetUsers_UserId",
                table: "From");

            migrationBuilder.DropForeignKey(
                name: "FK_To_AspNetUsers_UserId",
                table: "To");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "To",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "From",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToId",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromId",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_From_FromId",
                table: "Documents",
                column: "FromId",
                principalTable: "From",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_To_ToId",
                table: "Documents",
                column: "ToId",
                principalTable: "To",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_From_AspNetUsers_UserId",
                table: "From",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_To_AspNetUsers_UserId",
                table: "To",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_From_FromId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_To_ToId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_From_AspNetUsers_UserId",
                table: "From");

            migrationBuilder.DropForeignKey(
                name: "FK_To_AspNetUsers_UserId",
                table: "To");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "To",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "From",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ToId",
                table: "Documents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FromId",
                table: "Documents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_From_FromId",
                table: "Documents",
                column: "FromId",
                principalTable: "From",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_To_ToId",
                table: "Documents",
                column: "ToId",
                principalTable: "To",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_From_AspNetUsers_UserId",
                table: "From",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_To_AspNetUsers_UserId",
                table: "To",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
