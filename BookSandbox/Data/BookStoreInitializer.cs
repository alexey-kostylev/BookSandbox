using BookSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSandbox.Data
{
    public static class BookStoreInitializer
    {
        public static void InitStore(BookStore store)
        {
            if (store == null)
            {
                throw new ArgumentNullException("store");
            }

            store.Books.Add(new Book("War and Peace", 100));
            store.Books.Add(new Book("Web developing in MVC 4", 20));

            Console.WriteLine("store initialized");
        }
    }
}