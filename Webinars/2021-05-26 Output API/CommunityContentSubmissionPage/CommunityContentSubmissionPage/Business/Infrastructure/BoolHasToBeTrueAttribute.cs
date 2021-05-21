using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityContentSubmissionPage.Business.Infrastructure
{
    public class BoolHasToBeTrueAttribute : ValidationAttribute
    {
        private readonly string _errorMessage;

        public BoolHasToBeTrueAttribute(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult(_errorMessage);
            }

            if (!(value is bool))
            {
                return new ValidationResult(_errorMessage);
            }

            var valueAsBool = (bool)value;

            if (valueAsBool == false)
            {
                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
