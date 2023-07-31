using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_booking_roomcout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RoomCount",
                table: "Bookings",
                newName: "RoomName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Bookings",
                newName: "RoomCount");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
