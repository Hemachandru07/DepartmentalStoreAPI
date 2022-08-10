using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentalStore.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_customers_CustomerId",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_ordermasters_OrderMasterId",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_payments_PaymentId",
                table: "orderdetails");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "orderdetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderMasterId",
                table: "orderdetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "orderdetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_customers_CustomerId",
                table: "orderdetails",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_ordermasters_OrderMasterId",
                table: "orderdetails",
                column: "OrderMasterId",
                principalTable: "ordermasters",
                principalColumn: "OrderMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_payments_PaymentId",
                table: "orderdetails",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "PaymentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_customers_CustomerId",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_ordermasters_OrderMasterId",
                table: "orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_payments_PaymentId",
                table: "orderdetails");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderMasterId",
                table: "orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_customers_CustomerId",
                table: "orderdetails",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_ordermasters_OrderMasterId",
                table: "orderdetails",
                column: "OrderMasterId",
                principalTable: "ordermasters",
                principalColumn: "OrderMasterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_payments_PaymentId",
                table: "orderdetails",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
