using BookCollection.Core;
using System.Collections.Generic;
using System.Linq;

namespace BookCollection.Repository.UnitofWork
{
    public class AuthorUnitofWork : BaseUnitofWork
    {
        public void AddNewAuthor(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(author);
                Save();
            }
        }

        public void AddNewAuthorList(List<Author> authors)
        {
            using (DbContext = new ApplicationDbContext())
            {
                foreach (Author author in authors)
                {
                    RepositoryGetter.RetrieveCollectionRepository(DbContext).Create(author);
                }
                Save();
            }
        }

        public void UpdateAuthor(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Update(author);
                Save();
            }
        }

        public void DeleteAuthor(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                RepositoryGetter.RetrieveCollectionRepository(DbContext).Delete(author);
                Save();
            }
        }

        public bool Exists(Author author)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).Exists(author); ;
            }
        }

        public Author RetrieveAuthorByAuthorId(int authorId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                return RepositoryGetter.RetrieveReadOnlyRepository(DbContext).GetById<Author>(authorId);
            }
        }

        public List<Author> RetrieveAuthorsByBookId(int bookId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Author>().Where(x => x.Books.FirstOrDefault().BookId == bookId).ToList();
            }
        }

        public List<Author> RetrieveAuthorsByCollectionId(int collectionId)
        {
            using (DbContext = new ApplicationDbContext())
            {
                var repo = RepositoryGetter.RetrieveReadOnlyRepository(DbContext);
                return repo.GetAll<Author>().Where(x => x.Books.FirstOrDefault().CollectionId == collectionId).ToList();
            }
        }
    }
}
