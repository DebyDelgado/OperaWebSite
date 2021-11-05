using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBook.Models;
using MVCBook.Data;
using System.Data.Entity;

namespace MVCBook.Controllers
{
    public class BookController : Controller
    {
        //instancia
        private BookDbContext context = new BookDbContext();
        // GET: Book
        public ActionResult Index()
        {
            //traer todos los books
            var books = context.Books.ToList();
            return View("Index", books);
        }
        //Creamos dos métodos para la inserción del book en la DB

        //primer create por GET para retornar la vista de registro
        [HttpGet]//El Get es implicito asi y todo lo podemos indicar
        public ActionResult Create()
        {
            //creamos la instancia con valores en las propiedades
            Book book = new Book();

            //retornamos la vista "Create" que tiene el objeto book
            return View("Create", book);
        }

        //Segundo Create es por Post para insertar el nuevo book en la base
        //cuando el usuario en la vista Create hace click en enviar
        //Opera/Create -->POST
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", book);
        }

    }
}