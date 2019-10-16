using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProjectSIP.Exceptions
{
    [Obsolete]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public CustomExceptionFilter(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public override void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            if (!hostingEnvironment.IsDevelopment())
            {
                context.Result = new ConflictObjectResult($"В методе {actionName} возникло исключение: \n {exceptionMessage} \n {exceptionStack}");
            }
            else
            {
                context.Result = new ConflictObjectResult($"Возникло исключение:\n{exceptionMessage}");
            }
            context.ExceptionHandled = true;
        }
    }
}
