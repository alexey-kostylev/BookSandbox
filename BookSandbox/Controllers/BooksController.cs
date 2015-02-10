using BookSandbox.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookSandbox.Controllers
{
    public class BooksController : ApiController
    {
        public IBookRepository repo;

        public BooksController(IBookRepository repository)
        {
            if (repo == null)
            {
                if (repository == null)
                {
                    throw new ArgumentNullException("repository");
                }

                repo = repository;
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.repo.GetAll();
        }

        public Book GetBook(int id)
        {
            var found = this.repo.Get(id);

            if (found == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
           
            return found;
        }

        public HttpResponseMessage PostBook(Book book)
        {
            var created = this.repo.Add(book);
            var response = Request.CreateResponse<Book>(HttpStatusCode.Created, created);

            string uri = Url.Route(null, new { id = created.Id });

            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        public void UpdateBook(int id, Book book)
        {
            if (!this.repo.Update(book))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }

        public HttpResponseMessage DeleteBook(int id)
        {
            this.repo.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
