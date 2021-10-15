using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class EnsureItemIdExistFilter : IActionFilter
    {
        private readonly IItemService _service;
        public EnsureItemIdExistFilter(IItemService service)
        {
            _service = service;
        }
        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            object obj;
            var hasVal = context.ActionArguments.TryGetValue("itemId", out obj);
            if(hasVal)
            {
                var itemId = (int)context.ActionArguments["itemId"];
                var isExist = _service.Get(itemId);
                if (isExist == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
    public class EnsureItemIdExistFilterAttribute : TypeFilterAttribute
    {
        public EnsureItemIdExistFilterAttribute() : base(typeof(EnsureItemIdExistFilter))
        {
        }
    }
}
