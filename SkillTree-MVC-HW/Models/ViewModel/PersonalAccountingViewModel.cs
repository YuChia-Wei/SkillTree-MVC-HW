using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTree_MVC_HW.Models.ViewModel
{
    public class PersonalAccountingViewModel
    {
        public enum RecordCategory
        {
            Income,
            Expenditure,
            InternalTransfer
        }

        public RecordCategory Category { get; set; }

        public string Account { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Amount { get; set; }
    }
}