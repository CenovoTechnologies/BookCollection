using System;
using System.Collections;
using System.Collections.Generic;

namespace BookCollection.Core
{
    public class BookCollection : ICollection<Book>
    {
        public List<Book> Collection { get; set; }
        
        public BookCollection()
        {
            Collection = new List<Book>();
        }

        public Book this[int index]
        {
            get { return (Book)Collection[index]; }
            set { Collection[index] = value; }
        }

        public int Count
        {
            get
            {
                return Collection.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public void Add(Book book)
        {
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
            foreach (Book book in array)
            {
                Collection.Add(book);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Book book)
        {
            return Collection.Remove(book);
        }

        //TODO:
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
