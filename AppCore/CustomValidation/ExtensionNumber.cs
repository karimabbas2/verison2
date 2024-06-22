using System.ComponentModel.DataAnnotations;
using AppCore.Interfaces;
using AutoMapper.Configuration;


namespace AppCore.CustomValidation
{
    public class ExtensionNumber() : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
        System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var ext = (IExtenstions)validationContext.GetService(typeof(IExtenstions));

            if (ext == null)
            {
                throw new InvalidOperationException("ext service is not available.");
            }

            List<int> numbers = ext.GetlAllExtensionNumers();
            if (value is not null)
            {
                if (!numbers.Contains((int)value))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("This Extension Number Already Exists.");
                }
            }
            return new ValidationResult("This Extension Number Already Exists.");

        }
    }
}