using System.Collections.Generic;
using System.Web.Http;
using BookCollection.Core;
using BookCollection.Service.Service;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/Book")]
    public class BooksController : ApiController
    {
        private BookService bookService = new BookService();
        private AuthorService authorService = new AuthorService();

        [HttpGet]
        [Route("All")]
        public IList<Book> GetAllBooksInCollection(int collectionId)
        {
            return bookService.RetrieveBooksByCollectionId(collectionId);
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetBookByBookId(int id)
        {
            Book book = bookService.RetrieveBookByBookId(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (BookExists(book.BookId))
            {
                bookService.UpdateBookInCollection(book);
                return Ok();
            }
            bookService.CreateNewBookInCollection(book);
            return Ok();
        }

        private bool BookExists(int id)
        {
            return bookService.CheckIfBookExists(id);
        }
    }
}