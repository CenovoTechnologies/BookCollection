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
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true)
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
                    CollectionName = table.Column<string>(nullable: true),
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
                    BirthPlace = table.Column<string>(nullable: true),
                    BookCollectionId = table.Column<int>(nullable: false),
                    DeathDate = table.Column<DateTime>(nullable: false),
                    DeathPlace = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    Pseudonym = table.Column<string>(nullable: true),
                    WebsiteLink = table.Column<string>(nullable: true),
                    WikipediaLink = table.Column<string>(nullable: true)
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
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dewey = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    LocClassification = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    PublisherDate = table.Column<DateTime>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
