using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCollection.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookFormat",
                columns: table => new
                {
                    BookFormatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFormat", x => x.BookFormatId);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BookGenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => x.BookGenreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 21, DateTimeKind.Utc)),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleInitial = table.Column<string>(maxLength: 10, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 21, DateTimeKind.Utc))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BookCollection",
                columns: table => new
                {
                    CollectionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CollectionName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 24, DateTimeKind.Utc)),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 24, DateTimeKind.Utc)),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollection", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_BookCollection_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(maxLength: 150, nullable: true),
                    BookCollectionId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 22, DateTimeKind.Utc)),
                    DeathDate = table.Column<DateTime>(nullable: false),
                    DeathPlace = table.Column<string>(maxLength: 150, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleInitial = table.Column<string>(maxLength: 10, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 22, DateTimeKind.Utc)),
                    Pseudonym = table.Column<string>(maxLength: 100, nullable: true),
                    WebsiteLink = table.Column<string>(maxLength: 150, nullable: true),
                    WikipediaLink = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                    table.ForeignKey(
                        name: "FK_Author_BookCollection_BookCollectionId",
                        column: x => x.BookCollectionId,
                        principalTable: "BookCollection",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookFormatId = table.Column<int>(nullable: false),
                    BookGenreId = table.Column<int>(nullable: false),
                    CollectionId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 22, DateTimeKind.Utc)),
                    Dewey = table.Column<string>(maxLength: 100, nullable: true),
                    Isbn = table.Column<string>(maxLength: 100, nullable: true),
                    LocClassification = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 5, 5, 47, 58, 22, DateTimeKind.Utc)),
                    NumberOfPages = table.Column<int>(maxLength: 10, nullable: true),
                    Plot = table.Column<string>(maxLength: 400, nullable: true),
                    Publisher = table.Column<string>(maxLength: 150, nullable: true),
                    PublisherDate = table.Column<DateTime>(nullable: false),
                    SubTitle = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_BookFormat_BookFormatId",
                        column: x => x.BookFormatId,
                        principalTable: "BookFormat",
                        principalColumn: "BookFormatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_BookGenre_BookGenreId",
                        column: x => x.BookGenreId,
                        principalTable: "BookGenre",
                        principalColumn: "BookGenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_BookCollection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "BookCollection",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookCollectionId",
                table: "Author",
                column: "BookCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookFormatId",
                table: "Book",
                column: "BookFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookGenreId",
                table: "Book",
                column: "BookGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CollectionId",
                table: "Book",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCollection_UserId",
                table: "BookCollection",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookFormat");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "BookCollection");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
