using BookCollection.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Services
{
    public class BookCollectionService : ICollection<Book>
    {
        public bool IsReadOnly => false;

        public int Count => throw new NotImplementedException();

        public void Add(Book book)
        {
            //check if author exists, if false add author
            //add book to collection
        }

        public void Clear()
        {
        }

        public bool Contains(Book book)
        {
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            foreach (var book in array)
            {
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return null;
        }

        public bool Remove(Book book)
        {
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
