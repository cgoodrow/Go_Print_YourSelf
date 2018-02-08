using System.Web;
using System.Web.Mvc;

namespace Go_Print_YourSelf
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
