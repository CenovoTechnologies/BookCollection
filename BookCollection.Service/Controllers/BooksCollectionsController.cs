using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BookCollection.Core;
using BookCollection.Service.Service;

namespace BookCollection.Service.Controllers
{
    public class BooksCollectionsController : ApiController
    {
        private BookCollectionService bs = new BookCollectionService();

        // GET: api/BooksCollections
        public IList<BooksCollection> GetBooksCollectionsForUser(User user)
        {
            return bs.RetrieveCollectionsByUserId(user.UserId);
        }

        // GET: api/BooksCollections/5
        [ResponseType(typeof(BooksCollection))]
        public IHttpActionResult GetBooksCollection(int id)
        {
            BooksCollection booksCollection = bs.RetrieveCollectionsByCollectionId(id);
            if (booksCollection == null)
            {
                return NotFound();
            }

            return Ok(booksCollection);
        }

        // PUT: api/BooksCollections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooksCollection(int id, BooksCollection booksCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booksCollection.CollectionId)
            {
                return BadRequest();
            }

            bs.UpdateCollection(booksCollection);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BooksCollections
        [ResponseType(typeof(BooksCollection))]
        public IHttpActionResult PostBooksCollection(BooksCollection booksCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bs.CreateNewCollection(booksCollection);

            return CreatedAtRoute("DefaultApi", new { id = booksCollection.CollectionId }, booksCollection);
        }

        // DELETE: api/BooksCollections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBooksCollection(int id)
        {
            bool success = bs.DeleteCollectionById(id);
            if (success)
            {
                return Ok();
            }

            return NotFound();
        }

        private bool BooksCollectionExists(int id)
        {
            return bs.CheckIfCollectionExists(id);
        }
    }
}