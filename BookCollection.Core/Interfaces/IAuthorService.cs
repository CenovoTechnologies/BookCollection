using System.Collections.Generic;

namespace BookCollection.Core.Interfaces
{
    public interface IAuthorService
    {
        IList<Author> RetrieveAuthorsByCollectionId(int collectionId);

        IList<Author> RetrieveAuthorsByBookId(int bookId);

        Author RetrieveAuthorByAuthorId(int authorId);

        bool CheckIfAuthorExists(int id);

        void CreateNewAuthor(Author author);

        void CreateNewAuthors(IList<Author> authors);

        void UpdateAuthor(Author author);
    }
}
