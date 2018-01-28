using System.Collections.Generic;
using System.Web.Http;
using BookCollection.Core;
using BookCollection.Service.Service;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/BookGenres")]
    public class BookGenresController : ApiController
    {
        private BookGenreService bgs = new BookGenreService();
        
        [HttpGet]
        public IList<BookGenre> GetBookGenre()
        {
            return bgs.GetAllBookGenres();
        }
        
        [HttpGet]
        public IHttpActionResult GetBookGenre(int id)
        {
            BookGenre bookGenre = bgs.GetBookGenreById(id);
            if (bookGenre == null)
            {
                return NotFound();
            }
            return Ok(bookGenre);
        }
    }
}