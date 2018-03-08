using System.Collections.Generic;
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
        public IActionResult PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (BookExists(book.BookId))
            {
                _bookService.UpdateBookInCollection(book);
                return Ok(book);
            }
            _bookService.CreateNewBookInCollection(book);
            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _bookService.CheckIfBookExists(id);
        }
    }
}