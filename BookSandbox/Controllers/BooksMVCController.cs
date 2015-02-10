using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSandbox.Controllers
{
    public class BooksMVCController : Controller
    {
        // GET: BooksMVC
        public ActionResult Index()
        {
            return View();
        }
    }
}