using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.ModelValidators
{
    public static class CommonValidationHandling
    {
        public static void CommonValidationHandler(ValidationResult validation)
        {
            if (!validation.IsValid)
            {
                string errorMessages = string.Empty;

                for (int i = 0; i < validation.Errors.Count; i++)
                {
                    errorMessages += validation.Errors[i].ErrorMessage + "\r";
                }

                throw new ValidationException(errorMessages);
            }
        }
    }
}
