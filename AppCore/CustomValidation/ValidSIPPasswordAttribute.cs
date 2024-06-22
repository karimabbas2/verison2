using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppCore.CustomValidation
{
    public class ValidSIPPasswordAttribute : ValidationAttribute
    {
        private const string Pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value.ToString();
            var regex = new Regex(Pattern);
            if (!regex.IsMatch(password))
            {
                return new ValidationResult("The SIP password must be complex.");
            }
            return ValidationResult.Success;
        }

    }
}