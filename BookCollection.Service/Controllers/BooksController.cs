using System;
using System.Collections.Generic;
using System.Linq;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.Service.Controllers
{
    [Route("api/Book")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAllBooksInCollection(int collectionId)
        {
            var books = _bookService.RetrieveBooksByCollectionId(collectionId);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetBookByBookId(int id)
        {
            var book = _bookService.RetrieveBookByBookId(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult PostBook([FromBody] BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = MapBookModelToBook(bookModel);
            if (BookExists(book.BookId))
            {
                _bookService.UpdateBookInCollection(book);
                return Ok(book);
            }
            _bookService.CreateNewBookInCollection(book);
            return Ok(MakeBookModelToReturn(bookModel));
        }

        private bool BookExists(int id)
        {
            return _bookService.CheckIfBookExists(id);
        }

        public class BookModel
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string SubTitle { get; set; }
            public ICollection<Author> Authors { get; set; }
            public int CollectionId { get; set; }
            public string Isbn { get; set; }
            public int BookGenreId { get; set; }
            public int BookFormatId { get; set; }
            public int? NumberOfPages { get; set; }
            public string LocClassification { get; set; }
            public string Dewey { get; set; }
            public string Publisher { get; set; }
            public DateTime PublisherDate { get; set; }
            public string Plot { get; set; }
        }

        private Book MapBookModelToBook(BookModel bookModel)
        {
            return new Book
            {
                BookId = bookModel.BookId,
                Title = bookModel.Title,
                SubTitle = bookModel.SubTitle,
                CollectionId = bookModel.CollectionId,
                Isbn = bookModel.Isbn,
                BookGenreId = bookModel.BookGenreId,
                BookFormatId = bookModel.BookFormatId,
                NumberOfPages = bookModel.NumberOfPages,
                LocClassification = bookModel.LocClassification,
                Dewey = bookModel.Dewey,
                Publisher = bookModel.Publisher,
                PublisherDate = bookModel.PublisherDate,
                Plot = bookModel.Plot,
                BookAuthors = MapAuthorsFromBookModel(bookModel)
            };
        }

        private ICollection<BookAuthor> MapAuthorsFromBookModel(BookModel bookModel)
        {
            var bookAuthors = new List<BookAuthor>();
            foreach (var author in bookModel.Authors)
            {
                author.BookCollectionId = bookModel.BookId;
                var ba = new BookAuthor
                {
                    Author = author
                };
                bookAuthors.Add(ba);
            }
            return bookAuthors;
        }

        private BookModel MakeBookModelToReturn(BookModel model)
        {
            var bookAuthor = model.Authors.FirstOrDefault()?.BookAuthors.FirstOrDefault();
            if (bookAuthor == null)
            {
                return model;
            }
            return new BookModel
            {
                BookId = bookAuthor.BookId,
                Title = bookAuthor.Book.Title,
                SubTitle = bookAuthor.Book.SubTitle,
                Authors = model.Authors,
                CollectionId = bookAuthor.Book.CollectionId,
                Isbn = bookAuthor.Book.Isbn,
                BookGenreId = bookAuthor.Book.BookGenreId,
                BookFormatId = bookAuthor.Book.BookFormatId,
                NumberOfPages = bookAuthor.Book.NumberOfPages,
                LocClassification = bookAuthor.Book.LocClassification,
                Dewey = bookAuthor.Book.Dewey,
                Publisher = bookAuthor.Book.Publisher,
                PublisherDate = bookAuthor.Book.PublisherDate,
                Plot = bookAuthor.Book.Plot
            };
        }
    }
}