using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApiJwtProj1.ActionFilters
{
    public class ActionModifyFilter : IActionFilter

    {
        ILogger _logger;
        public ActionModifyFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ActionModifyFilter>();
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' before");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' after");
        }
    }
}

