using Microsoft.EntityFrameworkCore.Migrations;

namespace sconug.org.mssql.integration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<string>(nullable: false),
                    HouseNum = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    EmailID = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    AddressID = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AddressID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Events",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    EventID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Events", x => new { x.EventID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_Customer_Events_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Events_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTags",
                columns: table => new
                {
                    EventTagID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EventID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTags", x => x.EventTagID);
                    table.ForeignKey(
                        name: "FK_EventTags_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer_EventTags",
                columns: table => new
                {
                    CustomerID = table.Column<string>(nullable: false),
                    EventTagID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_EventTags", x => new { x.EventTagID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_Customer_EventTags_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_EventTags_EventTags_EventTagID",
                        column: x => x.EventTagID,
                        principalTable: "EventTags",
                        principalColumn: "EventTagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_EventTags",
                columns: table => new
                {
                    EventID = table.Column<string>(nullable: false),
                    EventTagID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_EventTags", x => new { x.EventID, x.EventTagID });
                    table.ForeignKey(
                        name: "FK_Event_EventTags_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_EventTags_EventTags_EventTagID",
                        column: x => x.EventTagID,
                        principalTable: "EventTags",
                        principalColumn: "EventTagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Events_CustomerID",
                table: "Customer_Events",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EventTags_CustomerID",
                table: "Customer_EventTags",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressID",
                table: "Customers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTags_EventTagID",
                table: "Event_EventTags",
                column: "EventTagID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddressID",
                table: "Events",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_EventID",
                table: "EventTags",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Events");

            migrationBuilder.DropTable(
                name: "Customer_EventTags");

            migrationBuilder.DropTable(
                name: "Event_EventTags");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EventTags");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
