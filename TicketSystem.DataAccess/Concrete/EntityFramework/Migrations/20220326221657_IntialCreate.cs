using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CinemaAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpoyeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    EmpUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EmpEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmpBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpoyeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId");
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    SceneId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    SceneName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SceneType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.SceneId);
                    table.ForeignKey(
                        name: "FK_Scenes_Cinemas_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CardUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CardDueDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EInvoice = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovieVisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieBanner = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MovieCategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieIMDB = table.Column<int>(type: "int", nullable: true),
                    MovieReview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MovieAgeLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_MovieCategoryId",
                        column: x => x.MovieCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Movies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmpoyeeId");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SceneId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SeatRow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "SceneId");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    SessionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionHour = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StudentNum = table.Column<int>(type: "int", nullable: false),
                    AdultNum = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Seats",
                        principalColumn: "SeatId");
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Romantic" },
                    { 3, "Comedy" },
                    { 4, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "CinemaAddress", "CinemaName" },
                values: new object[,]
                {
                    { 1, "Anteras AVM", "Cinemaximum" },
                    { 2, "Kızılay", "Deniz Feneri" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpoyeeId", "CinemaId", "EmpAddress", "EmpBirthDate", "EmpEmail", "EmpName", "EmpPassword", "EmpPhoneNumber", "EmpSurname", "EmpUserName" },
                values: new object[] { 1, 1, "Ankara", new DateTime(2022, 4, 27, 1, 16, 57, 22, DateTimeKind.Local).AddTicks(3025), "sncr.@html.com", "Ismail", "Admin", "0534543123", "Bal", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CinemaId",
                table: "Employees",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_EmployeeId",
                table: "Movies",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieCategoryId",
                table: "Movies",
                column: "MovieCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SceneId",
                table: "Seats",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
