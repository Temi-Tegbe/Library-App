using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerOnboarding.Domain.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OutstandingBalance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBorrowed = table.Column<bool>(type: "bit", nullable: false),
                    BorrowedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "LendingHistory",
                columns: table => new
                {
                    LendingHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LendingHistory", x => x.LendingHistoryId);
                    table.ForeignKey(
                        name: "FK_LendingHistory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LendingHistory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BookId",
                table: "Customers",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LendingHistory_BookId",
                table: "LendingHistory",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LendingHistory_CustomerId",
                table: "LendingHistory",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Books_BookId",
                table: "Customers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Books_BookId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "LendingHistory");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BookId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OutstandingBalance",
                table: "Customers");
        }
    }
}
