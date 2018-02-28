using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.Service.Controllers
{
    [Route("api/BookFormats")]
    public class BookFormatsController : Controller
    {
        private readonly IBookFormatService _bookFormatService;

        public BookFormatsController(IBookFormatService bookFormatService)
        {
            _bookFormatService = bookFormatService;
        }
        
        [HttpGet]
        public IList<BookFormat> GetBookFormat()
        {
            return _bookFormatService.GetAllBookFormats().ToList();
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetBookFormat(int id)
        {
            BookFormat bookFormat = _bookFormatService.GetBookFormatById(id);
            if (bookFormat == null)
            {
                return NotFound();
            }
            return Ok(bookFormat);
        }
    }
}