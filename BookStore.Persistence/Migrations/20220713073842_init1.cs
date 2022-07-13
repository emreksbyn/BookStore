using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Persistence.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "FirstName", "LastName", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 13, 10, 38, 42, 376, DateTimeKind.Local).AddTicks(6887), null, "Michelle", "Alexander", 1, null },
                    { 26, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1741), null, "Seth", "Grahame-Smith", 1, null },
                    { 25, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1740), null, "JK", "Rowling", 1, null },
                    { 23, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1739), null, "Augusten", "Burroughs", 1, null },
                    { 22, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1737), null, "Sun", "Tzu", 1, null },
                    { 21, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1736), null, "Mary", "Shelley", 1, null },
                    { 20, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1735), null, "George", "Orwell", 1, null },
                    { 19, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1734), null, "Toni", "Morrison", 1, null },
                    { 18, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1733), null, "David", "McCullough", 1, null },
                    { 17, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1732), null, "Stieg", "Larsson", 1, null },
                    { 16, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1730), null, "Aldous", "Huxley", 1, null },
                    { 14, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1728), null, "Dashiel", "Hammett", 1, null },
                    { 15, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1729), null, "Frank", "Herbert", 1, null },
                    { 12, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1726), null, "Tina", "Fey", 1, null },
                    { 2, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1674), null, "Stephen E.", "Ambrose", 1, null },
                    { 3, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1715), null, "Margaret", "Atwood", 1, null },
                    { 4, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1717), null, "Jane", "Austen", 1, null },
                    { 13, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1727), null, "Roxane", "Gay", 1, null },
                    { 6, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1719), null, "Emily", "Bronte", 1, null },
                    { 5, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1718), null, "James", "Baldwin", 1, null },
                    { 8, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1722), null, "Ta-Nehisi", "Coates", 1, null },
                    { 9, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1723), null, "Jared", "Diamond", 1, null },
                    { 10, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1724), null, "Joan", "Didion", 1, null },
                    { 11, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1725), null, "Daphne", "Du Maurier", 1, null },
                    { 7, new DateTime(2022, 7, 13, 10, 38, 42, 380, DateTimeKind.Local).AddTicks(1721), null, "Agatha", "Christie", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "scifi", new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(8674), null, "Science Finction", 1, null },
                    { "novel", new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(8182), null, "Novel", 1, null },
                    { "memoir", new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(8654), null, "Memoir", 1, null },
                    { "mystery", new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(8673), null, "Mystery", 1, null },
                    { "history", new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(8675), null, "History", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "GenreId", "Price", "Status", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5606), null, "novel", 10.99, 1, "Beloved", null },
                    { 15, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5618), null, "history", 15.5, 1, "Guns, Germs, and Steel", null },
                    { 9, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5611), null, "history", 15.0, 1, "D-Day", null },
                    { 4, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5605), null, "history", 11.5, 1, "Band of Brothers", null },
                    { 1, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(4578), null, "history", 18.0, 1, "1776", null },
                    { 22, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5625), null, "scifi", 12.5, 1, "The Handmaid's Tale", null },
                    { 13, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5615), null, "scifi", 6.5, 1, "Frankenstein", null },
                    { 11, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5613), null, "scifi", 8.75, 1, "Dune", null },
                    { 8, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5610), null, "scifi", 16.25, 1, "Brave New World", null },
                    { 2, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5565), null, "scifi", 5.5, 1, "1984", null },
                    { 23, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5626), null, "mystery", 10.99, 1, "The Maltese Falcon", null },
                    { 21, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5624), null, "mystery", 8.5, 1, "The Girl with the Dragon Tattoo", null },
                    { 19, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5622), null, "mystery", 10.99, 1, "Rebecca", null },
                    { 20, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5623), null, "history", 5.75, 1, "The Art of War", null },
                    { 17, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5620), null, "mystery", 6.75, 1, "Murder on the Orient Express", null },
                    { 27, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5630), null, "memoir", 11.0, 1, "Running With Scissors", null },
                    { 25, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5628), null, "memoir", 13.5, 1, "The Year of Magical Thinking", null },
                    { 16, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5619), null, "memoir", 14.5, 1, "Hunger", null },
                    { 10, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5612), null, "memoir", 12.5, 1, "Down and Out in Paris and London", null },
                    { 7, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5609), null, "memoir", 4.25, 1, "Bossypants", null },
                    { 6, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5608), null, "memoir", 13.5, 1, "Between the World and Me", null },
                    { 29, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5633), null, "novel", 9.75, 1, "Harry Potter and the Sorcerer's Stone", null },
                    { 28, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5631), null, "novel", 8.75, 1, "Pride and Prejudice and Zombies", null },
                    { 26, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5629), null, "novel", 9.0, 1, "Wuthering Heights", null },
                    { 18, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5621), null, "novel", 8.5, 1, "Pride and Prejudice", null },
                    { 14, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5616), null, "novel", 10.25, 1, "Go Tell it on the Mountain", null },
                    { 12, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5614), null, "novel", 9.0, 1, "Emma", null },
                    { 3, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5604), null, "mystery", 4.5, 1, "And Then There Were None", null },
                    { 24, new DateTime(2022, 7, 13, 10, 38, 42, 382, DateTimeKind.Local).AddTicks(5627), null, "history", 13.75, 1, "The New Jim Crow", null }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "Id", "AuthorId", "BookId", "CreateDate", "DeleteDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 5, 19, 5, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6539), null, 1, null },
                    { 15, 9, 15, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6550), null, 1, null },
                    { 9, 2, 9, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6544), null, 1, null },
                    { 4, 2, 4, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6538), null, 1, null },
                    { 1, 18, 1, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(5846), null, 1, null },
                    { 22, 3, 22, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6592), null, 1, null },
                    { 13, 21, 13, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6548), null, 1, null },
                    { 11, 15, 11, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6546), null, 1, null },
                    { 8, 16, 8, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6543), null, 1, null },
                    { 2, 20, 2, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6513), null, 1, null },
                    { 23, 14, 23, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6593), null, 1, null },
                    { 21, 17, 21, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6591), null, 1, null },
                    { 19, 11, 19, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6589), null, 1, null },
                    { 17, 7, 17, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6587), null, 1, null },
                    { 3, 7, 3, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6537), null, 1, null },
                    { 27, 23, 27, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6597), null, 1, null },
                    { 25, 10, 25, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6595), null, 1, null },
                    { 16, 13, 16, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6586), null, 1, null },
                    { 10, 20, 10, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6545), null, 1, null },
                    { 7, 12, 7, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6542), null, 1, null },
                    { 6, 8, 6, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6541), null, 1, null },
                    { 30, 25, 29, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6600), null, 1, null },
                    { 29, 26, 28, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6599), null, 1, null },
                    { 28, 4, 28, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6598), null, 1, null },
                    { 26, 6, 26, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6596), null, 1, null },
                    { 18, 4, 18, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6588), null, 1, null },
                    { 14, 5, 14, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6549), null, 1, null },
                    { 12, 4, 12, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6547), null, 1, null },
                    { 20, 22, 20, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6590), null, 1, null },
                    { 24, 1, 24, new DateTime(2022, 7, 13, 10, 38, 42, 381, DateTimeKind.Local).AddTicks(6594), null, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
