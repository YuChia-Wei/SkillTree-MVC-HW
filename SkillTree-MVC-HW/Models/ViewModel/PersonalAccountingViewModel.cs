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

            [Obsolete("未使用", true)]
            InternalTransfer
        }

        [Required]
        public RecordCategory Category { get; set; }

        [Obsolete("未使用", true)]
        public string Account { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Remark { get; set; }
    }
}