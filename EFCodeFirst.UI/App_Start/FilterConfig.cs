using EFCodeFirst.UI.Filter;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new PermissionValidataAttribute());
        }
    }
}