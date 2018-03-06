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
        public IActionResult CreateBookCollection([FromBody] CollectionInfo collectionInfo)
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

        [Route("Collection")]
        public IActionResult GetBooksCollection(int id)
        {
            BooksCollection booksCollection = _bookCollectionService.RetrieveCollectionsByCollectionId(id);
            if (booksCollection == null)
            {
                return NotFound();
            }

            return Ok(booksCollection);
        }

        // DELETE: api/BooksCollections/5
        public IActionResult DeleteBooksCollection(int id)
        {
            _bookCollectionService.DeleteCollectionById(id);
            return Ok();
        }

        public class CollectionInfo
        {
            public int UserId { get; set; }
            public string CollectionName { get; set; }
        }
    }
}