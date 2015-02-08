using BookSandbox.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSandbox.Models
{
    public class BookRepository : IBookRepository
    {
        private BookStore db = new BookStore();

        public BookRepository()
        {
            BookStoreInitializer.InitStore(db);
            Console.WriteLine("repository created");
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
            db.Books.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            var found = db.Books.Single(s=>s.Id == id);
            db.Books.Remove(found);
        }

        public bool Update(Book item)
        {
            var found = db.Books.Single(s => s.Id == item.Id);
            found.Name = item.Name;
            found.Price = item.Price;

            return true;
        }
    }
}