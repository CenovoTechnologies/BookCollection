using System.Collections.Generic;
using System.Web.Http;
using BookCollection.Core;
using BookCollection.Service.Service;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/Author")]
    public class AuthorsController : ApiController
    {
        private AuthorService authorService = new AuthorService();
        
        [HttpGet]
        [Route("All")]
        public IList<Author> GetAllAuthorsInCollection(int collectionId)
        {
            return authorService.RetrieveAuthorsByCollectionId(collectionId);
        }
        
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult GetAuthorById(int id)
        {
            Author author = authorService.RetrieveAuthorByAuthorId(id);
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
            return authorService.RetrieveAuthorsByBookId(bookId);
        }
        
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (AuthorExists(author.AuthorId))
            {
                return Ok(authorService.UpdateAuthor(author));
            }
            return Ok(authorService.CreateNewAuthor(author));
        }

        private bool AuthorExists(int id)
        {
            return authorService.CheckIfAuthorExists(id);
        }
    }
}