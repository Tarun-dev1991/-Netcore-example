using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQuery_AJAX_WebAPI_CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
        public ActionResult User()
        {
            return View();
        }

        // GET: Home
        public ActionResult UserDetail()
        {
            return View();
        }
    }
}