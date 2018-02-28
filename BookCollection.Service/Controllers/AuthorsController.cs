using System.Collections.Generic;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.Service.Controllers
{
    [Route("api/Author")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        [HttpGet]
        [Route("All")]
        public IList<Author> GetAllAuthorsInCollection(int collectionId)
        {
            return _authorService.RetrieveAuthorsByCollectionId(collectionId);
        }
        
        [HttpGet]
        [Route("Get")]
        public IActionResult GetAuthorById(int id)
        {
            Author author = _authorService.RetrieveAuthorByAuthorId(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet]
        [Route("Book")]
        public IList<Author> GetAllAuthorsForBook(int bookId)
        {
            return _authorService.RetrieveAuthorsByBookId(bookId);
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (AuthorExists(author.AuthorId))
            {
                _authorService.UpdateAuthor(author);
                return Ok();
            }
            _authorService.CreateNewAuthor(author);
            return Ok();
        }

        private bool AuthorExists(int id)
        {
            return _authorService.CheckIfAuthorExists(id);
        }
    }
}