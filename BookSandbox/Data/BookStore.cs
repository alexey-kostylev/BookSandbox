using BookSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSandbox.Data
{
    public class BookStore
    {
        private List<Book> mDb;

        public BookStore()
        {
            this.mDb = new List<Book>();

            Console.WriteLine("store created");
        }

        public ICollection<Book> Books { get { return this.mDb; } }
    }
}