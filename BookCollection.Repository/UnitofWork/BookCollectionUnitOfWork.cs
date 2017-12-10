using BookCollection.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Repository.UnitofWork
{
    public class BookCollectionUnitOfWork : BaseUnitofWork
    {
        public void AddNewBookCollection(BooksCollection collection)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(collection);
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

        public void DeleteBookCollection(BooksCollection collection)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Delete(collection);
                Save();
            }
        }

        public BooksCollection RetrieveBookCollectionByCollectionId(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetById<BooksCollection>(collectionId);
            }
        }

        public List<BooksCollection> RetrieveBooksCollectionByUserId(int userId)
        {
            using (DbContext = new ApplicationDbContext())
            {
               return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetAll<BooksCollection>().Where(x => x.UserId == userId).ToList();
            }
        }
    }
}
