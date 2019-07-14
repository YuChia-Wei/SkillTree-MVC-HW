using System;
using System.Collections.Generic;
using System.Linq;
using SkillTree_MVC_HW.Models.DataModel;
using SkillTree_MVC_HW.Models.ViewModel;
using SkillTree_MVC_HW.Repository;

namespace SkillTree_MVC_HW.Service
{
    public class AccountBookService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(unitOfWork); ;
        }

        public IEnumerable<PersonalAccountingViewModel> Lookup()
        {
            var source = _accountBookRepository.LookupAll();
            var result = source.Select(v => new PersonalAccountingViewModel()
            {
                Category = (PersonalAccountingViewModel.RecordCategory)v.Categoryyy,
                Date = v.Dateee,
                Account = v.Remarkkk,
                Amount = v.Amounttt
            });
            return result;
        }

        public PersonalAccountingViewModel GetSingle(Guid orderId)
        {
            var source = _accountBookRepository.GetSingle(d => d.Id == orderId);
            return new PersonalAccountingViewModel
            {
                Category = (PersonalAccountingViewModel.RecordCategory)source.Categoryyy,
                Date = source.Dateee,
                Account = source.Remarkkk,
                Amount = source.Amounttt
            };
        }

        public void Add(PersonalAccountingViewModel order)
        {
            _accountBookRepository.Create(new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int)order.Amount,
                Categoryyy = (int)order.Category,
                Dateee = order.Date,
                Remarkkk = order.Account
            });
        }

        public void Edit(Guid id, PersonalAccountingViewModel pageData)
        {
            var oldData = _accountBookRepository.GetSingle(d => d.Id == id);
            if (oldData != null)
            {
                oldData.Amounttt = (int)pageData.Amount;
                oldData.Categoryyy = (int)pageData.Category;
                oldData.Dateee = pageData.Date;
                oldData.Remarkkk = pageData.Account;
            }
        }

        public void Delete(Guid id)
        {
            _accountBookRepository.Remove(_accountBookRepository.GetSingle(d => d.Id == id));
        }
    }
}