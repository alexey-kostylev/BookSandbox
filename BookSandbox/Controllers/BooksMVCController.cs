using BookSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSandbox.Controllers
{
    public class BooksMVCController : Controller
    {
        private IBookRepository repo = null;

        public BooksMVCController(IBookRepository repository)
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

        // GET: BooksMVC
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBook(Book book)
        {
            this.repo.Add(book);

            return RedirectToAction("Index");
        }

        public ActionResult SearchById(int id)
        {
            return RedirectToAction("Index");
        }
        
        public ActionResult GetBooks()
        {
            var data = this.repo.GetAll();
            
            return PartialView("BookCollectionView", data);
            //return Content("Hi there!");
        }
    }
}