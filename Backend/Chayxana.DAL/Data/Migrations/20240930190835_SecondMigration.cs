using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Chayxana.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "orders",
                newName: "BookingId");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "branches",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BranchFeedback",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchFeedback_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchFeedback_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeedback",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeedback_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFeedback_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_BookingId",
                table: "orders",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFeedback_BranchId",
                table: "BranchFeedback",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFeedback_UserId",
                table: "BranchFeedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeedback_RoomId",
                table: "RoomFeedback",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeedback_UserId",
                table: "RoomFeedback",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bookings_BookingId",
                table: "orders",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_bookings_BookingId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "BranchFeedback");

            migrationBuilder.DropTable(
                name: "RoomFeedback");

            migrationBuilder.DropIndex(
                name: "IX_orders_BookingId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "branches");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "orders",
                newName: "RoomId");
        }
    }
}
