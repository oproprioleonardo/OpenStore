using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenStore.Domain.Shared.Exceptions;

namespace OpenStore.Infra.Api.Filters
{
    public class DefaultExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception.GetType() == typeof(NotificationException))
            {
                var notificationException = (NotificationException)exception;
                var response = new
                {
                    exception = notificationException.GetType().Name,
                    message = notificationException.Message,
                    errors = notificationException.Errors
                };

                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(response);
                return;
            }
            
            var defaultErrorResponse = new
            {
                exception = exception.GetType().Name,
                message = "Ocorreu um erro durante a solicitação.",
                error = exception.Message,
                stackTrace = exception.StackTrace
            };
            
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(defaultErrorResponse);
        }
    }
}
