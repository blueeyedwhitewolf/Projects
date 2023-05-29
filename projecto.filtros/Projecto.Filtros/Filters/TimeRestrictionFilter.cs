using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto.Filtros.Filters
{
    public class TimeRestrictionFilter : Attribute, IActionFilter,
                                                    IResultFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (DateTime.Now.Hour == 9 && DateTime.Now.Minute == 50)
            {
                throw new UnauthorizedAccessException();

                // alternativa
                //context.HttpContext.Response.StatusCode = 403;

            }

            //throw new NotImplementedException();
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }


    public  class MyFilterXpto : ActionFilterAttribute
    {
        private String _Nome;
        public MyFilterXpto(String Nome)
        {
            _Nome = Nome;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Author", _Nome);

            base.OnActionExecuting(context);
        }

       
    
    }



}
