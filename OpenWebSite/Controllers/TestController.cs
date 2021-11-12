using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenWebSite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Login(string name, string role)
        {
            //viewbag lo usamos para pasar datos del controlador a la vista
            ViewBag.Name = name;
            ViewBag.Role = role;

            return View();
        }
        public ActionResult SearchByTitle(string title)
        {
            ViewBag.Title = title;
            return View();
        }
    }
}