using System.Collections.Generic;
using System.Linq;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.Service.Controllers
{
    [Route("api/BookGenres")]
    public class BookGenresController : Controller
    {
        private readonly IBookGenreService _bookGenreService;

        public BookGenresController(IBookGenreService bookGenreService)
        {
            _bookGenreService = bookGenreService;
        }
        
        [HttpGet]
        [Route("All")]
        public IList<BookGenre> GetBookGenre()
        {
            return _bookGenreService.GetAllBookGenres().ToList();
        }
        
        [HttpGet]
        public IActionResult GetBookGenre(int id)
        {
            BookGenre bookGenre = _bookGenreService.GetBookGenreById(id);
            if (bookGenre == null)
            {
                return NotFound();
            }
            return Ok(bookGenre);
        }
    }
}