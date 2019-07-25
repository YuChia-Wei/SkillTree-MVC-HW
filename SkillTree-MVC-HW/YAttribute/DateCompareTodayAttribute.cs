using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTree_MVC_HW.YAttribute
{
    public enum DateCompareMethod
    {
        DoNotCare,
        MoreThen,
        LessThen,
        Equal
    }

    public class DateCompareTodayAttribute : ValidationAttribute
    {
        private DateCompareMethod _CompareMethod;

        public DateCompareTodayAttribute(DateCompareMethod dateCompareMethod)
        {
            _CompareMethod = dateCompareMethod;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime time)
            {
                switch (_CompareMethod)
                {
                    case DateCompareMethod.DoNotCare:
                    case DateCompareMethod.Equal when time.Date.CompareTo(DateTime.Today) == 0:
                    case DateCompareMethod.LessThen when time.Date.CompareTo(DateTime.Today) <= 0:
                    case DateCompareMethod.MoreThen when time.Date.CompareTo(DateTime.Today) >= 0:
                        return ValidationResult.Success;

                    default:
                        return new ValidationResult(GetErrorMsg(time));
                }
            }

            return new ValidationResult(GetErrorMsg(value));
        }

        protected string GetErrorMsg(object validData)
        {
            return validData is DateTime date ? this.GetErrorMsg(date) : "Unsupported type";
        }

        protected string GetErrorMsg(DateTime validDateTime)
        {
            switch (_CompareMethod)
            {
                case DateCompareMethod.Equal:
                    return $"Date must be Equal with {DateTime.Today.Date:yyyy-MM-dd}";

                case DateCompareMethod.LessThen:
                    return $"Date must be less then {DateTime.Today.Date:yyyy-MM-dd}";

                case DateCompareMethod.MoreThen:
                    return $"Date must be More then {DateTime.Today.Date:yyyy-MM-dd}";

                default:
                    return "Date error";
            }
        }
    }
}