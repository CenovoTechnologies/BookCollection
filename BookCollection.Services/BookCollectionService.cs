﻿using BookCollection.Core;
using BookCollection.Repository.UnitofWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Services
{
    public class BookCollectionService : Service
    {

        public void CreateNewCollection(BooksCollection collection)
        {
            new BookCollectionUnitOfWork().AddNewBookCollection(collection);
        }

        public void UpdateCollection(BooksCollection collection)
        {
            new BookCollectionUnitOfWork().UpdateBookCollection(collection);
        }

        public void DeleteCollection(BooksCollection collection)
        {
            new BookCollectionUnitOfWork().DeleteBookCollection(collection);
        }

        public List<BooksCollection> RetrieveCollectionsByCollectionId(int collectionId)
        {
            return new BookCollectionUnitOfWork().RetrieveBooksCollectionByUserId(collectionId);
        }

        public List<BooksCollection> RetrieveCollectionsByUserId(int userId)
        {
            return new BookCollectionUnitOfWork().RetrieveBooksCollectionByUserId(userId);
        }

        public bool IsBookAlreadyInCollection(Book book)
        {
            return false;
        }

        public void RemoveBookFromCollection(Book book)
        {
        }
    }
}
