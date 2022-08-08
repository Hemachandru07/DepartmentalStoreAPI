using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentalStore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminmasters",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1001, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminmasters", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "beverages",
                columns: table => new
                {
                    BeverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    BeverageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeveragePrice = table.Column<float>(type: "real", nullable: false),
                    BeverageQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beverages", x => x.BeverageId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "2001, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "fruits",
                columns: table => new
                {
                    FruitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "201, 1"),
                    FruitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FruitPrice = table.Column<float>(type: "real", nullable: false),
                    FruitQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fruits", x => x.FruitId);
                });

            migrationBuilder.CreateTable(
                name: "groceries",
                columns: table => new
                {
                    GroceryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "301, 1"),
                    GroceryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroceryPrice = table.Column<float>(type: "real", nullable: false),
                    GroceryQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groceries", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "vegetables",
                columns: table => new
                {
                    VegetableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "401, 1"),
                    VegetableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VegetablePrice = table.Column<float>(type: "real", nullable: false),
                    VegetableQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vegetables", x => x.VegetableId);
                });

            migrationBuilder.CreateTable(
                name: "ordermasters",
                columns: table => new
                {
                    OrderMasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "3001, 1"),
                    GroceryDetailId = table.Column<int>(type: "int", nullable: false),
                    FruitDetailId = table.Column<int>(type: "int", nullable: false),
                    BeverageDetailId = table.Column<int>(type: "int", nullable: false),
                    VegetableDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordermasters", x => x.OrderMasterID);
                    table.ForeignKey(
                        name: "FK_ordermasters_beverages_BeverageDetailId",
                        column: x => x.BeverageDetailId,
                        principalTable: "beverages",
                        principalColumn: "BeverageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordermasters_fruits_FruitDetailId",
                        column: x => x.FruitDetailId,
                        principalTable: "fruits",
                        principalColumn: "FruitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordermasters_groceries_GroceryDetailId",
                        column: x => x.GroceryDetailId,
                        principalTable: "groceries",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordermasters_vegetables_VegetableDetailId",
                        column: x => x.VegetableDetailId,
                        principalTable: "vegetables",
                        principalColumn: "VegetableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "4001, 1"),
                    OrderMasterId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_payments_ordermasters_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "ordermasters",
                        principalColumn: "OrderMasterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "5001, 1"),
                    OrderMasterId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_orderdetails_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetails_ordermasters_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "ordermasters",
                        principalColumn: "OrderMasterID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_orderdetails_payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_CustomerId",
                table: "orderdetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_OrderMasterId",
                table: "orderdetails",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_PaymentId",
                table: "orderdetails",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ordermasters_BeverageDetailId",
                table: "ordermasters",
                column: "BeverageDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ordermasters_FruitDetailId",
                table: "ordermasters",
                column: "FruitDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ordermasters_GroceryDetailId",
                table: "ordermasters",
                column: "GroceryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ordermasters_VegetableDetailId",
                table: "ordermasters",
                column: "VegetableDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_OrderMasterId",
                table: "payments",
                column: "OrderMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminmasters");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "ordermasters");

            migrationBuilder.DropTable(
                name: "beverages");

            migrationBuilder.DropTable(
                name: "fruits");

            migrationBuilder.DropTable(
                name: "groceries");

            migrationBuilder.DropTable(
                name: "vegetables");
        }
    }
}
