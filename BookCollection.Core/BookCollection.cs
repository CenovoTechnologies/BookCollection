using System;
using System.Collections;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BookCollection : Entity<Int32>, ICollection<Book>
    {
        public List<Book> Collection { get; set; }
        
        public BookCollection()
        {
            Collection = new List<Book>();
        }

        public Book this[int index]
        {
            get => (Book)Collection[index];
            set => Collection[index] = value;
        }

        public int Count => Collection.Count;

        public bool IsReadOnly => false;

        public void Add(Book book)
        {
            //check if author exists, if false add author
            //save book asyncly
            //add book to collection
            Collection.Add(book);
        }

        public void Clear()
        {
            Collection.Clear();
        }

        public bool Contains(Book book)
        {
            return Collection.Contains(book);
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            foreach (var book in array)
            {
                Collection.Add(book);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        public bool Remove(Book book)
        {
            return Collection.Remove(book);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
