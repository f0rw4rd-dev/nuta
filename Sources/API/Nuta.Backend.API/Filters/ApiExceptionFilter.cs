using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Users.Domain.Exceptions;

namespace Nuta.Backend.API.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    //TODO: Подробности выводить только на тесте
    public void OnException(ExceptionContext context)
    {
        context.Result = context.Exception switch
        {
            EntityNotFoundException notFoundException
                => new BadRequestObjectResult(new { error = notFoundException.Message }),

            BusinessRuleValidationException validationException
                => new BadRequestObjectResult(new { error = validationException.Message }),

            _ => new ObjectResult(new { error = "Произошла внутренняя ошибка сервера." })
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Value = new
                {
                    message = context.Exception.Message,
                    stackTrace = context.Exception.StackTrace
                }
            }
        };

        context.ExceptionHandled = true;
    }
}