using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SkillTree_MVC_HW.Models.ViewModel;
using SkillTree_MVC_HW.Repository;
using SkillTree_MVC_HW.Service;

namespace SkillTree_MVC_HW.Areas.PersonalAccounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookService;
        private readonly AccountBookLogService _accountBookLogService;
        private readonly SkillTreeHomeWorkUnitOfWork _unitOfWork;

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
            List<PersonalAccountingViewModel> showData =
                new List<PersonalAccountingViewModel>();

            GetPersonalAccountingViewModels(showData);

            return View(showData);
        }

        private List<PersonalAccountingViewModel> GetPersonalAccountingViewModels()
        {
            return GetPersonalAccountingViewModels(new List<PersonalAccountingViewModel>());
        }

        private List<PersonalAccountingViewModel> GetPersonalAccountingViewModels(List<PersonalAccountingViewModel> orgAccountingViewModels)
        {
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                orgAccountingViewModels.Add(GetRandomAccountingViewModel(random));
            }

            return orgAccountingViewModels;
        }

        private PersonalAccountingViewModel GetRandomAccountingViewModel()
        {
            return GetRandomAccountingViewModel(new Random());
        }

        private PersonalAccountingViewModel GetRandomAccountingViewModel(Random random)
        {
            string[] accountNameStrings = new[] { "A 帳戶", "B 帳戶", "C 帳戶" };

            return new PersonalAccountingViewModel()
            {
                Account = accountNameStrings[random.Next(0, 3)],
                Amount = (decimal)random.Next(0, 1000000),
                Category = (PersonalAccountingViewModel.RecordCategory)random.Next(1, 3),
                Date = DateTime.Now.AddDays(random.Next(0, 10))
            };
        }
    }
}