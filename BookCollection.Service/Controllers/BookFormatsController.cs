using System.Web.Http;
using BookCollection.Core;
using BookCollection.Service.Service;
using System.Collections.Generic;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/BookFormats")]
    public class BookFormatsController : ApiController
    {
        private BookFormatService bfs = new BookFormatService();
        
        [HttpGet]
        public IList<BookFormat> GetBookFormat()
        {
            return bfs.GetAllBookFormats();
        }

        [HttpGet]
        public IHttpActionResult GetBookFormat(int id)
        {
            BookFormat bookFormat = bfs.GetBookFormatById(id);
            if (bookFormat == null)
            {
                return NotFound();
            }
            return Ok(bookFormat);
        }
    }
}