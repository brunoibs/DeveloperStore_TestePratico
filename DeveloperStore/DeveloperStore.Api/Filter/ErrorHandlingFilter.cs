using DeveloperStore.Infra;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeveloperStore.Api.Filter
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public ErrorHandlingFilter()
        {
        }
        public override void OnException(ExceptionContext context)
        {
            LogSentry.EnviarExceptionSentry(context.Exception);
        }
    }
}
