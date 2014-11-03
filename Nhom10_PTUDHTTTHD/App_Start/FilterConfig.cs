using System.Web;
using System.Web.Mvc;

namespace Nhom10_PTUDHTTTHD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}