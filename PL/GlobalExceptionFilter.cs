using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException)
        {
            context.Result = new BadRequestObjectResult(new { error = context.Exception.Message });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new BadRequestObjectResult(new { error = "Internal error" });
            context.ExceptionHandled = true;
        }
    }
}
