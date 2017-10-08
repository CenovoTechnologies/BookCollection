using System.Collections;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class Enumerator : IEnumerator<Book>
    {
        private BookCollection _collection;
        private int currentIndex;
        private Book currentBook;

        public Enumerator(BookCollection collection)
        {
            _collection = collection;
            currentIndex = -1;
            currentBook = default(Book);
        }

        public Book Current
        {
            get { return currentBook; }
        }


        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (++currentIndex >= _collection.Count)
            {
                return false;
            }
            currentBook = _collection[0];
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
