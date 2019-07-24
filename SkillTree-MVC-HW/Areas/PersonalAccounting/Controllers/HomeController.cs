using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult RecordList()
        {
            return View(_accountBookService.Lookup().OrderBy( a => a.Date));
        }

        [ChildActionOnly]
        public ActionResult Input()
        {
            return View();
        }

        // POST: WithServiceAndLogInUnitOfWork/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Input([Bind(Include = "Category,Date,Amount,Remark")]
            PersonalAccountingViewModel accountingViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountBookService.Add(accountingViewModel);
                _unitOfWork.Commit();
                ModelState.Clear();
            }

            return View();
        }
    }
}