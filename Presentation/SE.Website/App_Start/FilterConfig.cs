using SE.Website.Models;
using System.Web.Mvc;
using System.Linq;

namespace SE.Website.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidateModelStateAttribute());
        }
    }

    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var result = new ResultModel(false, GetErrorMessage(viewData.ModelState));
                    filterContext.Result = new JsonResult() { Data = result };
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private string GetErrorMessage(ModelStateDictionary modelState)
        {
            var msg = string.Empty;
            foreach (var item in modelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    msg = item.Errors.First().ErrorMessage;
                }
            }
            return msg;
        }
    }
}