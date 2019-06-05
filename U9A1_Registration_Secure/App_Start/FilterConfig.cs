using System.Web;
using System.Web.Mvc;

namespace U9A1_Registration_Secure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
