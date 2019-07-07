using System.Web;
using System.Web.Mvc;

namespace SkillTree_MVC_HW
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
