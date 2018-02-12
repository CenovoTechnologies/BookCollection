using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BookCollection.Core;
using BookCollection.Service.Service;
using Newtonsoft.Json;

namespace BookCollection.Service.Controllers
{
    [RoutePrefix("api/BookCollection")]
    public class BooksCollectionsController : ApiController
    {
        private BookCollectionService bs = new BookCollectionService();

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateBookCollection(CollectionInfo collectionInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var collection = new BooksCollection()
            {
                UserId = collectionInfo.UserId,
                CollectionName = collectionInfo.CollectionName
            };

            bs.CreateNewCollection(collection);

            return Ok(JsonConvert.SerializeObject(collection));
        }
        
        [Route("Collections")]
        [HttpGet]
        public IList<BooksCollection> GetBooksCollectionsForUser([FromUri] int userId)
        {
            return bs.RetrieveCollectionsByUserId(userId);
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

        public class CollectionInfo
        {
            public int UserId { get; set; }
            public string CollectionName { get; set; }
        }
    }
}