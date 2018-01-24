using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection.Repository.UnitofWork
{
    public class BookCollectionUnitOfWork : BaseUnitofWork
    {
        public void AddNewBookCollection(BooksCollection collection)
        {
            using (DbContext = new ApplicationDbContext())
            {
                DbContext.BookCollection.Add(collection);
                Save();
            }
        }

        public void UpdateBookCollection(BooksCollection collection)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Update(collection);
                Save();
            }
        }

        public bool DeleteBookCollection(BooksCollection collection)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var found = DbContext.BookCollection.Find(collection);
                if (found == null)
                {
                    return false;
                }
                DbContext.BookCollection.Remove(collection);
                Save();
                return true;
            }
        }

        public bool DeleteBookCollectionById(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var found = DbContext.BookCollection.Find(collectionId);
                if (found == null)
                {
                    return false;
                }
                DbContext.BookCollection.Remove(found);
                Save();
                return true;
            }
        }

        public BooksCollection RetrieveBookCollectionByCollectionId(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return DbContext.BookCollection.Find(collectionId);
            }
        }

        public List<BooksCollection> RetrieveBooksCollectionByUserId(int userId)
        {
            using (DbContext = new ApplicationDbContext())
            {
               return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetAll<BooksCollection>().Where(x => x.UserId == userId).ToList();
            }
        }

        public bool CheckIfCollectionExists(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return DbContext.BookCollection.Count(e => e.CollectionId == collectionId) > 0;
            }
        }

        public bool CheckIfCollectionNameExists(int userId, string collectionName)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return DbContext.BookCollection.Count(e => e.CollectionName.Equals(collectionName) && e.UserId == userId) > 0;
            }
        }
    }
}
