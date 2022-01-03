using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute()
        { }
		public void OnActionExecuting(ActionExecutingContext context)
		{
			var action = context.RouteData.Values["action"];
			var controller = context.RouteData.Values["controller"];

			object? param = context.ActionArguments
				.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;


			if (!context.ModelState.IsValid)
				context.Result = new UnprocessableEntityObjectResult(context.ModelState.Values.LastOrDefault().Errors);

			if (param is null && context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
			}

			return;
		}
		public void OnActionExecuted(ActionExecutedContext context) { }


    }
}
