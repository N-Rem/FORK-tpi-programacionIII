using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClient",
                table: "users",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "IsFinalized",
                table: "Reservations",
                newName: "State");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "sneakers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "sneakers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 0, 2 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "Category" },
                values: new object[] { 0, 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "users",
                newName: "IsClient");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Reservations",
                newName: "IsFinalized");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "sneakers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "sneakers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsFinalized",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsFinalized",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsFinalized",
                value: false);

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Nike", "Sports" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Adidas", "Casual" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Nike", "Running" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Adidas", "Casual" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Adidas", "Running" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Converse", "Casual" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Adidas", "Running" });

            migrationBuilder.UpdateData(
                table: "sneakers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "Category" },
                values: new object[] { "Nike", "Sports" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsClient",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsClient",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsClient",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsClient",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsClient",
                value: true);
        }
    }
}
