using System.ComponentModel.DataAnnotations;

namespace AppCore.CustomValidation
{
    public class IsRegisterTrunkAttribute(string propertyName, string ItsValue) : ValidationAttribute
    {
        public readonly string _propertyName = propertyName;
        public readonly string _ItsValue = ItsValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var trunk = validationContext.ObjectType.GetProperty(_propertyName);

            var trunkType = trunk?.GetValue(validationContext.ObjectInstance);

            if (Equals(trunkType, _ItsValue))
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