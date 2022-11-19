using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FIAPSmartCity.Controllers.Filtros
{
    public sealed class LogFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine("teste");
            System.Diagnostics.Debug.WriteLine("==========================================================");
            System.Diagnostics.Debug.WriteLine("== Iniciando a gravação da mensagem de  log");
            System.Diagnostics.Debug.WriteLine("Controller : " + context.RouteData.Values["Controller"] + " executado");
            System.Diagnostics.Debug.WriteLine("Action : " + context.RouteData.Values["Action"] + " executado");
            System.Diagnostics.Debug.WriteLine("Data e Hora : " + DateTime.Now);
            System.Diagnostics.Debug.WriteLine("==========================================================");
        }

    }
}
