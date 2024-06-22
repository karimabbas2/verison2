using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace AppCore.CustomValidation
{
    public class BoolServserAddressAttribute(string propertyName, bool ItsValue) : ValidationAttribute
    {
        public readonly string _propertyName = propertyName;
        public readonly bool _ItsValue = ItsValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var checkbox = validationContext.ObjectType.GetProperty(_propertyName);

            var checkboxValue = checkbox?.GetValue(validationContext.ObjectInstance);

            if (_ItsValue && Equals(checkboxValue, true))
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult($"{validationContext.DisplayName} is required.");
                }
            }
            return ValidationResult.Success;

        }
    }
}