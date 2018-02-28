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
        public IList<Book> GetAllBooksInCollection(int collectionId)
        {
            return _bookService.RetrieveBooksByCollectionId(collectionId);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetBookByBookId(int id)
        {
            Book book = _bookService.RetrieveBookByBookId(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (BookExists(book.BookId))
            {
                _bookService.UpdateBookInCollection(book);
                return Ok();
            }
            _bookService.CreateNewBookInCollection(book);
            return Ok();
        }

        private bool BookExists(int id)
        {
            return _bookService.CheckIfBookExists(id);
        }
    }
}