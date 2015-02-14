using BookSandbox.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BookSandbox.Models
{
    public class BookRepository : IBookRepository
    {
        private BookStore db = new BookStore();

        private class Nested
        {
            internal static readonly BookRepository instance = new BookRepository();

            public Nested()
            {
            }
        }

        public static BookRepository Instance
        {
            get
            {                
                return Nested.instance;
            }
        }

        private BookRepository()
        {
            Debug.WriteLine("repository created");
            InitRepository();
            Debug.WriteLine("repository initialized");
        }

        internal void InitRepository()
        {
            BookStoreInitializer.InitStore(db);
        }

        public IEnumerable<Book> GetAll()
        {
            return this.db.Books;
        }

        public Book Get(int id)
        {
            return this.db.Books.FirstOrDefault(f => f.Id == id);
        }

        public Book Add(Book item)
        {
            if (item.Id == 0)
            {
                item.Id = Book.GenerateNextId();
            }

            db.Books.Add(item);
            Debug.WriteLine("book added: " + item + ". Total books: " + this.db.Books.Count);
            return item;
        }

        public void Remove(int id)
        {
            var found = db.Books.FirstOrDefault(s=>s.Id == id);
            if (found != null)
            {
                db.Books.Remove(found);
                Debug.WriteLine("book deleted: " + found);
            }
        }

        public bool Update(Book item)
        {
            var found = db.Books.Single(s => s.Id == item.Id);
            found.Name = item.Name;
            found.Price = item.Price;

            Debug.WriteLine("book updated:  " + found);
            return true;
        }
    }
}