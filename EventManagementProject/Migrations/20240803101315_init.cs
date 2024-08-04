using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PrivateQuotationRequests",
                columns: table => new
                {
                    PrivateQuotationRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ExpectedPeopleCount = table.Column<int>(type: "int", nullable: false),
                    VenueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateringInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventTiming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateQuotationRequests", x => x.PrivateQuotationRequestId);
                    table.ForeignKey(
                        name: "FK_PrivateQuotationRequests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateQuotationRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicQuotationRequests",
                columns: table => new
                {
                    PublicQuotationRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicQuotationRequests", x => x.PublicQuotationRequestId);
                    table.ForeignKey(
                        name: "FK_PublicQuotationRequests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicQuotationRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    UserCredentialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HashedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.UserCredentialId);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateQuotationResponses",
                columns: table => new
                {
                    PrivateQuotationResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivateQuotationRequestId = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotedAmount = table.Column<double>(type: "float", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateQuotationResponses", x => x.PrivateQuotationResponseId);
                    table.ForeignKey(
                        name: "FK_PrivateQuotationResponses_PrivateQuotationRequests_PrivateQuotationRequestId",
                        column: x => x.PrivateQuotationRequestId,
                        principalTable: "PrivateQuotationRequests",
                        principalColumn: "PrivateQuotationRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledPrivateEvents",
                columns: table => new
                {
                    ScheduledPrivateEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    PrivateQuotationRequestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledPrivateEvents", x => x.ScheduledPrivateEventId);
                    table.ForeignKey(
                        name: "FK_ScheduledPrivateEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledPrivateEvents_PrivateQuotationRequests_PrivateQuotationRequestId",
                        column: x => x.PrivateQuotationRequestId,
                        principalTable: "PrivateQuotationRequests",
                        principalColumn: "PrivateQuotationRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledPrivateEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicQuotationResponses",
                columns: table => new
                {
                    PublicQuotationResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicQuotationRequestId = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotedAmount = table.Column<double>(type: "float", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicQuotationResponses", x => x.PublicQuotationResponseId);
                    table.ForeignKey(
                        name: "FK_PublicQuotationResponses_PublicQuotationRequests_PublicQuotationRequestId",
                        column: x => x.PublicQuotationRequestId,
                        principalTable: "PublicQuotationRequests",
                        principalColumn: "PublicQuotationRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledPublicEvents",
                columns: table => new
                {
                    ScheduledPublicEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    PublicQuotationRequestId = table.Column<int>(type: "int", nullable: false),
                    UserEventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemainingSeats = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledPublicEvents", x => x.ScheduledPublicEventId);
                    table.ForeignKey(
                        name: "FK_ScheduledPublicEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledPublicEvents_PublicQuotationRequests_PublicQuotationRequestId",
                        column: x => x.PublicQuotationRequestId,
                        principalTable: "PublicQuotationRequests",
                        principalColumn: "PublicQuotationRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledPublicEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledPublicEventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_ScheduledPublicEvents_ScheduledPublicEventId",
                        column: x => x.ScheduledPublicEventId,
                        principalTable: "ScheduledPublicEvents",
                        principalColumn: "ScheduledPublicEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrivateQuotationRequests_EventId",
                table: "PrivateQuotationRequests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateQuotationRequests_UserId",
                table: "PrivateQuotationRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateQuotationResponses_PrivateQuotationRequestId",
                table: "PrivateQuotationResponses",
                column: "PrivateQuotationRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicQuotationRequests_EventId",
                table: "PublicQuotationRequests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicQuotationRequests_UserId",
                table: "PublicQuotationRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicQuotationResponses_PublicQuotationRequestId",
                table: "PublicQuotationResponses",
                column: "PublicQuotationRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPrivateEvents_EventId",
                table: "ScheduledPrivateEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPrivateEvents_PrivateQuotationRequestId",
                table: "ScheduledPrivateEvents",
                column: "PrivateQuotationRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPrivateEvents_UserId",
                table: "ScheduledPrivateEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPublicEvents_EventId",
                table: "ScheduledPublicEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPublicEvents_PublicQuotationRequestId",
                table: "ScheduledPublicEvents",
                column: "PublicQuotationRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledPublicEvents_UserId",
                table: "ScheduledPublicEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduledPublicEventId",
                table: "Tickets",
                column: "ScheduledPublicEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateQuotationResponses");

            migrationBuilder.DropTable(
                name: "PublicQuotationResponses");

            migrationBuilder.DropTable(
                name: "ScheduledPrivateEvents");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.DropTable(
                name: "PrivateQuotationRequests");

            migrationBuilder.DropTable(
                name: "ScheduledPublicEvents");

            migrationBuilder.DropTable(
                name: "PublicQuotationRequests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
