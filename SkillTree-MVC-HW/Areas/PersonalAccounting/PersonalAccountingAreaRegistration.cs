using System.Web.Mvc;

namespace SkillTree_MVC_HW.Areas.PersonalAccounting
{
    public class PersonalAccountingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PersonalAccounting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PersonalAccounting_default",
                "PersonalAccounting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}