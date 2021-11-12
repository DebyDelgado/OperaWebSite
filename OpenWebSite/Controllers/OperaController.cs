using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenWebSite.Models;
using OpenWebSite.Data;
using System.Data.Entity;
using System.Diagnostics;
using OpenWebSite.Filters; //agregar para usar MyFilterAction

namespace OpenWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        //Crear instancia del dbcontext

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index (nombre de controlador y nombre del metodo)
        public ActionResult Index()
        {
            //Traer todas las operas usando EF

            var operas = context.Operas.ToList();

            //el controller retorna una vista "Index" con la lista de operas
            return View("Index", operas);
        }

        //Creamos dos métodos para la inserción de la opera en la DB

        //primer create por GET para retornar la vista de registro
        [HttpGet]//el get es implicito asi y todo lo podemos indicar
        public ActionResult Create()
        {
            //creamos la instancia sin valores en las propiedades
            Opera opera = new Opera();

            //retornamos la vista "create" que tiene el objeto opera
            return View("Create", opera);

        }

        //segundo create es por Post para insertar la nueva opera en la base
        //cuando el usuario en la vista create hace click en enviar
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Create", opera);
        }
        //GET
        //Opera/Detail/id
        //Opera/Detail/2
        public ActionResult Detail(int id)
        {

            Opera opera = context.Operas.Find(id);
            if (opera != null) { 
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();

            }
        }

        //GET /OPERA/DELETE/ID
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }

        }
        // /OPERA/DELETE
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");

        }


        //GET /OPERA /EDIT

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Edit", opera);

            }
            else
                return HttpNotFound();

        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }
        //filtro de acción -  ANTES
      //  protected override void OnActionExecuting(ActionExecutingContext filterContext)
       // {
            //controller/action
            //{controller}/{action}
            //opera/create
         //   var controller = filterContext.RouteData.Values["controller"];
         //   var action = filterContext.RouteData.Values["action"];
         //   Debug.WriteLine("Controller: " + controller + "Action: " + action + "Paso por OnActionExecuting");
     //   }
        //filtro de acción -  DESPUES
      //  protected override void OnActionExecuted(ActionExecutedContext filterContext)
      //  {
        //    var controller = filterContext.RouteData.Values["controller"];
       //     var action = filterContext.RouteData.Values["action"];
       //     Debug.WriteLine("Controller: " + controller + "Action: " + action + "Paso por OnActionExecuting");
      //  }
    }
}