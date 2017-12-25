using System.Collections.Generic;
using BookCollection.Core;
using BookCollection.Repository.UnitofWork;

namespace BookCollection.Service.Service
{
    public class AuthorService : Service
    {
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

        public bool CheckIfAuthorExists(Author author)
        {
            return new AuthorUnitofWork().Exists(author);
        }

        public void CreateNewAuthor(Author author)
        {
            new AuthorUnitofWork().AddNewAuthor(author);
        }

        public void CreateNewAuthors(List<Author> authors)
        {
            new AuthorUnitofWork().AddNewAuthorList(authors);
        }
    }
}
