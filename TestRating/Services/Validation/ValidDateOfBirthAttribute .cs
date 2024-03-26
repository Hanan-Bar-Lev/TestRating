using System.ComponentModel.DataAnnotations;
using TestRating.Models;

namespace TestRating.Services.Validation
{


    public class ValidDateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var policy = validationContext.ObjectInstance as LifePolicy;

            if (policy != null)
            {
                if (policy.DateOfBirth == DateTime.MinValue)
                {
                    return new ValidationResult("Life policy must include Date of Birth.");
                }

                if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                {
                    return new ValidationResult("Max eligible age for coverage is 100 years.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
