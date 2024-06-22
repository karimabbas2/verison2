using System.ComponentModel.DataAnnotations;


namespace AppCore.CustomValidation
{
    public class SRTPRangeAttribute(string PropertyName) : ValidationAttribute
    {
        private readonly string RangeFrom = PropertyName;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rangeFromProperty = validationContext.ObjectType.GetProperty(RangeFrom);

            var rangeFromValue = (int?)rangeFromProperty?.GetValue(validationContext.ObjectInstance);

            if ((int?)value <= rangeFromValue)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be greater than RTP Range From");
            }

            return ValidationResult.Success;
        }
    }



}