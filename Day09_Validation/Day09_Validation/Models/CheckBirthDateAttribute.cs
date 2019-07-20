using System;
using System.ComponentModel.DataAnnotations;

namespace Day09_Validation.Models
{
    public class CheckBirthDateAttribute : ValidationAttribute
    {
        public CheckBirthDateAttribute(string errorMessage = "Ngày sinh không hợp lệ") : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            DateTime dateTime = (DateTime) value;

            return dateTime < DateTime.Now;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as Employee;
            if (model == null)
            {
                throw new ArgumentException("Tham số truyền không đúng");
            }
            if (DateTime.Now.Year - model.BirthDate.Year < 10)
            {
                return new ValidationResult("Chưa đủ 10 tuổi");
            }
            return ValidationResult.Success;
        }
    }
}