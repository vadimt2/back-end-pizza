using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catrgories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catrgories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    Discount = table.Column<int>(nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ParentItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Items_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryItems_Catrgories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catrgories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    UploadedImage = table.Column<byte[]>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ConfirmationNumber = table.Column<Guid>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Tax = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BellingAndShippInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: true),
                    BellingOrShipping = table.Column<int>(nullable: false),
                    IsTheSame = table.Column<bool>(nullable: false),
                    IsSaved = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BellingAndShippInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BellingAndShippInfo_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catrgories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "All Pizza", "Pizza" },
                    { 2, "All Toopings", "Toopings" },
                    { 3, "All Pizza Crust", "PizzaCrust" },
                    { 4, "All Pizza Size", "PizzaSize" },
                    { 5, "All drinks", "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Available", "Description", "Discount", "ParentItemId", "Price", "QuantityInStock", "Title", "Total" },
                values: new object[,]
                {
                    { 9, true, "Soda drink.", null, null, 1m, null, "Coke", 1m },
                    { 8, true, "Beef pepperoni, Italian sausage, green peppers, mushrooms.", null, null, 20m, null, "Private Pizza", 20m },
                    { 7, true, "Try our great pizza", null, null, 11.99m, null, "Deluxe Feast pizza", 11.99m },
                    { 6, true, "Pizza with a little kick of buffalo wing flavor! Have your pizza and wings together!", null, null, 20m, null, "Buffalo Chicken pizza", 20m },
                    { 5, true, "It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives. It's also topped with three kinds of cheese — feta, provolone, and mozzarella — and sprinkled with garlic herb seasoning.", null, null, 10m, null, "Pacific Veggie pizza", 10m },
                    { 4, true, "This Philly Cheese Steak Pizza is cheesy, meaty, comfort food at it’s most addicting.  It starts by layering pizza dough with Alfredo Sauce followed by mozzarella cheese, juicy steak, bell peppers, mushrooms.", null, null, 11.99m, null, "Philly Cheese Steak pizza", 11.99m },
                    { 3, true, " Features traditional ham and pineapple as well as smoked bacon, roasted red peppers, mozzarella, and provolone cheese.", null, null, 14.99m, null, "Honolulu Hawaiian pizza", 14.99m },
                    { 2, true, "This spinach and feta pizza comes together really quickly, it’s a great veggie pizza option. It comes with homemade pizza sauce and homemade dough. Topped with lots of spinach, feta, red onions and sundried tomatoes this pizza is not short on flavour. I like to add some toasted pine nuts to this too just to add a little more crunch to my pizza.", null, null, 17.99m, null, "Spinach & Feta pizza", 17.99m },
                    { 1, true, "Try our the great pizza", null, null, 20m, null, "Great Pizza", 15m }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleType" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Guset" }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "Id", "Available", "Price", "Title" },
                values: new object[,]
                {
                    { 1, true, 5m, "Delivery" },
                    { 2, true, 0m, "Pickup" }
                });

            migrationBuilder.InsertData(
                table: "CategoryItems",
                columns: new[] { "Id", "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 8, 1, 8 },
                    { 7, 1, 7 },
                    { 6, 1, 6 },
                    { 9, 5, 9 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 3, 1, 3 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ItemId", "UploadedImage", "Url" },
                values: new object[,]
                {
                    { 4, 4, null, "https://www.dominos.com.au/ManagedAssets/AU/product/P356/AU_P356_en_hero_4055.jpg" },
                    { 5, 5, null, "https://i.insider.com/5cf6d1ef11e2054bb76400b4?width=1100&format=jpeg&auto=webp" },
                    { 2, 2, null, "https://media.metrolatam.com/2020/04/23/pizza14429461280-26168c22f83af34d20770970db28bb7b-1200x0.jpg" },
                    { 6, 6, null, "https://d1725r39asqzt3.cloudfront.net/9858a18d-613d-4d14-ad4d-bc87e000df9e/orig.jpg" },
                    { 7, 7, null, "https://www.sirpizzatn.com/wp-content/uploads/2017/09/RoyalFeast.jpg" },
                    { 1, 1, null, "http://st1.foodsd.co.il/Images/Recipes/xxl/Recipe-5968-7g0fXYdnVNi1LZ7N.jpg" },
                    { 8, 8, null, "https://images.squarespace-cdn.com/content/v1/53816030e4b0135aba1a2100/1454031327479-S1VJTYG878E9W09KM9DM/ke17ZwdGBToddI8pDm48kGdXwE-vebEpgb33VwdtsTxZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZUJFbgE-7XRK3dMEBRBhUpyFXBTrd8RtdLuD2xTt52BcbibHP9HAWTuiNyjdIhZkDRmM2LuhCrpPu_cqK6msTYI/PizzaHut_TargetMenuBoards_MR-002.jpg" },
                    { 3, 3, null, "https://www.dominos.com.au/ManagedAssets/AU/product/P005/AU_P005_en_hero_4055.jpg" },
                    { 9, 9, null, "https://cdn.shopify.com/s/files/1/1335/2603/products/Coca-cola_regular_1024x1024.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BellingAndShippInfo_OrderId",
                table: "BellingAndShippInfo",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryId",
                table: "CategoryItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ItemId",
                table: "CategoryItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ItemId",
                table: "Images",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParentItemId",
                table: "Items",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BellingAndShippInfo");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Catrgories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
