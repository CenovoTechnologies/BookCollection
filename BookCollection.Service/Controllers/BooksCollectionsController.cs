using System.Collections.Generic;
using BookCollection.Core;
using BookCollection.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookCollection.Service.Controllers
{
    [Route("api/BookCollection")]
    public class BooksCollectionsController : Controller
    {
        private readonly IBookCollectionService _bookCollectionService;

        public BooksCollectionsController(IBookCollectionService bookCollectionService)
        {
            _bookCollectionService = bookCollectionService;
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult CreateBookCollection(CollectionInfo collectionInfo)
        {
            var collection = new BooksCollection()
            {
                UserId = collectionInfo.UserId,
                CollectionName = collectionInfo.CollectionName
            };

            _bookCollectionService.CreateNewCollection(collection);

            return Ok(JsonConvert.SerializeObject(collection));
        }

        [Route("Collections")]
        [HttpGet]
        public IList<BooksCollection> GetBooksCollectionsForUser([FromHeader] int userId)
        {
            return _bookCollectionService.RetrieveCollectionsByUserId(userId);
        }

        // GET: api/BooksCollections/5
        public IActionResult GetBooksCollection(int id)
        {
            BooksCollection booksCollection = _bookCollectionService.RetrieveCollectionsByCollectionId(id);
            if (booksCollection == null)
            {
                return NotFound();
            }

            return Ok(booksCollection);
        }

        // POST: api/BooksCollections
        public IActionResult PostBooksCollection(BooksCollection booksCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookCollectionService.CreateNewCollection(booksCollection);

            return CreatedAtRoute("DefaultApi", new { id = booksCollection.CollectionId }, booksCollection);
        }

        // DELETE: api/BooksCollections/5
        public IActionResult DeleteBooksCollection(int id)
        {
            _bookCollectionService.DeleteCollectionById(id);
            return Ok();
        }

        private bool BooksCollectionExists(int id)
        {
            return _bookCollectionService.CheckIfCollectionExists(id);
        }

        public class CollectionInfo
        {
            public int UserId { get; set; }
            public string CollectionName { get; set; }
        }
    }
}