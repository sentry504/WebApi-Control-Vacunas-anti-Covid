using System.Web;
using System.Web.Mvc;

namespace WebApi_Control_Vacunas_anti_Covid
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
