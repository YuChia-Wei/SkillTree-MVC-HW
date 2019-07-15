using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTree_MVC_HW.Repository;
using SkillTree_MVC_HW.Service;

namespace SkillTree_MVC_HW.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookService;
        private readonly SkillTreeHomeWorkUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new SkillTreeHomeWorkUnitOfWork();
            _accountBookService = new AccountBookService(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View(_accountBookService.Lookup());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}