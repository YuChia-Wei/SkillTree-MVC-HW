using System;
using System.Collections.Generic;
using SkillTree_MVC_HW.Models.ViewModel;

namespace SkillTree_MVC_HW.Areas.PersonalAccounting.Controllers
{
    public partial class HomeController
    {

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
                Remark = accountNameStrings[random.Next(0, 3)],
                Amount = (decimal)random.Next(0, 1000000),
                Category = (PersonalAccountingViewModel.RecordCategory)random.Next(1, 3),
                Date = DateTime.Now.AddDays(random.Next(0, 10))
            };
        }
    }
}