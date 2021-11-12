using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenWebSite.Filters
{
    public class MyFilterAction: ActionFilterAttribute
    {
        //filtro de acción -  ANTES
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + "Action: " + action + "Paso por OnActionExecuting");
        }
        //filtro de acción -  DESPUES
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            Debug.WriteLine("Controller: " + controller + "Action: " + action + "Paso por OnActionExecuting");
        }
    }
}