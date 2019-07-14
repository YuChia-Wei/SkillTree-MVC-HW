using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SkillTree_MVC_HW.Models.ViewModel;
using SkillTree_MVC_HW.Repository;
using SkillTree_MVC_HW.Service;

namespace SkillTree_MVC_HW.Areas.PersonalAccounting.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly AccountBookService _accountBookService;
        private readonly SkillTreeHomeWorkUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new SkillTreeHomeWorkUnitOfWork();
            _accountBookService = new AccountBookService(_unitOfWork);
        }

        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Input()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RecordList()
        {
            //List<PersonalAccountingViewModel> showData =
            //    new List<PersonalAccountingViewModel>();

            //GetPersonalAccountingViewModels(showData);

            return View(_accountBookService.Lookup());
        }
    }
}