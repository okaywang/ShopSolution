using SE.Website.Models;
using System.Web.Mvc;
using System.Linq;
using SE.Website.Filters;

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

}