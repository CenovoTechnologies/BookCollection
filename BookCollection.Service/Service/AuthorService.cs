using System.Collections.Generic;
using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using BookCollection.Repository;

namespace BookCollection.Service.Service
{
    public class AuthorService : Service
    {
        private ApplicationDbContext db;

        public List<Author> RetrieveAuthorsByCollectionId(int collectionId)
        {
            return new AuthorUnitofWork().RetrieveAuthorsByCollectionId(collectionId);
        }

        public List<Author> RetrieveAuthorsByBookId(int bookId)
        {
            return new AuthorUnitofWork().RetrieveAuthorsByBookId(bookId);
        }

        public Author RetrieveAuthorByAuthorId(int authorId)
        {
            return new AuthorUnitofWork().RetrieveAuthorByAuthorId(authorId);
        }

        public bool CheckIfAuthorExists(int id)
        {
            using (db = new ApplicationDbContext())
            {
                if (db.Author.Find(id) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CreateNewAuthor(Author author)
        {
            new AuthorUnitofWork().AddNewAuthor(author);
            return true;
        }

        public void CreateNewAuthors(List<Author> authors)
        {
            new AuthorUnitofWork().AddNewAuthorList(authors);
        }

        public bool UpdateAuthor(Author author)
        {
            return false;
        }
    }
}
