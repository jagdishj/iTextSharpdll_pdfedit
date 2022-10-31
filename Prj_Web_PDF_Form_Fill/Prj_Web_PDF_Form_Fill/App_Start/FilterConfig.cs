using System.Web;
using System.Web.Mvc;

namespace Prj_Web_PDF_Form_Fill
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
