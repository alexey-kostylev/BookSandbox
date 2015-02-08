using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSandbox.Models
{
    public class Book
    {
        private static int IdSequence;

        public static int GenerateNextId()
        {
            return ++IdSequence;
        }

        public Book()
        {
        }

        public Book(string name, decimal price)
        {
            this.Id = GenerateNextId();
            this.Name = name;
            this.Price = price;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get;set;}
    }
}